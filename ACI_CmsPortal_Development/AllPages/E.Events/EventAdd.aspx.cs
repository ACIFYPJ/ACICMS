using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.E.Events
{
    public partial class EventAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string eventTitle = Label1.Text;
            string location = Label2.Text;
            string s = Label3.Text;
            DateTime startDate = DateTime.ParseExact(s, "dd-MM-yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Label4.Text,"dd-MM-yyyy HH:mm",null);
            Label13.Text = startDate.ToString();

        }
    }
}