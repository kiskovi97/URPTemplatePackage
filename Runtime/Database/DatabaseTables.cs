using System;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    public class DatabaseTables
    {
        #region Tables

        private static DatabaseTable<MaxScores> mScoreTable = new DatabaseTable<MaxScores>("TableUIText");
        private static AppSettingsDatabase mAppSettingsDatabase = new AppSettingsDatabase();

        public static IDataProvider<MaxScores> scoreTable => mScoreTable;
        
        public static IAppSettingsDatabase settingsDatabase => mAppSettingsDatabase;

        private static IDatabaseTable[] localTables => new IDatabaseTable[]
            {
                mScoreTable,
                mAppSettingsDatabase
            };

        #endregion

        #region Public methods

        public static void Initialize()
        {
            foreach (var database in localTables)
            {
                database.LoadFromDisk();
            }
        }

        public static void SaveToDisk()
        {
            foreach (var database in localTables)
            {
                database.SaveToDisk();
            }
        }

        #endregion

    }
}
