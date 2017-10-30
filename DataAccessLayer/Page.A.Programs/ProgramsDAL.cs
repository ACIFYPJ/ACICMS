using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Page.A.Programs
{
    public class ProgramsDAL
    {
        string constr = Properties.Settings.Default.DBConnect;
    }
}
