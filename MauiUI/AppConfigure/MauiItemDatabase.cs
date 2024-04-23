using MauiUI.Models;
using SQLite;

namespace MauiUI.AppConfigure
{
    public sealed class MauiItemDatabase
    {
        private static readonly SQLiteAsyncConnection database = new SQLiteAsyncConnection(DatabaseConfigure.DatabasePath, DatabaseConfigure.Flags);

        private static readonly MauiItemDatabase itemDatabase = new MauiItemDatabase();
        static MauiItemDatabase()
        {
        }
        private MauiItemDatabase()
        {
            var initDb = this.Init();
            initDb.RunSynchronously();
        }
        public static MauiItemDatabase ItemDatabase
        {
            get
            {
                return itemDatabase;
            }
        }

        public static SQLiteAsyncConnection DbInstance
        {
            get
            {
                return database;
            }
        }

        public async Task Init()
        {
            var resultEmployee = await database.CreateTableAsync<Employee>();
            var resultUserTable = await database.CreateTableAsync<UserTable>();
            var resultSettingTable = await database.CreateTableAsync<SettingTable>();
        }

        //public MauiItemDatabase()
        //{
        //    Database = new SQLiteAsyncConnection(DatabaseConfigure.DatabasePath, DatabaseConfigure.Flags);
        //    var initDb = this.Init();
        //    initDb.RunSynchronously();
        //}
    }
}
