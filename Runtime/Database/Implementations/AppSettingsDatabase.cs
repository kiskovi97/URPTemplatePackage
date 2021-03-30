using Newtonsoft.Json;
using System;
using UnityEngine;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    internal class AppSettingsDatabase : DatabaseTableBase<string>, IAppSettingsDatabase
    {
        public float UiSoundVolume { get => database.uiSoundVolume; 
            set {
                if (value != database.uiSoundVolume)
                {
                    Updated?.Invoke();
                    database.uiSoundVolume = value;
                }
            } 
        }

        public AppSettingsDatabase()
        {
            additionalName = "AppSettings";
        }

        private SavableChangedDatabase database = new SavableChangedDatabase();

        public event Action Updated;

        protected override SavableDatabaseBase mDatabase { get => database; }

        [Serializable]
        public class SavableChangedDatabase : SavableDatabaseBase
        {
            public float uiSoundVolume = 0f;
            public override void CopyData(string json)
            {
                base.CopyData(json);
                var objectA = JsonConvert.DeserializeObject<SavableChangedDatabase>(json);
                uiSoundVolume = objectA.uiSoundVolume;
            }
        }

        protected override void DatabaseLoaded()
        {
            base.DatabaseLoaded();
            Updated?.Invoke();
        }

        protected override void OnErrorRecived(ErrorCode errorCode)
        {
        }
    }
}
