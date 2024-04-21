namespace MauiUI.Services
{
    public interface IAppSettingService
    {
        Task<int> RegisterSettingData();
        Task<bool> ConnectingUrlServer();
    }

    public class AppSettingService : IAppSettingService
    {
        public async Task<bool> ConnectingUrlServer()
        {
            await Task.CompletedTask;
            return true;
        }

        public async Task<int> RegisterSettingData()
        {
            await Task.CompletedTask;
            return 1;
        }
    }
}
