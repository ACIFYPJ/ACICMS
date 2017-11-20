using DataAccessLayer.Page.I.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Page.I.Users
{
    public class UsersBLL
    {

        private int AddNewUser(string displayname, string username, string email, string password, int changepass,string createdBy,int profileID ,string salt, out string ex)
        {
            int result;
            UsersDAL addnewuser = new UsersDAL();
            result = addnewuser.AddNewUser(displayname, username, email, password, changepass,createdBy,profileID,salt, out ex);
            return result;
        }

        private int CreateUserProfile(string username, out string ex, out int profileID)
        {
            int result;
            UsersDAL adduserprofile = new UsersDAL();
            result = adduserprofile.AddNewUserProfile(username, out ex,out profileID);
            return result;
        }

        public int CheckUserNameExistBLL(string displayname, string username, string email, string hash, int changepass,string createdBy,string salt, out string ex)
        {
            UsersDAL checkuserexist = new UsersDAL();
            int UserExistResult = checkuserexist.CheckUserNameExistDAL(username);
            ex = "";
            if (UserExistResult > 0)
            {
               //user already exist                           
                return -10101010;
            }
            else
            {
                int profileID; // get the new profileID
                //user name available
                //create a userprofile first
                int CreateUserprofile = CreateUserProfile(username, out ex, out profileID);
                if (CreateUserprofile > 0)//profile created
                {              
                    //finally add new user
                    int result = AddNewUser(displayname, username, email, hash, changepass, createdBy, profileID,salt, out ex);
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        //user not created
                        return -10001111;
                    }
                }
                else
                {
                    //profile not created
                    return -11001100;
                }             
            }         
        }


        public int updateuserinfo(string currentusername, string username, string hash, string displayname, string email, int changepass, int displaymemberlist, string firstname, string lastname, Nullable<DateTime> DOB, char gender, string jobtitle, int userID, out string ex)
        {
            UsersDAL updateinfo = new UsersDAL();           
            ex = "";        
            if (currentusername == username)
            {
                int result = updateinfo.UpdateUserInfo(username, hash, displayname, email, changepass, displaymemberlist, firstname, lastname, DOB, gender, jobtitle, userID, out ex);
                return result;              
            }
            else
            {
                int UserExistResult = updateinfo.CheckUserNameExistDAL(username);
                if (UserExistResult > 0)
                {
                    //user already exist                           
                    return -10101010;
                }
                else
                {
                    int result = updateinfo.UpdateUserInfo(username, hash, displayname, email, changepass, displaymemberlist, firstname, lastname, DOB, gender, jobtitle, userID, out ex);
                    return result;
                }             
            }
                       
        }


        public string[] getrolesArray(int userID)
        {
            UsersDAL getroles = new UsersDAL();
            string roles = getroles.getuserroles(userID);
            if (roles == "")
            {
                string[] arr = new string[]{};
                return arr;
            }
            else
            {
                string[] arr = roles.Split(new string[] { "," }, StringSplitOptions.None);
                //Array.Resize(ref arr, arr.Length - 1);
                return arr;
            }
            
        }

    }
}
