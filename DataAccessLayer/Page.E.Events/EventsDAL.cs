using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.Page.E.Events
{
    public class EventsDAL
    {

        string constr = Properties.Settings.Default.DBConnect;
        public void addEvent(string eventTitle, string description, string photoPath, string location, DateTime eventStart, DateTime eventEnd, int regStatus, DateTime deadline, int homeFeatured, int fOrder, int pID, string ps, int pStatus, int createuserid, DateTime createdate)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO aci_event(EventTitle, Description, PhotoPath, Location, EventStart, EventEnd, RegistrationStatus, RegistrationEnd, HomePageFeatured, FeaturedOrder, PhotoAlbumID, PageSlug, PublishStatus, CreateUserID, CreateDate) VALUES (@eventTitle, @description, @photoPath, @location, @eventStart, @eventEnd, @regStatus, @regEnd, @homeFeatured, @featureOrder, @photoalbumid, @pageslug, @publishStatus, @createUserID, @createDate)", con);
                
                    cmd.Parameters.AddWithValue("@eventTitle", eventTitle);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@photoPath", photoPath);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@eventStart", eventStart);
                    cmd.Parameters.AddWithValue("@eventEnd", eventEnd);
                    cmd.Parameters.AddWithValue("@regStatus", regStatus);
                    cmd.Parameters.AddWithValue("@regEnd", deadline);
                    cmd.Parameters.AddWithValue("@homeFeatured", homeFeatured);
                    cmd.Parameters.AddWithValue("@featureOrder", fOrder);
                    cmd.Parameters.AddWithValue("@photoalbumid", pID);
                    cmd.Parameters.AddWithValue("@pageslug", ps);
                    cmd.Parameters.AddWithValue("@publishStatus", pStatus);
                    cmd.Parameters.AddWithValue("@createUserID", createuserid);
                    cmd.Parameters.AddWithValue("@createDate", createdate);
                    //cmd.Parameters.AddWithValue("@LastModifiedUserID", lastmodifieduserid);
                    //cmd.Parameters.AddWithValue("@LastModifiedDate", lastmodifieddate);
                    cmd.ExecuteNonQuery();
                
            }
        }
        public int getCount()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM aci_event", con);
                int count = (int)cmd.ExecuteScalar();
                return count;
                
            }
        }
        public DataTable GetData()
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT EventID, HomePageFeatured, EventTitle, Location, EventStart, EventEnd,RegistrationStatus,PublishStatus FROM aci_event"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public string getEventTitle(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EventTitle FROM aci_event WHERE EventID = @eventID",con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                string EventTitle =cmd.ExecuteScalar() as string;
                return EventTitle;
            }
        }
        public string getLocation(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Location FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                string location = cmd.ExecuteScalar() as string;
                return location;
            }
        }
        public string getDescription(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Description FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                string description = cmd.ExecuteScalar() as string;
                return description;
            }
        }
        public string getsDate(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EventStart FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                DateTime sd = (DateTime)cmd.ExecuteScalar();
                string sDate = sd.ToString();
                return sDate;
            }
        }
        public string geteDate(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EventEnd FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                DateTime ed = (DateTime)cmd.ExecuteScalar();
                string eDate = ed.ToString();
                return eDate;
            }
        }
        public string getDeadline(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegistrationEnd FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                DateTime d = (DateTime)cmd.ExecuteScalar();
                string deadline = d.ToString();
                return deadline;
            }
        }
        public int getRegStatus(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegistrationStatus FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                int regStatus = (int)cmd.ExecuteScalar();
                return regStatus;
            }
        }
        public int featured(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT HomePageFeatured FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                int featured = (int)cmd.ExecuteScalar();
                return featured;
            }
        }
        public int fOrder(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT FeaturedOrder FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                int fOrder = (int)cmd.ExecuteScalar();
                return fOrder;
            }
        }
        public string pubStatus(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PublishStatus FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                int status = (int)cmd.ExecuteScalar();
                if (status == 1)
                {
                    return "Draft";
                }
                else if (status == 2)
                {
                    return "Published";
                }
                else
                    return "Archived";

            }
        }
    }
}