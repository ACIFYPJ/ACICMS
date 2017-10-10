using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using DataAccessLayer.Page.E.Events;
using BussinessLogicLayer;
using BussinessLogicLayer.Page.E.Events;

namespace ACI_CmsPortal_Development.AllPages.E.Events
{

    public partial class EventAdd : System.Web.UI.Page
    {

        EventsDAL DAL = new EventsDAL();
        EventsBLL BLL = new EventsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            
            int regStatus = checkbox(CheckBox1);
            int homeFeatured = checkbox(CheckBox2);
            int fOrder = BLL.fo(featureorder.Value);

            
            int photoalbumid = 1;
            string pageslug = "asd";
            string status = DropDownList2.Text;
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
        
        public int checkbox(CheckBox c)
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