using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using DataAccessLayer.Page.E.Events;
using BussinessLogicLayer;
using BussinessLogicLayer.Page.E.Events;

namespace ACI_CmsPortal_Development.AllPages.E.Events
{
    public partial class EventEdit : System.Web.UI.Page
    {
        EventsBLL BLL = new EventsBLL();
        EventsDAL DAL = new EventsDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int EventID = int.Parse(Request.QueryString["EventID"]);
                tbeventTitle.Text = DAL.getEventTitle(EventID);
                tblocation.Text = DAL.getLocation(EventID);
                startDate.Value = DAL.getsDate(EventID).ToString();
                endDate.Value = DAL.geteDate(EventID).ToString();
                CKEditor1.Text = DAL.getDescription(EventID);
                regCheckbox(EventID);
                rDeadline.Value = DAL.getDeadline(EventID).ToString();
                FeaturedH(EventID);
                featureorder.Value = DAL.fOrder(EventID).ToString();
                pStatus.Text = DAL.pubStatus(EventID);
            }
           
        }
        public void regCheckbox(int input)
        {
            if (DAL.getRegStatus(input) == 1)
            {
                enableForm.Checked = true;

            }
            else
            {
                enableForm.Checked = false;
            }
                

        }
        public void FeaturedH(int i)
        {
            if (DAL.featured(i) == 1)
            {
                feature.Checked = true;

            }
            else
            {
                feature.Checked = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBoxValidator.IsValid && StartDateValidator.IsValid && DescriptionValidator.IsValid && EndDateValidator.IsValid)
            {
                string eventTitle = tbeventTitle.Text;
                string description = CKEditor1.Text;
                string photoPath = "";
                string location = tblocation.Text;
                DateTime sDate = DateTime.ParseExact(startDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime eDate = DateTime.ParseExact(endDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                int regStatus = CheckBox(enableForm);
                int homeFeatured = CheckBox(feature);
                int fOrder = BLL.fo(featureorder.Value);
                int photoalbumid = 1;
                string pageslug = "asd";
                string status = pStatus.Text;
                int publishStatus = BLL.pubStatus(status);
                int createUserID = 1;
                Nullable<DateTime> deadline = null;
                DateTime createDate = DateTime.Now;
                //DateTime deadline = DateTime.ParseExact(rDeadline.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                //int LastModifiedUserID = 1;
                //DateTime LastModifiedDate = DateTime.Now;
                DAL.addEvent(eventTitle, description, photoPath, location, sDate, eDate, regStatus, deadline, homeFeatured, fOrder, photoalbumid, pageslug, publishStatus, createUserID, createDate);
                Response.Redirect("EventsAdmin.aspx");
            }
        }
        public static int CheckBox(CheckBox c)
        {
            if (c.Checked)
            {
                return 1;
            }
            else
                return 0;

        }
    }
}