using BussinessLogicLayer.Page.I.Users;
using DataAccessLayer.Page.I.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.I.Users
{
    public partial class AddUser : System.Web.UI.Page
    {
        string createdBy;
        protected void Page_Load(object sender, EventArgs e)
        {

            createdBy = Session["username"].ToString();
        }
        protected void LinkBtnDisplayname_Click(object sender, EventArgs e)
        {
            lbVhelpguide.Text = "Display name is a screen name that will appear around your personal web portal";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        protected void LinkBtnUsername_Click(object sender, EventArgs e)
        {
            lbVhelpguide.Text = "blah";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        protected void LinkBtnEmail_Click(object sender, EventArgs e)
        {
            lbVhelpguide.Text = "blah";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        protected void LinkBtnPassword_Click(object sender, EventArgs e)
        {
            lbVhelpguide.Text = "blah";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        protected void LinkBtnUserChangePw_Click(object sender, EventArgs e)
        {
            lbVhelpguide.Text = "blah";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        private void SendFormValue()
        {
            string displayname;
            string username;
            string email;
            string password;
            int changepass;
            string salt = generateSalt();
            string hash;

            displayname = tbdisplayname.Text;
            username = tbusername.Text;
            email = tbemail.Text;
            password = tbpassword.Text;
            hash = getSHA(password + salt);
            

            if (chkchangepassword.Checked)
            {
                changepass = 1;
            }
            else
            {
                changepass = 0;
            }

            //send values to BLL
            SendValueToBLL(displayname, username,email,hash,changepass,createdBy, salt);
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

        private void SendValueToBLL(string displayname, string username, string email, string hash, int changepass, string createdBy,string salt)
        {
            string ex;
            UsersBLL newuser = new UsersBLL();
            int result = newuser.CheckUserNameExistBLL(displayname, username, email, hash, changepass, createdBy,salt, out ex);
           
            if (result == -10101010)
            {
                //user already exist
                tbusername.Focus();
                lbusername.Visible = true;
            }
            else if (result == -10001111 || result == -11110000)
            {
                //failed
                lblerror.Text += "Error" + " : " + ex.ToString();
            }
            else if(result > 0)
            {
                //success
                //get new userID
                UsersDAL getID = new UsersDAL();
                int userID = getID.getuserID(username);

                Response.Redirect("ManageUser.aspx?UserID=" + userID);
            }
            else
            {
                //failed
                lblerror.Text += "Error" + " : " + ex.ToString();
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            
            SendFormValue();
        }
    }
}