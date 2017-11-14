using ACI_CmsPortal_Development.User;
using BussinessLogicLayer.Page.I.Users;
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
    public partial class ManageUser : System.Web.UI.Page
    {
        static int userID;
        static string currentusername;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                userID = int.Parse(Request.QueryString["UserID"]);
                checkuseriflocked();
                bindrolesDDL();
                filterrolesDDL();
                bindRPTUserRole();
                bindformfield();
            }
        }
        private void checkuseriflocked()
        {
            UsersDAL checkuserlocked = new UsersDAL();
            int result = checkuserlocked.checkuserlocked(userID);
            if (result == 1)
            {
                setpagetolockeduser();
            }
            else
            {
                setpagetonormaluser();
            }
        }
        private void setpagetolockeduser()
        {
            lblheading.Text = "Manage locked user";
            Btnlock.Visible = false;
            Btnlock.Enabled = false;
            BtnUnlock.Visible = true;
            BtnUnlock.Enabled = true;
        }
        private void setpagetonormaluser()
        {
            lblheading.Text = "Manage user";
            Btnlock.Visible = true;
            Btnlock.Enabled = true;
            BtnUnlock.Visible = false;
            BtnUnlock.Enabled = false;
        }

        private void bindformfield()
        {
            int changepass = -1, displaymemberlist = -1;
            UsersDAL binduserformfield = new UsersDAL();
            DataTable userinfo = binduserformfield.GetSpecificUserData(userID);

            foreach (DataRow row in userinfo.Rows)
            {
                tbdisplayname.Text = row["displayname"].ToString();
                tbusername.Text = row["username"].ToString();
                currentusername = row["username"].ToString();
                //textboxusername = row["username"].ToString();

                tbemail.Text = row["email"].ToString();
                tbfirstname.Text = row["firstname"].ToString();
                tblastname.Text = row["lastname"].ToString();
                ddlgender.SelectedValue = row["gender"].ToString();
                tbJobtitle.Text = row["jobtitle"].ToString();
                //tbfirstname.Text = row["dateofbirth"].ToString();
                try
                {
                    DateTime dob = DateTime.Parse(row["dateofbirth"].ToString());
                    this.tbdob.Text = dob.ToString("yyyy-MM-dd");
                }
                catch
                {

                }
                changepass = int.Parse(row["changepass"].ToString());
                displaymemberlist = int.Parse(row["displaymemberlist"].ToString());
            }

            //if (tbusername.Text == currentusername)
            //{
            //    Label1.Text = tbusername.Text + currentusername + "SAME";
            //}
            //else
            //{
            //    Label1.Text = tbusername.Text + currentusername + "NOT SAME";
            //}

            if (changepass == 0)
            {
                chkchangepassword.Checked = false;
            }
            else
            {
                chkchangepassword.Checked = true;
            }
            if (displaymemberlist == 0)
            {
                chkdisplaymemberlist.Checked = false;
            }
            else
            {
                chkdisplaymemberlist.Checked = true;
            }
        }

        private List<Roles> Users()
        {
            return new List<Roles> {
            new Roles{RoleValue="Administrator", RoleName="Administrator"}
            ,new Roles{RoleValue="ContentAdmin",RoleName="Content Admin"}
            ,new Roles{RoleValue="ProgramAdmin",RoleName="Program Admin"}
            ,new Roles{RoleValue="CoursesAdmin",RoleName="Courses Admin"}
            ,new Roles{RoleValue="JobsAdmin",RoleName="Jobs Admin"}
            ,new Roles{RoleValue="PhotoAdmin",RoleName="Photo Admin"}
            ,new Roles{RoleValue="EventsAdmin",RoleName="Events Admin"}
            ,new Roles{RoleValue="HomePageAdmin",RoleName="Home Page Admin"}
            ,new Roles{RoleValue="RecommendationAdmin",RoleName="Recommendation Admin"}
            ,new Roles{RoleValue="NotificationAdmin",RoleName="Notification Admin"}
            ,new Roles{RoleValue="RolesAdmin",RoleName="Roles Admin"}
            ,new Roles{RoleValue="AuthenticatedUser",RoleName="Authenticated User"}
            };
        }

        private void bindrolesDDL()
        {
            ddlroles.DataSource = Users().ToList();
            ddlroles.DataValueField = "RoleValue";
            ddlroles.DataTextField = "RoleName";
            ddlroles.DataBind();
        }

        private void filterrolesDDL()
        { 
            UsersBLL userroles = new UsersBLL();
            string[] Roles = userroles.getrolesArray(userID);
            for (int i = 0; i < Roles.Length; i++)
            {
                ListItem itemToRemove = ddlroles.Items.FindByValue(Roles[i]);
                if (itemToRemove != null)
                {
                    ddlroles.Items.Remove(itemToRemove);
                }
            }
        }

        private void bindRPTUserRole()
        {
            UsersBLL userroles = new UsersBLL();
            string[] Roles = userroles.getrolesArray(userID);
            UserRolesRPT.DataSource = Roles;
            UserRolesRPT.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //form tab 1
            string displayname;
            string username;
            string email;
            string password;
            int changepass;
            int displaymemberlist;
            displayname = tbdisplayname.Text;
            username = tbusername.Text;
            email = tbemail.Text;
            password = tbpassword.Text;

            if (chkchangepassword.Checked)
            {
                changepass = 1;
            }
            else
            {
                changepass = 0;
            }

            if (chkdisplaymemberlist.Checked)
            {
                displaymemberlist = 1;
            }
            else
            {
                displaymemberlist = 0;
            }


            //form tab 2
            string firstname, lastname, jobtitle;
            Nullable<DateTime> DOB = null;
            char gender;
            if (tbfirstname.Text != "")
            {
                firstname = tbfirstname.Text;
            }
            else
            {
                firstname = "";
            }
            if (tblastname.Text != "")
            {
                lastname = tblastname.Text;
            }
            else
            {
                lastname = "";
            }
            if (tbJobtitle.Text != "")
            {
                jobtitle = tbJobtitle.Text;
            }
            else
            {
                jobtitle = "";
            }
            if (ddlgender.SelectedValue != "")
            {
                gender = char.Parse(ddlgender.SelectedValue.ToString());
            }
            else
            {
                gender = '\0';
            }
            if (tbdob.Text != "")
            {
                DOB = DateTime.Parse(tbdob.Text);
            }
            else
            {
                DOB = null;
            }

            string ex;

            UsersBLL updateinfo = new UsersBLL();
            int result = updateinfo.updateuserinfo(currentusername, username, password, displayname, email, changepass, displaymemberlist, firstname, lastname, DOB, gender, jobtitle, userID, out ex);
            if (result == -10101010)
            {
                //username exist
            }
            else if (result > 0)
            {
                // success
                //lblheading.Text = "success" + result.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                lbVsuccessmessage.Text = "Update success!";

            }
            else
            {
                //failed
                // lblheading.Text = "Failed" + ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                lbVmodalheaderfail.Text = "Update Failed";
                lbVmodalfailcontent.Text = "Update failed, please try again" + ex;
            }

            //lblheading.Text = DOB.ToString();
        }

        protected void Btnlock_Click(object sender, EventArgs e)
        {
            setpagetolockeduser();

            string ex;
            UsersDAL lockuser = new UsersDAL();
            int result = lockuser.lockthisuser(userID, 1, out ex);
            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                lbVmodalheaderfail.Text = "User Locked";
                lbVmodalfailcontent.Text = "User has been locked";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                lbVmodalheaderfail.Text = "Lock user failed";
                lbVmodalfailcontent.Text = "lock failed, please try again" + ex;
            }

        }

        protected void BtnUnlock_Click(object sender, EventArgs e)
        {
            setpagetonormaluser();

            string ex;
            UsersDAL unlockuser = new UsersDAL();
            int result = unlockuser.lockthisuser(userID, 0, out ex);
            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                lbVsuccessmessage.Text = "User has been unlock!";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                lbVmodalheaderfail.Text = "Unlocking user failed";
                lbVmodalfailcontent.Text = "Unlocking failed, please try again" + ex;
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersAdmin.aspx");
        }

        protected void BtnAddRole_Click(object sender, EventArgs e)
        {
            if (ddlroles.SelectedValue != "")
            {
                //take value from ddl
                string newrole = ddlroles.SelectedValue;
                //get current roles from DB and combine string
                UsersBLL getcurrentroles = new UsersBLL();
                string[] arr = getcurrentroles.getrolesArray(userID);

                string roles;
                if (arr.Length == 0)
                {
                    //label1.Text = "null array";
                    roles = newrole;
                }
                else
                {
                    //change role array to string for combine
                    roles = String.Join(",", arr);
                    //combined string
                    roles = roles + "," + newrole;
                }

                //store combined string into DB //add to DB
                UsersDAL updaterole = new UsersDAL();
                string ex;
                int result = updaterole.updateroleDAL(userID, roles, out ex);

                if (result > 0)//success
                {
                    bindrolesDDL();
                    filterrolesDDL();
                    bindRPTUserRole();
                }
                else //failed
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                    lbVmodalheaderfail.Text = "Add Role Failed";
                    lbVmodalfailcontent.Text = "Add Role Failed, please try again " + ex.ToString();
                }
            }
        }

        protected void UserRolesRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRole")
            {
                //get current array of roles
                UsersBLL getcurrentroles = new UsersBLL();
                string[] arr = getcurrentroles.getrolesArray(userID);


                //remove the selected role in the array
                arr = arr.Where(val => val != e.CommandArgument.ToString()).ToArray();




                //if arr length is left with 1, set roles to empty;
                string roles;
                if (arr.Length < 1)
                {
                    // label1.Text = "empty";
                    roles = "";
                }
                else//convert the array back to a string with seperator
                {
                    //label1.Text = "";
                    roles = String.Join(",", arr);
                }

                //store the new combine string into database
                //add to DB
                string ex;
                UsersDAL updaterole = new UsersDAL();
                int result = updaterole.updateroleDAL(userID, roles, out ex);

                if (result > 0)//success
                {

                    //reload all the table
                    //label1.Text = roles;
                    bindrolesDDL();
                    filterrolesDDL();
                    bindRPTUserRole();
                }
                else //failed
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
                    lbVmodalheaderfail.Text = "Delete Role Failed";
                    lbVmodalfailcontent.Text = "Delete Role Failed, please try again " + ex.ToString();
                }



            }
        }
    }
}