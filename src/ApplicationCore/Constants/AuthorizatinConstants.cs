using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Constants
{
    public class AuthorizatinConstants
    {
        public const string DEFAULT_DEMO_USER = "demouser@example.com";
        public const string DEFAULT_ADMIN_USER = "admin@example.com";
        public const string DEFAULT_PASSWORD = "P@ssword1";

        public static class Roles
        {
            public const string ADMINISTRATOR = "Admin";
        }
    }
}
