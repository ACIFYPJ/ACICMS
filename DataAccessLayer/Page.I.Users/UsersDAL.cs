using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Page.I.Users
{
    public class UsersDAL
    {
        string constr = Properties.Settings.Default.DBConnect;

        public DataTable GetUsersData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT userID,username, displayname, email, changepass, lockedout, displaymemberlist, roles, createdBy, createdOn, profileID FROM cms_user  WHERE lockedout=0"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable GetLockedUserData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT userID,username, displayname, email, changepass, lockedout, displaymemberlist, roles, createdBy, createdOn, profileID FROM cms_user WHERE lockedout=1"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable GetSpecificUserData(int ID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  cms_user.displayname, cms_user.username,  cms_user.email,  cms_user.roles,  cms_user.createdBy,  cms_user.createdOn,cms_user.displaymemberlist, cms_user.changepass,  cms_user.profileID, cms_userprofile.firstname,  cms_userprofile.lastname,  cms_userprofile.gender,cms_userprofile.dateofbirth, cms_userprofile.jobtitle FROM cms_user  INNER JOIN cms_userprofile ON cms_user.profileID = cms_userprofile.profileID WHERE userID=@userID"))
                {
                    cmd.Parameters.AddWithValue("userID", ID);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public int AddNewUser(string displayname, string username, string email, string password, int changepass, string createdBy, int profileID, out string ex)
        {
            int result = 0;
            ex = "";
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO cms_user(username,password,displayname,email,changepass,createdBy,createdOn,profileID) VALUES (@username,@password,@displayname,@email,@changepass,@createdBy,@createdOn,@profileID)", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@displayname", displayname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@changepass", changepass);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", DateTime.Now);
                    cmd.Parameters.AddWithValue("@profileID", profileID);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    ex = e.Message.ToString();
                }
            }
            return result;
        }

        public int AddNewUserProfile(string username, out string ex, out int profileID)
        {
            int result = 0;
            ex = "";
            profileID = -1;

            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO cms_userprofile(username) VALUES (@username)", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    profileID = getuserprofileID(username);
                }
                catch (Exception e)
                {
                    ex = e.Message.ToString();
                }
            }
            return result;
        }
        private int getuserprofileID(string username)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string checkuser = "SELECT profileID from cms_userprofile where username=@username";
            SqlCommand cmd = new SqlCommand(checkuser, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            int ID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            myConnect.Close();
            return ID;
        }

        public int CheckUserNameExistDAL(string username)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string checkuser = "SELECT count(*) from cms_user where username=@username";
            SqlCommand cmd = new SqlCommand(checkuser, myConnect);
            cmd.Parameters.AddWithValue("@username", username);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            myConnect.Close();
            return temp;
        }




        public int UpdateUserInfo(string username, string password, string displayname, string email, int changepass, int displaymemberlist, string firstname, string lastname, Nullable<DateTime> DOB, char gender, string jobtitle, int userID, out string ex)
        {
            int result = 0;
            ex = "";

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("UPDATE cms_user SET cms_user.username=@username,  cms_user.password=@password, cms_user.displayname=@displayname, cms_user.email=@email, cms_user.changepass=@changepass, cms_user.displaymemberlist=@displayinmemberlist WHERE userID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@displayname", displayname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@changepass", changepass);
                    cmd.Parameters.AddWithValue("@displayinmemberlist", displaymemberlist);

                    result = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    ex = e.Message.ToString();
                    return result;
                }
                if (result > 0)
                {
                    //success 
                    //get profileID to update profile
                    int profileID;
                    SqlCommand cmd2 = new SqlCommand("SELECT profileID FROM cms_user WHERE userID=@userID", con);
                    cmd2.Parameters.AddWithValue("@userId", userID);
                    profileID = Convert.ToInt32(cmd2.ExecuteScalar().ToString());

                    SqlCommand cmd3 = new SqlCommand("UPDATE cms_userprofile SET username=@username, firstname=@firstname, lastname=@lastname, dateofbirth=@dateofbirth, gender=@gender,jobtitle=@jobtitle WHERE profileID=@profileID", con);
                    cmd3.Parameters.AddWithValue("@profileID", profileID);
                    cmd3.Parameters.AddWithValue("@username", username);
                    cmd3.Parameters.AddWithValue("@firstname", firstname);
                    cmd3.Parameters.AddWithValue("@lastname", lastname);
                    //cmd3.Parameters.AddWithValue("@dateofbirth", DOB);
                    cmd3.Parameters.AddWithValue("@gender", gender);
                    cmd3.Parameters.AddWithValue("@jobtitle", jobtitle);
                    SqlParameter d = cmd3.Parameters.AddWithValue("@dateofbirth", DOB);
                    if (DOB == null)
                    {
                        d.Value = DBNull.Value;
                    }
                    result = cmd3.ExecuteNonQuery();

                    return profileID;
                }
                else
                {
                    return 0; // failed
                }



            }
        }


        public string getuserroles(int userID)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string checkuser = "SELECT roles from cms_user where userID=@userID";
            SqlCommand cmd = new SqlCommand(checkuser, myConnect);
            cmd.Parameters.AddWithValue("@userID", userID);
            string returnroles = cmd.ExecuteScalar().ToString();
            myConnect.Close();
            return returnroles;
        }

        public int lockthisuser(int userID, int lockedindex, out string ex)
        {
            int result = 0;
            ex = "";

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE cms_user SET lockedout=@lockedout WHERE userID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@lockedout", lockedindex);
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception e)
                {
                    ex = e.ToString();
                    return 0;
                }
            }
        }
        public int checkuserlocked(int userID)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            int lockedout;
            SqlCommand cmd2 = new SqlCommand("SELECT lockedout FROM cms_user WHERE userID=@userID", myConnect);
            cmd2.Parameters.AddWithValue("@userId", userID);
            lockedout = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
            myConnect.Close();
            return lockedout;
        }

        public int updateroleDAL(int userID, string roles, out string ex)
        {
            int result;
            ex = "";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE cms_user SET roles=@roles WHERE userID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@roles", roles);
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception e)
                {
                    ex = e.ToString();
                    return 0;
                }
            }
        }

        public int getuserID(string username)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            int userID;
            SqlCommand cmd2 = new SqlCommand("SELECT userID FROM cms_user WHERE username=@username", myConnect);
            cmd2.Parameters.AddWithValue("@username", username);
            userID = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
            myConnect.Close();
            return userID;
        }

    }
}
