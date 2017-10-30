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
        SecureDAL s = new SecureDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Value;
            if (s.checkUser(username) == true)
            {
                string password = inputPassword.Value;
                string salt = s.retrieveSalt(username);
                string hash = s.getSHA(password + salt);
                if (s.userValidate(username, hash, salt) == true)
                {
                    int userID = s.getUID(username);
                    Response.Redirect("ChangePassword.aspx?userID=" + userID + "&username=" + username);
                }
                else
                {
                    ErrorMsg.Visible = true;
                }
            }
            else
                ErrorMsg.Visible = true;
        }
        
    }
}