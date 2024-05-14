using MauiUI.AppConfigure;
using MauiUI.Models;

namespace MauiUI.Services
{
    public interface IUserContextService
    {
        Task<UserTable> GetUserAsync();
    }

    public class UserContextService : IUserContextService
    {
        //public static UserTable User { get;  }
        //private UserTable _user { get; set; }
        //public UserContextService() 
        //{

        //}

        public async Task<UserTable> GetUserAsync()
        {
            // get user from Sql Lite
            var userContext = (await SqlLiteAccess<UserTable>.GetAsync()).FirstOrDefault(); ;
            if(userContext == null)
            {
                throw new NullReferenceException("User information does not exist!!!");
            }
            return userContext;
        }
    }
}
