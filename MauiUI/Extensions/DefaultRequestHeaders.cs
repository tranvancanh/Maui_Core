using MauiUI.AppConfigure;
using MauiUI.Models;
using System.Net.Http.Headers;

namespace MauiUI.Extensions
{
    public static class RequestHeaderExtensions
    {
        public static void AddRequestHeaders(this HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var userInfor = GetuserInfor();
            if(userInfor != null)
            {
                httpClient.DefaultRequestHeaders.Add("CompanyId", userInfor.CompanyId);
                httpClient.DefaultRequestHeaders.Add("CompanyCode", userInfor.CompanyCode);
                httpClient.DefaultRequestHeaders.Add("CompanyName", userInfor.CompanyName);
                httpClient.DefaultRequestHeaders.Add("HandyUserCode", userInfor.HandyUserCode);
                httpClient.DefaultRequestHeaders.Add("HandyUserName", userInfor.HandyUserName);
                httpClient.DefaultRequestHeaders.Add("DepoID", userInfor.DepoID);
                httpClient.DefaultRequestHeaders.Add("DepoCode", userInfor.DepoCode);
                httpClient.DefaultRequestHeaders.Add("DepoName", userInfor.DepoName);
                httpClient.DefaultRequestHeaders.Add("AdministratorFlag", userInfor.AdministratorFlag);
                httpClient.DefaultRequestHeaders.Add("HandyUserCode", userInfor.HandyUserCode);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userInfor.TokenString);
            }
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        }


        private static dynamic GetuserInfor()
        {
            var settingTable = (SqlLiteAccess<SettingTable>.GetAsync().GetAwaiter().GetResult()).ToList();
            var userTable = (SqlLiteAccess<UserTable>.GetAsync().GetAwaiter().GetResult()).ToList();
            dynamic resultQuery = (
            from s in settingTable
            join u in userTable
            on s.CompanyId equals u.CompanyId
            select new
            {
                CompanyId = s.CompanyId,
                CompanyCode = s.CompanyCode,
                CompanyName = s.CompanyName,
                HandyUserId = s.HandyUserId,
                HandyUserCode = s.HandyUserCode,
                HandyUserName = s.HandyUserName,
                DepoID = u.DepoID,
                DepoCode = u.DepoCode,
                DepoName = u.DepoName,
                AdministratorFlag = u.AdministratorFlag,
                TokenString = u.TokenString
            }).FirstOrDefault();

            return resultQuery;
    }
}
}
