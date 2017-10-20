using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Security.Cryptography;
using DataAccessLayer.Page.E.Events;
using DataAccessLayer.Page.K.Secure;

namespace ACI_CmsPortal_Development.AllPages.K.Secure
{
    public partial class Login : System.Web.UI.Page
    {
        EventsDAL dl = new EventsDAL();
        protected void Page_Load(object sender, EventArgs e)
        {       
            

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Value;
            if (dl.checkUser(username) == true)
            {


                string password = inputPassword.Value;
                string salt = dl.retrieveSalt(username);
                string hash = getSHA(password + salt);
                if (dl.userValidate(username, hash, salt) == true)
                {
                    Response.Redirect("ResetPassword.aspx");
                }
                else
                {
                    
                    ErrorMsg.Visible = true;

                }
            }
            else
                ErrorMsg.Visible = true;
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
    }
}