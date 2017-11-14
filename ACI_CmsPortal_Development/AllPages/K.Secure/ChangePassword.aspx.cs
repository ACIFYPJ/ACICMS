using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.Page.K.Secure;

namespace ACI_CmsPortal_Development.AllPages.K.Secure
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        SecureDAL s = new SecureDAL();
        int uid;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                uid = Int32.Parse(Session["uid"].ToString());
                username = Session["username"].ToString();
            }
            catch (NullReferenceException nre)
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (s.checkPass(s.getSHA(oldPass.Value.ToString() + s.retrieveSalt(username))) == true)
                {
                    string salt = s.generateSalt();
                    string hash = s.getSHA(confirmPass.Value + salt);
                    s.resetPassword(uid, salt, hash);
                }
                else
                {
                    oldpasserror.Visible = true;
                }



            }

        }
    }
}