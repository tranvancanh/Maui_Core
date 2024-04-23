namespace MauiUI.Models
{
    public class SettingTable
    {
        public string HandyApiUrl { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPassword { get; set; }

        public int HandyUserId { get; set; }
        public string HandyUserCode { get; set; }
        public string HandyUserName { get; set; }

        public string DeviceId { get; set; }
        public string DeviceName { get; set; }

        public string ScanMode { get; set; }
        public string ScanOkeySound { get; set; }
        public string ScanErrorSound { get; set; }

    }
}
