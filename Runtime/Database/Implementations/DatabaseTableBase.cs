
using Newtonsoft.Json;
using System;
using UnityEngine;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    public abstract class DatabaseTableBase<T> : IDatabaseTable
    {
        private static readonly object mLockKey = new object();
        private string mFileName { get => "/" + additionalName + typeof(T).Name + ".json"; }
        protected string additionalName = "";

        protected static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        };

        public enum State
        {
            LoadingOffline,
            Offline,
        }
        private volatile State state = State.LoadingOffline;
        public State mState
        {
            get => state; protected set
            {
                state = value;
            }
        }

        public IFileLoader mFileLoader => FileLoaderProvider.FileLoader;

        public DatabaseTableBase(string name = "Table")
        {
            additionalName = name;
        }

        public void LoadFromDisk()
        {
            if (mState != State.LoadingOffline) return;

            var lPath = Application.persistentDataPath + mFileName;
            var lFullString = mFileLoader.GetData(lPath);

            if (!lFullString.Equals(""))
            {
                try
                {
                    SetFromJson(lFullString);
                    DebugLog.LogDebug("Data Loaded from: " + lPath + " , tableName: " + typeof(T).Name + " " + additionalName);
                }
                catch (Exception exp)
                {
                    NoDataLoaded();
                    OnErrorRecived(exp.Message, ErrorCode.OfflineLoadingFailed);
                }
            }
            else
            {
                DebugLog.LogDebug("File not found " + typeof(T).Name + " " + additionalName);
                NoDataLoaded();
                SaveToDisk();
            }
        }

        public void SaveToDisk()
        {
            lock (mLockKey)
            {
                if (mState.Equals(State.LoadingOffline)) return;
                var lPath = Application.persistentDataPath + mFileName;
                var lFullString = GetJson(settings);
                mFileLoader.SaveData(lPath, lFullString);
            }
        }

        protected abstract SavableDatabaseBase mDatabase { get; }

        [Serializable]
        public class SavableDatabaseBase
        {
            public virtual void CopyData(string json)
            {
            }
        }

        private string GetJson(JsonSerializerSettings settings)
        {
            DatabaseSaving();
            var json = JsonConvert.SerializeObject(mDatabase, settings);
            return json;
        }

        private void SetFromJson(string json)
        {
            mDatabase.CopyData(json);
            mState = State.Offline;
            DatabaseLoaded();
        }

        protected virtual void DatabaseSaving() { }

        protected virtual void DatabaseLoaded() { }

        protected virtual void NoDataLoaded() {
            mState = State.Offline;
        }

        public void OnErrorRecived(string errorMessage, ErrorCode errorCode)
        {
            DebugLog.LogWarning(typeof(T).Name + " table recived an error : " + errorMessage, errorCode);
            OnErrorRecived(errorCode);
        }

        protected abstract void OnErrorRecived(ErrorCode errorCode);
    }
}
