using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLayer.Page.K.Secure
{
    public class SecureDAL
    {
        string constr = Properties.Settings.Default.DBConnect;
        public bool checkUser(string username)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM cms_user WHERE username like @username", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    int i = (int)cmd.ExecuteScalar();
                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
            }
        }
        public bool userValidate(string username, string hash, string salt)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM cms_user WHERE username = @username AND password = @password AND salt = @salt", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hash);
                    cmd.Parameters.AddWithValue("@salt", salt);
                    cmd.Connection = con;
                    cmd.Connection.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
        }
        public bool checkPass(string hash)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM cms_user WHERE password = @hash", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@hash", hash);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public string retrieveSalt(string username)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT salt FROM cms_user WHERE username = @username", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    string salt = (string)cmd.ExecuteScalar();
                    return salt;
                }


            }
        }
        public int getUID(string username)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT userID FROM cms_user WHERE username = @username", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    int uid = (int)cmd.ExecuteScalar();
                    return uid;
                }
            }
        }
        public void resetPassword(int userID, string salt, string hash)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE cms_user SET password= @hash, salt = @salt WHERE userID = @userID", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("salt", salt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string getSHA(string text)
        {
            byte[] b = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(b);
            string String = string.Empty;
            foreach (byte x in hash)
            {
                String += String.Format("{0:x2}", x);
            }
            return String;
        }
        public string generateSalt()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[10];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
        
        
    }
}
