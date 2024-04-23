using Microsoft.Extensions.Configuration;
using SQLite;

namespace MauiUI.AppConfigure
{
    public class SqlLiteAccess<T> where T : new()
    {
        private static readonly SQLiteAsyncConnection _database = MauiItemDatabase.DbInstance;
       

        public static Task<List<T>> GetAsync()
        {
            return _database.Table<T>().ToListAsync();
        }

        public static Task<int> GetCountAsync()
        {
            return _database.Table<T>().CountAsync();
        }

        public static Task<int> InsertAsync(T model)
        {
            return _database.InsertAsync(model);
        }

        public static Task<int> UpdateAsync(T model)
        {
            return _database.UpdateAsync(model);
        }

        public static Task<int> DeleteAsync(T model)
        {
            return _database.DeleteAsync(model);
        }

        public static Task<int> DeleteAllAsync()
        {
            return _database.DeleteAllAsync<T>();
        }

    }
}
