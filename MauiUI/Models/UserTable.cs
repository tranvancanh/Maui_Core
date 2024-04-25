namespace MauiUI.Models
{
    public class UserTable
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string HandyUserCode { get; set; }
        public string HandyUserName { get; set; }
        public int DepoID { get; set; }
        public string DepoCode { get; set; }
        public string DepoName { get; set; }
        public string AppVersion { get; set; }
        public int AdministratorFlag { get; set; }
        public string TokenString { get; set; }
    }
}
