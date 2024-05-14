using MauiUI.Models;

namespace MauiUI.Services
{
    public interface IUserContextService
    {
        Task<UserTable> GetUserAsync();
    }

    public class UserContextService : IUserContextService
    {
        public async Task<UserTable> GetUserAsync()
        {
            // get user from Sql Lite
            var user =  new UserTable();

            await Task.CompletedTask;
            return user;
        }
    }
}
