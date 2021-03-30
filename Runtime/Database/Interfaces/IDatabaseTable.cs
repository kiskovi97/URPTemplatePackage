using System;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    public delegate void DatabaseStateChange();
    public delegate void DatabaseError(string errorMessage, ErrorCode errorCode);

    internal interface IDatabaseTable
    {
        void LoadFromDisk();

        void SaveToDisk();
    }

    internal interface IDatabaseManagable
    {
    }

    public enum TableState
    {
        Local, 
        Downloaded,
        ConnectionNeeded,
        LoadingOffline
    }
}
