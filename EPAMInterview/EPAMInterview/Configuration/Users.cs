using System.Configuration;

namespace EPAMInterview.Configuration
{
    public static class Users
    {
        public static string CustomerLogin => ConfigurationManager.AppSettings["customerLogin"];

        public static string CustomerPassword => ConfigurationManager.AppSettings["customerPassword"];
    }
}
