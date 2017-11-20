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
    public partial class ClassAdmin : System.Web.UI.Page
    {
        CoursesBLL BLL = new CoursesBLL();
        private static int CourseID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CourseID = int.Parse(Request.QueryString["CourseID"].ToString());
                loadRPT();
            }
        }

        private void loadRPT()
        {
            DataTable dt1, dt2;
            dt1 = BLL.getClasses(CourseID, 1);
            dt2 = BLL.getClasses(CourseID, 2);

           ClassPublishRPT.DataSource = dt1;
                ClassPublishRPT.DataBind();
                
           
                
                
                ClassUnPublishRPT.DataSource = dt2;
                ClassUnPublishRPT.DataBind();
            
           
        }

        protected void ClassPublishRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditClass.aspx?ClassID=" + e.CommandArgument +"&CourseID=" + CourseID);
            }         
        }

        protected void ClassUnPublishRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditClass.aspx?ClassID=" + e.CommandArgument + "&CourseID=" + CourseID);
            }
        }
    }
}