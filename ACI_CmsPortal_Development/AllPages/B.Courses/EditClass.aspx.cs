using BussinessLogicLayer.Page.B.Courses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.B.Courses
{
    public partial class EditClass : System.Web.UI.Page
    {
        CoursesBLL BLL = new CoursesBLL();
        private static int ClassID = -1;
        private static int CourseID = -1;
        bool registrationstrat = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ClassID = int.Parse(Request.QueryString["ClassID"].ToString());
                CourseID = int.Parse(Request.QueryString["CourseID"].ToString());
                loadtextbox();
            }
        }
        private void loadtextbox()
        {
            DataTable dt = BLL.getClassDetails(ClassID);

            foreach (DataRow row in dt.Rows)
            {
                DateTime regstart = DateTime.Parse(row["RegStartDate"].ToString());
                DateTime regend = DateTime.Parse(row["RegEndDate"].ToString());
                string regperiod = regstart.ToString("dd MMMM yyyy") + " To " + regend.ToString("dd MMMM yyyy");
                txtRegPeriod.Text = regperiod;
                txtendtime.Text = row["ClassEndTime"].ToString();
                txtstarttime.Text = row["ClassStartTime"].ToString();
                txtLanguage.Text = row["Language"].ToString();
                txtremarks.Text = row["Remarks"].ToString();
                lblHeading.Text = ": " + row["ClassCode"].ToString();
               registrationstrat= checkifregstarts(regstart);
            }

        }
        private bool checkifregstarts(DateTime regstart)
        {
            if (regstart < DateTime.Today)
            {
                txtendtime.Enabled = false;
                txtstarttime.Enabled = false;
                txtLanguage.Enabled = false;
                return true;
            }
            else
            {
                txtendtime.Enabled = true;
                txtstarttime.Enabled = true;
                txtLanguage.Enabled = true;
                return false;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (checktimevalid() == true)
            {
                string EndTime = "", StartTime = "", Language = "", Remarks = "";

                if (txtstarttime.Text != "")
                {
                    StartTime = txtstarttime.Text;
                }
                if (txtendtime.Text != "")
                {
                    EndTime = txtendtime.Text;
                }
                if (txtLanguage.Text != "")
                {
                    Language = txtLanguage.Text;
                }
                if (txtremarks.Text != "")
                {
                    Remarks = txtremarks.Text;
                }
                UpdateClassDetails(EndTime, StartTime, Language, Remarks);
            }
            
           
        }
        private void UpdateClassDetails(string EndTime, string StartTime, string Language, string Remarks)
        {
            BLL.updateClassDetails(ClassID, EndTime, StartTime, Language, Remarks);
        }

        protected void BtnUnpublish_Click(object sender, EventArgs e)
        {
            BLL.setpublishmode(ClassID, 2);
            BtnPublish.Visible = true;
            BtnUnpublish.Visible = false;
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            if (checktimevalid() == true)
            {
                BLL.setpublishmode(ClassID, 1);
                BtnUnpublish.Visible = true;
                BtnPublish.Visible = false;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassAdmin.aspx?CourseID="+ CourseID );
        }

        private bool checktimevalid()
        {

            bool A = false, B = false, C = false;

            if (txtstarttime.Text != "" && txtendtime.Text != "")
            {
                DateTime starttime = DateTime.ParseExact(txtstarttime.Text, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime endtime = DateTime.ParseExact(txtendtime.Text, "h:mm tt", CultureInfo.InvariantCulture);
                A = true;
                B = true;
                if (endtime < starttime)
                {
                    lblendtimevalid.Text = "End time should be later than start time";
                    lblstarttimevalid.Text = "Start time should be earlier than end time";
                    C = false;
                }
                else
                {
                    C = true;
                }
            }

            if (txtstarttime.Text == "")
            {
                lblstarttimevalid.Text = "Please enter the start time";
                A = false;
            }

            if (txtendtime.Text == "")
            {
                lblendtimevalid.Text = "Please enter the end time";
                B = false;
            }

            if (A == true && B == true && C == true)
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