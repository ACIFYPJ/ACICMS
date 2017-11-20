using BussinessLogicLayer.Page.B.Courses;
using DataAccessLayer.Page.B.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.B.Courses
{
    public partial class EditCourses : System.Web.UI.Page
    {
        CoursesBLL BLL = new CoursesBLL();
        CoursesDAL DAL = new CoursesDAL();
        private static int CourseID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //load dropdown
                loaddropdown();
                //get query
                CourseID = int.Parse(Request.QueryString["CourseID"]);
                loadCKdatas(CourseID);
                loadmodules();
            }
        }

        private void loaddropdown()
        {
            DDLProgramme.DataSource = BLL.getProgramListForEditpage();
            DDLProgramme.DataValueField = "ProgramID";
            DDLProgramme.DataTextField = "ProgramName";
            DDLProgramme.DataBind();
        }
        private void loadCKdatas(int CourseID)
        {
            int PublishedBefore = -1;
            double Coursefees;
            string PublishStatus, ProgramID, CourseFeesText;
            string description, targetaudience, refundpolicy, entryrequirements, otherinfo, CourseName;
            BLL.getCKdata(CourseID, out PublishStatus, out ProgramID, out description, out targetaudience, out refundpolicy, out entryrequirements, out otherinfo, out CourseName, out Coursefees, out CourseFeesText, out PublishedBefore);

            lblheading.Text = " : " + CourseName;
            CKEditorDescription.Text = description;
            CKEditorEntryRequirements.Text = entryrequirements;
            CKEditorOtherInfo.Text = otherinfo;
            CKEditorRefundPolicy.Text = refundpolicy;
            CKEditorTargetAudience.Text = targetaudience;
            DDLProgramme.SelectedValue = ProgramID;
            DDLpublish.SelectedValue = PublishStatus;
            lblcoursefee.Text = "$" + Coursefees.ToString();
            CKEditorCourseFees.Text = CourseFeesText;

            if (PublishedBefore == 1)
            {
                lblpublishbefore1.Text = "Course published to public before: Yes";
                CKEditorCourseFees.Enabled = false;
                CKEditorRefundPolicy.Enabled = false;
                CKEditorEntryRequirements.Enabled = false;
            }
            else
            {
                lblpublishbefore1.Text = "Course published to public before: No";
                CKEditorCourseFees.Enabled = true;
                CKEditorRefundPolicy.Enabled = true;
                CKEditorEntryRequirements.Enabled = true;
            }
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {

            UpdateDataBase(int.Parse(DDLProgramme.SelectedValue.ToString()), int.Parse(DDLpublish.SelectedValue.ToString()), CKEditorDescription.Text, CKEditorTargetAudience.Text, CKEditorEntryRequirements.Text, CKEditorOtherInfo.Text, CKEditorRefundPolicy.Text, CKEditorCourseFees.Text);
        }

        private void UpdateDataBase(int ProgramID, int PublishMode, string Overview, string TargetAudience, string EntryRequirements, string OtherInfo, string RefundPolicy, string CourseFeesText)
        {
            int result = BLL.UpdateCourse(CourseID, ProgramID, PublishMode, Overview, TargetAudience, EntryRequirements, OtherInfo, RefundPolicy, CourseFeesText);
            if (result > 0)
            {
                //success
                //lblheading.Text = "SUCCESS";
                loadCKdatas(CourseID);
            }
            else
            {
                //fail
                //lblheading.Text = "FAIL";
                loadCKdatas(CourseID);
            }
        }


        protected void BtnArchive_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoursesAdmin.aspx");
        }

        protected void BtnDraft_Click(object sender, EventArgs e)
        {
            loadCKdatas(CourseID);
        }

        private void loadmodules()
        {
            string[] dtcore = BLL.getCoreArray(CourseID);
            string[] dtelective = BLL.getElectiveArray(CourseID);
            CoreModuleRPT.DataSource = dtcore;
            ElectiveRPT.DataSource = dtelective;
            CoreModuleRPT.DataBind();
            ElectiveRPT.DataBind();
        }

        protected void CoreModuleRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string moduleChange = "";
            if (e.CommandName == "ChangeToElective")
            {             
                moduleChange = e.CommandArgument.ToString();
                string[] dtcore = BLL.getCoreArray(CourseID);
                string[] dtelective = BLL.getElectiveArray(CourseID);
                var list = new List<string>(dtcore);
                list.Remove(moduleChange);
                dtcore = list.ToArray();

                string dtcoreString = String.Join(";", dtcore);
                string dtelectiveString = String.Join(";", dtelective);

                if (dtelectiveString == "")
                {
                    dtelectiveString = moduleChange;
                }
                else
                {
                    dtelectiveString = dtelectiveString + ";" + moduleChange;
                }
                

                //update core module to db
                DAL.updateCoreModule(CourseID, dtcoreString);
                //update elective module to db
                DAL.updateElectiveModule(CourseID, dtelectiveString);
                loadmodules();
            }
            


        }

        protected void ElectiveRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string moduleChange = "";
            if (e.CommandName == "ChangeToCore")
            {
                
                moduleChange = e.CommandArgument.ToString();
                string[] dtcore = BLL.getCoreArray(CourseID);
                string[] dtelective = BLL.getElectiveArray(CourseID);
                var list = new List<string>(dtelective);
                list.Remove(moduleChange);
                dtelective = list.ToArray();

                string dtcoreString = String.Join(";", dtcore);
                string dtelectiveString = String.Join(";", dtelective);

                if (dtcoreString == "")
                {
                    dtcoreString = moduleChange;
                }
                else
                {
                    dtcoreString = dtcoreString + ";" + moduleChange;
                }


                //update core module to db
                DAL.updateCoreModule(CourseID, dtcoreString);
                //update elective module to db
                DAL.updateElectiveModule(CourseID, dtelectiveString);
                loadmodules();
            }
        }

        protected void CoreModuleRPT_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            //ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            //Button btn = e.Item.FindControl("BtnChangeToElective") as Button;
            //if (btn != null)
            //{
            //    btn.Click += Btn_Click;
            //    scriptMan.RegisterAsyncPostBackControl(btn);
            //}
        }

        //protected void Btn_Click(object sender, EventArgs e)
        //{
        //    Label2.Text = "asdasd";
        //}
    }
}