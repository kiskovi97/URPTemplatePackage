
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    public class DatabaseTable<T> : DatabaseTableBase<T>, IDataProvider<T>, IDatabaseManagable where T : SavableItem
    {
        private SavableDatabase database = new SavableDatabase();
        protected override SavableDatabaseBase mDatabase { get => database; }

        [Serializable]
        public class SavableDatabase : SavableDatabaseBase
        {
            public Dictionary<string, T> mElements = new Dictionary<string, T>();
            public override void CopyData(string json)
            {
                base.CopyData(json);
                var objectA = JsonConvert.DeserializeObject<SavableDatabase>(json);
                mElements = objectA.mElements ?? mElements;
            }
        }

        private Action<TableState> OnDataArrived = null;


        public DatabaseTable(string name = "Table") : base(name)
        {
        }

        protected override void OnErrorRecived(ErrorCode errorCode)
        {
            SendOneTimeNotification(TableState.ConnectionNeeded);
        }

        #region IDataProvider

        public virtual T[] GetAll()
        {
            return database.mElements.Values.ToArray();
        }

        public T GetById(string id)
        {
            return database.mElements[id];
        }

        public T SelectItem<TKey>(Func<T, bool> predictate, Func<T, TKey> orderPredictate)
        {
            return orderPredictate == null 
                ? database.mElements.Values.Where(predictate).DefaultIfEmpty().First() 
                : database.mElements.Values.Where(predictate).OrderBy(orderPredictate).DefaultIfEmpty().First();
        }

        public T[] SelectItems<TKey>(Func<T, bool> predictate, Func<T, TKey> orderPredictate)
        {
            return orderPredictate == null
                ? database.mElements.Values.Where(predictate).ToArray()
                : database.mElements.Values.Where(predictate).OrderBy(orderPredictate).ToArray();
        }

        public void AddItem(T item)
        {
            database.mElements.Add(item.id, item);
        }

        public void RemoveItem(string itemId)
        {
            database.mElements.Remove(itemId);
        }

        public void RemoveItems(Func<T, bool> predictate)
        {
            database.mElements = database.mElements.Values.Where(item => !predictate(item)).ToDictionary(item => item.id);
        }

        #endregion

        private void SendOneTimeNotification(TableState state)
        {
            OnDataArrived?.Invoke(state);
            OnDataArrived = null;
        }

        public void UsedOnlyForAOTCodeGeneration()
        {
            SelectItem<int>(null, null);
            SelectItems<int>(null, null);

            SelectItem<string>(null, null);
            SelectItems<string>(null, null);
            // Include an exception so we can be sure to know if this method is ever called.
            throw new InvalidOperationException("This method is used for AOT code generation only. Do not call it at runtime.");
        }
    }
}
