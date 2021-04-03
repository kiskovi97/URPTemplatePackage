
using System;

namespace URPTemplate.Model
{
    public class SavableItem : IComparable
    {
        public string id;

        public virtual int CompareTo(object obj)
        {
            if (obj is SavableItem item)
                return id == item.id ? 0 : -1;
            return -1;
        }
    }
}
