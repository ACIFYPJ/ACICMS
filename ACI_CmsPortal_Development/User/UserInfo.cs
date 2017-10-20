using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACI_CmsPortal_Development.User
{
    public class UserInfo
    {
        private static int userID;
        private static string username;
        private static string displayname;
        private static string roles = "AuthenticatedUser;RecommendationAdmin;JobsAdmin;Administrator;ContentAdmin;";   //have to be loaded from DB, initializing is only for testing



        public int getUserID()
        {
            return userID;
        }
        public string getUsername()
        {
            return username;
        }
        public string getDisplayname()
        {
            return displayname;
        }
        public string getroles()
        {
            return roles;
        }
        public string[] getrolesArray()
        {
            var arr = roles.Split(new string[] { ";" }, StringSplitOptions.None);
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }

    }
}