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
            await Task.CompletedTask;
            return true;
        }
    }
}
