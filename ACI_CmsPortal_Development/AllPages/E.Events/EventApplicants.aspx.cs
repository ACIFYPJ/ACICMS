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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindtabledata();
            }
        }
        private void bindtabledata()
        {
            EventsDAL DAL = new EventsDAL();
            //Populating a DataTable from database.
            DataTable dt = DAL.GetApplicantsData();
            EventRPT.DataSource = dt;
            EventRPT.DataBind();
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
                lbVRegistrationID.Text = HttpUtility.HtmlEncode(dtRow["RegistrationID"].ToString());
                //lbVRegistrationID.Text = dtRow["RegistrationID"].ToString();
                lbVRegistrationDate.Text = HttpUtility.HtmlEncode(dtRow["RegistrationDate"].ToString());
                lbVEventTitle.Text = HttpUtility.HtmlEncode(dtRow["Title"].ToString());
                lbVname.Text = HttpUtility.HtmlEncode(dtRow["Name"].ToString());
                lbVnationality.Text = HttpUtility.HtmlEncode(dtRow["Nationality"].ToString());
                lbVnric.Text = HttpUtility.HtmlEncode(dtRow["NRIC"].ToString());
                //lbVdob.Text = dtRow["DateOfBirth"].ToString();
                DateTime DOB = DateTime.Parse(dtRow["DateOfBirth"].ToString());
                lbVdob.Text = DOB.ToString("dd MMMM yyyy");
                lbVhighestedu.Text = HttpUtility.HtmlEncode(dtRow["HighestEducation"].ToString());
                lbVcurrentemploy.Text = HttpUtility.HtmlEncode(dtRow["CurrentEmployment"].ToString());
                lbVreferralsource.Text = HttpUtility.HtmlEncode(dtRow["ReferralSource"].ToString());
                lbVsignupreason.Text = HttpUtility.HtmlEncode(dtRow["SignupReason"].ToString());
                lbVhandphone.Text = HttpUtility.HtmlEncode(dtRow["Handphone"].ToString());
                lbVemail.Text = HttpUtility.HtmlEncode(dtRow["Email"].ToString());
            }
        }

    }
}