
using DataAccessLayer.Page.I.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.I.Users
{
    public partial class UsersAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindtabledata();               
            }
        }

        private void bindtabledata()
        {
            lblheading.Text = "Manage Admin Users";
            UsersDAL DAL = new UsersDAL();
            //Populating a DataTable from database.
            DataTable dt = DAL.GetUsersData();
            UsersRPT.DataSource = dt;
            UsersRPT.DataBind();
        }

        protected void UsersRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ViewID = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "ViewUser")
            {             
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                PopulateModal(ViewID);
            }
            else if(e.CommandName == "ManageUser")
            {
                var btnSender = (Button)e.CommandSource;
                string riderName = btnSender.Attributes["data-rider-name"];
                Response.Redirect("ManageUser.aspx?UserID=" + ViewID );
            }
        }
        private void PopulateModal(int UserID)
        {
            UsersDAL UsersModal = new UsersDAL();
            DataTable dt = UsersModal.GetSpecificUserData(UserID);
            foreach (DataRow dtRow in dt.Rows)
            {
                lbVCreatedBy.Text = dtRow["createdBy"].ToString();
                lbVCreatedOn.Text = dtRow["createdOn"].ToString();
                lbVDisplayname.Text = dtRow["displayname"].ToString();
                lbVusername.Text = dtRow["username"].ToString();
                lbVEmail.Text = dtRow["email"].ToString();
                lbVroles.Text = dtRow["roles"].ToString();
                lbVFirstName.Text = dtRow["firstname"].ToString();
                lbVLastName.Text = dtRow["lastname"].ToString();
                string gender = dtRow["gender"].ToString();
                if (gender == "M")
                {
                    gender = "Male";
                }
                else if (gender == "F")
                {
                    gender = "Female";
                }
                lbVGender.Text = gender;
                lbVJobTitle.Text = dtRow["jobtitle"].ToString();                             
            }
        }

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

        protected void BtnLockedUser_Click(object sender, EventArgs e)
        {
            lblheading.Text = "Manage Admin Users (Locked Users)";        
            BtnLockedUser.Visible = false;
            BtnAllUser.Visible = true;
            UsersDAL DAL = new UsersDAL();
            //Populating a DataTable from database.
            DataTable dt = DAL.GetLockedUserData();
            UsersRPT.DataSource = dt;
            UsersRPT.DataBind();
        }

        protected void BtnAllUser_Click(object sender, EventArgs e)
        {     
            BtnLockedUser.Visible = true;
            BtnAllUser.Visible = false;
            bindtabledata();
        }
    }
}