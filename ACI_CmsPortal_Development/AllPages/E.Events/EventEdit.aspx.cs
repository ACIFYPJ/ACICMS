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
        int EventID = 13;
        EventsDAL DAL = new EventsDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            tbeventTitle.Text = DAL.getEventTitle(EventID);
            tblocation.Text = DAL.getLocation(EventID);
            sDate.Value = DAL.getsDate(EventID);
            eDate.Value = DAL.geteDate(EventID);
            CKEditor1.Text = DAL.getDescription(EventID);
            regCheckbox();
            rDeadline.Value = DAL.getDeadline(EventID);
            featuredH();
            fOrder.Value = DAL.fOrder(EventID).ToString();
            pStatus.Text = DAL.pubStatus(EventID);
            Label13.Text = DAL.getRegStatus(EventID).ToString();
        }
        public void regCheckbox()
        {
            if (DAL.getRegStatus(EventID) == 1)
            {
                enableForm.Checked = true;

            }
            else
            {
                enableForm.Checked = false;
            }
                

        }
        public void featuredH()
        {
            if (DAL.featured(EventID) == 1)
            {
                feature.Checked = true;

            }
            else
            {
                feature.Checked = false;
            }
        }
    }
}