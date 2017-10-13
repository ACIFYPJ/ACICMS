using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using DataAccessLayer.Page.E.Events;

namespace ACI_CmsPortal_Development.AllPages.E.Events
{
    public partial class EventsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                EventsDAL DAL = new EventsDAL();
                //Populating a DataTable from database.
                DataTable dt = DAL.GetData();
                EventRPT.DataSource = dt;
                EventRPT.DataBind();
            }
        }

        protected void EventRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EditEvent")
            {
                Response.Redirect("EventEdit.aspx?EventID="+ e.CommandArgument.ToString());
            }
        }

        protected void BtnEventNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventAdd.aspx");
        }

        protected void btnViewApplicants_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventApplicants.aspx");
        }

      
    }
}