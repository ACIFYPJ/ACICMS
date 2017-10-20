using DataAccessLayer.Page.E.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.E.Events
{
    public partial class EventDetails : System.Web.UI.Page
    {
        static int EventID = 25;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindinfofield();
                bindtabledata();
                //EventID = int.Parse(Request.QueryString["EventID"].ToString());
            }
        }
        private void bindtabledata()
        {
            EventsDAL DAL = new EventsDAL();
            //Populating a DataTable from database.
            DataTable dt = DAL.GetEventApplicantsData(EventID);
            EventRPT.DataSource = dt;
            EventRPT.DataBind();
        }

        private void bindinfofield()
        {
            EventsDAL geteventinfo = new EventsDAL();
            //DataTable dt = geteventinfo.GetSpecificEventData(EventID);
            //foreach (DataRow row in dt.Rows)
            //{
            //    lbltitle.Text = row["EventTitle"].ToString();
            //    lblstartDT.Text = row["EventStart"].ToString();
            //    lblEndDT.Text = row["EventEnd"].ToString();
            //    int regstatus = int.Parse(row["RegistrationStatus"].ToString());
            //    if (regstatus == 1)
            //    {
            //        lblregStatus.Text = "Active";
            //    }
            //    else
            //    {
            //        lblregStatus.Text = "Inactive";
            //    }
            //    lblregEnd.Text = row["RegistrationEnd"].ToString();
            //    // lblCreatedBy.Text = row["username"].ToString();
            //    lblCreatedOn.Text = row["CreateDate"].ToString();
            //    lblLastModifiedDate.Text = row["LastModifiedDate"].ToString();
            //}
            int countvalue = geteventinfo.GetApplicantsCount(EventID);
            lblTotalNumberOfApplicants.Text = countvalue.ToString();            
        }

        protected void EventRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ViewID = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "ViewApplicant")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                PopulateModal(ViewID);
            }
        }

        private void PopulateModal(int ApplicantID)
        {
            EventsDAL ApplicantModal = new EventsDAL();
            DataTable dt = ApplicantModal.GetSpecificApplicantsData(ApplicantID);
            foreach (DataRow dtRow in dt.Rows)
            {
                lbVRegistrationID.Text = dtRow["RegistrationID"].ToString();
                lbVRegistrationDate.Text = dtRow["RegistrationDate"].ToString();
                lbVEventTitle.Text = dtRow["Title"].ToString();

                lbVname.Text = dtRow["Name"].ToString();
                lbVnationality.Text = dtRow["Nationality"].ToString();
                lbVnric.Text = dtRow["NRIC"].ToString();
                //lbVdob.Text = dtRow["DateOfBirth"].ToString();
                DateTime DOB = DateTime.Parse(dtRow["DateOfBirth"].ToString());
                lbVdob.Text = DOB.ToString("dd MMMM yyyy");

                lbVhighestedu.Text = dtRow["HighestEducation"].ToString();
                lbVcurrentemploy.Text = dtRow["CurrentEmployment"].ToString();
                lbVreferralsource.Text = dtRow["ReferralSource"].ToString();
                lbVsignupreason.Text = dtRow["SignupReason"].ToString();

                lbVhandphone.Text = dtRow["Handphone"].ToString();
                lbVemail.Text = dtRow["Email"].ToString();

            }

        }
    }
}