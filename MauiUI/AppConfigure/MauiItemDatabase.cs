using MauiUI.Models;
using SQLite;

namespace MauiUI.AppConfigure
{
    public sealed class MauiItemDatabase
    {
        private readonly SQLiteAsyncConnection Database = null;

        private static readonly MauiItemDatabase dbInstance = new MauiItemDatabase();
        static MauiItemDatabase()
        {
        }
        private MauiItemDatabase()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(DatabaseConfigure.DatabasePath, DatabaseConfigure.Flags);
            var initDb = this.Init();
            initDb.RunSynchronously();
        }
        public static MauiItemDatabase DbInstance
        {
            get
            {
                return dbInstance;
            }
        }

        public async Task Init()
        {
            var result = await Database.CreateTableAsync<Employee>();
        }

        //public MauiItemDatabase()
        //{
        //    Database = new SQLiteAsyncConnection(DatabaseConfigure.DatabasePath, DatabaseConfigure.Flags);
        //    var initDb = this.Init();
        //    initDb.RunSynchronously();
        //}
    }
}
