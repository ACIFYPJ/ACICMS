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
    public partial class EventApplicants : System.Web.UI.Page
    {
        private static int ViewID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                EventsDAL DAL = new EventsDAL();
                //Populating a DataTable from database.
                DataTable dt = DAL.GetApplicantsData();
                EventRPT.DataSource = dt;
                EventRPT.DataBind();
            }
        }

        protected void EventRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewApplicant")
            {
                ViewID = int.Parse(e.CommandArgument.ToString());
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