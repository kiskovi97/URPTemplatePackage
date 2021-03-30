using System;

namespace URPTemplate.Database
{
    public interface IDataProvider<T> : IDataProviderGet<T>
    {
        T SelectItem<TKey>(Func<T, bool> predictate, Func<T, TKey> orderPredictate);
        T[] SelectItems<TKey>(Func<T, bool> predictate, Func<T, TKey> orderPredictate);

        void AddItem(T item);
        void RemoveItem(string itemId);
        void RemoveItems(Func<T, bool> predictate);

        void UsedOnlyForAOTCodeGeneration();
    }

    public interface IDataProviderGet<T> {

        T[] GetAll();

        T GetById(string id);

    }
}
