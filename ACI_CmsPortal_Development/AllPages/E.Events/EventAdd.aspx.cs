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
            int count = DAL.getCount() + 1;
        }
        

        protected void Button4_Click(object sender, EventArgs e)
        {
            string eventTitle = tbeventTitle.Text;
            string description = CKEditor1.Text;
            string photoPath = "";
            string location = tblocation.Text;
            DateTime sDate = DateTime.ParseExact(startDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime eDate = DateTime.ParseExact(endDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            int regStatus = checkbox(CheckBox1);
            int homeFeatured = checkbox(CheckBox2);
            int fOrder = Int32.Parse(featureorder.Value);
            int photoalbumid = 1;
            string pageslug = "asd";
            string status = DropDownList2.Text;
            int publishStatus = BLL.pubStatus(status);
            int createUserID = 1;
            
            DateTime createDate = DateTime.Now;
            DateTime deadline = DateTime.ParseExact(rDeadline.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            
            //int LastModifiedUserID = 1;
           
            //DateTime LastModifiedDate = DateTime.Now;
            string filename = myImg.Value;
            DAL.addEvent(eventTitle, description, photoPath, location, sDate, eDate, regStatus, deadline, homeFeatured, fOrder, photoalbumid, pageslug, publishStatus, createUserID, createDate);
            Server.Transfer("EventsAdmin.aspx", true);

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