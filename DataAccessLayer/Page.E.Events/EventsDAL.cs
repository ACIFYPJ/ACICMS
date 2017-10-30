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


        public void addEvent(string eventTitle, string description, string photoPath, string location, DateTime eventStart, DateTime eventEnd, int regStatus, Nullable<DateTime> deadline, int homeFeatured, int fOrder, int pID, string ps, int pStatus, int createuserid, DateTime createdate)
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
                SqlParameter d = cmd.Parameters.AddWithValue("@regEnd", deadline);
                cmd.Parameters.AddWithValue("@homeFeatured", homeFeatured);
                SqlParameter f = cmd.Parameters.AddWithValue("@featureOrder", fOrder);
                cmd.Parameters.AddWithValue("@photoalbumid", pID);
                cmd.Parameters.AddWithValue("@pageslug", ps);
                cmd.Parameters.AddWithValue("@publishStatus", pStatus);
                cmd.Parameters.AddWithValue("@createUserID", createuserid);
                cmd.Parameters.AddWithValue("@createDate", createdate);
                if (deadline == null)
                {
                    d.Value = DBNull.Value;
                }
                if (fOrder == null)
                {
                    f.Value = DBNull.Value;
                }
                cmd.ExecuteNonQuery();

            }
        }

        
        
        public void deleteEvent(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE aci_event WHERE EventID=@eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                cmd.ExecuteNonQuery();
            }
        }
        public void editEvent(string eventTitle, string description, string photoPath, string location, DateTime eventStart, DateTime eventEnd, int regStatus, Nullable<DateTime> deadline, int homeFeatured, int fOrder, int pID, string ps, int pStatus, int createuserid, DateTime createdate, int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                //DateTime etc = DateTime.Parse("11/11/2007");

                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_event SET EventTitle = @eventTitle, Description=@description, PhotoPath =@photoPath, Location =@location, EventStart=@eventStart, EventEnd=@eventEnd, RegistrationStatus=@regStatus, RegistrationEnd =@regEnd, HomePageFeatured =@homeFeatured, FeaturedOrder=@featureOrder, PhotoAlbumID =@photoalbumid, PageSlug=@pageslug, PublishStatus =@publishStatus, CreateUserID=@createUserID, CreateDate=@createDate WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventTitle", eventTitle);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@photoPath", "asd");
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@eventStart", eventStart);
                cmd.Parameters.AddWithValue("@eventEnd", eventEnd);
                cmd.Parameters.AddWithValue("@regStatus", regStatus);
                SqlParameter d = cmd.Parameters.AddWithValue("@regEnd", deadline);
                cmd.Parameters.AddWithValue("@homeFeatured", homeFeatured);
                SqlParameter f = cmd.Parameters.AddWithValue("@featureOrder", fOrder);
                cmd.Parameters.AddWithValue("@photoalbumid", pID);
                cmd.Parameters.AddWithValue("@pageslug", ps);
                cmd.Parameters.AddWithValue("@publishStatus", pStatus);
                cmd.Parameters.AddWithValue("@createUserID", createuserid);
                cmd.Parameters.AddWithValue("@createDate", createdate);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                cmd.ExecuteNonQuery();
                if (deadline == null)
                {
                    d.Value = DBNull.Value;
                }
                if (fOrder == null)
                {
                    f.Value = DBNull.Value;
                }
                cmd.ExecuteNonQuery();

            }
        }


        public DataTable GetData()
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT EventID, HomePageFeatured, EventTitle, Location, EventStart, EventEnd,RegistrationStatus,PublishStatus FROM aci_event ORDER BY EventID DESC"))
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

        public DataTable GetSpecificEventData(int EventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM aci_event WHERE EventID=@EventID"))
                {
                    cmd.Parameters.AddWithValue("@EventID", EventID);
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
        public DataTable GetApplicantsData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT RegistrationID, Title,Name,DateOfBirth,Handphone,Email,NRIC FROM aci_eventregistration"))
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
        public DataTable GetEventApplicantsData(int EventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT RegistrationID, Title,Name,DateOfBirth,Handphone,Email,NRIC FROM aci_eventregistration WHERE EventID=@EventID"))
                {
                    cmd.Parameters.AddWithValue("@EventID", EventID);
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
        public DataTable GetSpecificApplicantsData(int ID)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM aci_eventregistration WHERE RegistrationID=@RegistrationID"))
                {
                    cmd.Parameters.AddWithValue("@RegistrationID", ID);
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

        public int GetApplicantsCount(int EventID)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string Getapplicantcount = "SELECT count(*) from aci_eventregistration where EventID=@EventID";
            SqlCommand cmd = new SqlCommand(Getapplicantcount, myConnect);
            cmd.Parameters.AddWithValue("@EventID", EventID);
            int value = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            myConnect.Close();
            return value;
        }

        public string getEventTitle(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EventTitle FROM aci_event WHERE EventID = @eventID", con);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                string EventTitle = cmd.ExecuteScalar() as string;
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
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT EventStart FROM aci_event WHERE EventID = @eventID", con);
                    cmd.Parameters.AddWithValue("@eventID", eventID);
                    DateTime sd = (DateTime)cmd.ExecuteScalar();
                    string sDate = sd.ToString("dd/MM/yyyy HH:mm");
                    return sDate;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        public string geteDate(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT (EventEnd) FROM aci_event WHERE EventID = @eventID", con);
                    cmd.Parameters.AddWithValue("@eventID", eventID);
                    DateTime ed = (DateTime)cmd.ExecuteScalar();
                    string eDate = ed.ToString("dd/MM/yyyy HH:mm");
                    return eDate;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        public string getDeadline(int eventID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT RegistrationEnd FROM aci_event WHERE EventID = @eventID", con);
                    cmd.Parameters.AddWithValue("@eventID", eventID);
                    DateTime d = (DateTime)cmd.ExecuteScalar();
                    string deadline = d.ToString("dd/MM/yyyy HH:mm");
                    return deadline;
                }
                catch (Exception)
                {
                    return "";
                }
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