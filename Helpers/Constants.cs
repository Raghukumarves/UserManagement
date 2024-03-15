using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UserManagement.Helpers
{
    public class Constants
    {
        public static string BaseAPI = ConfigurationManager.AppSettings["BaseAPI"].ToString();
        public static string GetUserAPI = "/api/v1/user?username={0}";
        public static string AddUserAPI = "/api/v1/user";
        public static string FipsUnlockAPI = "/api/v1/case/fips/unlock";
        public static string MileageAPI = "/reports/mileage";
        public static string GetCaseAPI = "/api/v1/case/event?esr=";
        public static string ReplayAPI = "/api/v1/case/event/replay";
    }
}