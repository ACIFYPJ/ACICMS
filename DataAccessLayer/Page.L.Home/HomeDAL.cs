using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Page.L.Home
{
    public class HomeDAL
    {

        string constr = Properties.Settings.Default.DBConnect;

        public DataTable getCarouselData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM aci_HP_carousel"))
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

        public DataTable getFeaturedEventsData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM aci_event WHERE HomePageFeatured=1"))
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
        public DataTable getFeaturedCoursesData()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT aci_course.CourseID,aci_course.CourseName,aci_program.ProgramName FROM aci_course INNER JOIN aci_program ON aci_course.ProgramID = aci_program.ProgramID WHERE HomePageFeatured=1"))
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

        public void InsertCarouselImage(byte[] ImageBin, string FileName, int DisplayOrder)
        {      
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO aci_HP_carousel(ImageBin,FileName,DisplayOrder) VALUES (@ImageBin,@FileName,@DisplayOrder)", con);
                    cmd.Parameters.AddWithValue("@ImageBin", ImageBin);
                    cmd.Parameters.AddWithValue("@FileName", FileName);
                    cmd.Parameters.AddWithValue("@DisplayOrder", DisplayOrder);
                    cmd.ExecuteNonQuery();
                    con.Close();                  
                }
                catch (Exception)
                {
                   
                }
            }         
        }
        public void UpdateCarousel(int ImageID)
        {            
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM aci_HP_carousel WHERE ImageID=@ImageID", con);
                    cmd.Parameters.AddWithValue("@ImageID", ImageID);                   
                    cmd.ExecuteNonQuery();                   
                }
                catch (Exception e)
                {
                  
                }
            }
        }

        public void UpdateEventFeatured(int EventID, int featured)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE aci_event SET HomePageFeatured=@HPF WHERE EventID=@EventID", con);
                    cmd.Parameters.AddWithValue("@EventID", EventID);
                    cmd.Parameters.AddWithValue("@HPF", featured);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void UpdateCourseFeatured(int CourseID, int featured)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE aci_course SET HomePageFeatured=@HPF WHERE CourseID=@CourseID", con);
                    cmd.Parameters.AddWithValue("@CourseID", CourseID);
                    cmd.Parameters.AddWithValue("@HPF", featured);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
