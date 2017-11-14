using BussinessLogicLayer.Page.B.Courses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.B.Courses
{
    public partial class CoursesAdmin : System.Web.UI.Page
    {

        CoursesBLL BLL = new CoursesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //load dropdown
                loaddropdown();
                //load table
                loadtabledata();
              //  Label1.Text = DDLpublish.SelectedValue.ToString() + "  programID = " + DDLProgramme.SelectedValue.ToString();
            }
        }


        private void loaddropdown()
        {
            DDLProgramme.DataSource = BLL.getProgramList();
            DDLProgramme.DataValueField = "ProgramID";
            DDLProgramme.DataTextField = "ProgramName";
            DDLProgramme.DataBind();
        }
        private void loadtabledata()
        {
            int publishmode = int.Parse(DDLpublish.SelectedValue.ToString());
            int programID = int.Parse(DDLProgramme.SelectedValue.ToString());
            DataTable dt = BLL.getTableData(publishmode,programID);
            CoursesRPT.DataSource = dt;
            CoursesRPT.DataBind();
        }

        protected void DDLpublish_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Label1.Text = DDLpublish.SelectedValue.ToString() + "  programID = " + DDLProgramme.SelectedValue.ToString();
            loadtabledata();
        }

        protected void DDLProgramme_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Label1.Text = DDLpublish.SelectedValue.ToString() + "  programID = " + DDLProgramme.SelectedValue.ToString();
            loadtabledata();
        }

        protected void CoursesRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EditCourse")
            {
                Response.Redirect("EditCourses.aspx?CourseID=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Classes")
            {
                Response.Redirect("ClassAdmin.aspx?CourseID=" + e.CommandArgument.ToString());
            }
        }

       
    }
}