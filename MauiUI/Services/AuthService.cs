namespace MauiUI.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticateAsync();
    }

    public class AuthService : IAuthService
    {
        public async Task<bool> IsAuthenticateAsync()
        {
            await Task.Delay(1000);
            return true;
        }
    }
}
