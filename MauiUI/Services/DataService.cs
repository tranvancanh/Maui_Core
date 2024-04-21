namespace MauiUI.Services
{
    public interface IDataService
    {
        Task<bool> IsAuthenticateAsync();
    }

    public class DataService : IDataService
    {
        public async Task<bool> IsAuthenticateAsync()
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
