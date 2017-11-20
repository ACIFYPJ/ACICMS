using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Page.B.Courses
{
    public class CoursesDAL
    {
        string constr = Properties.Settings.Default.DBConnect;


        public void updateCoreModule(int CourseID, string Module)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_course SET CoreModules = @CoreModules WHERE CourseID = @CourseID", con);
                cmd.Parameters.AddWithValue("@CoreModules", Module);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);              
                int result = cmd.ExecuteNonQuery();
                con.Close();           
            }
        }
        public void updateElectiveModule(int CourseID, string Module)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_course SET ElectiveModules = @ElectiveModules WHERE CourseID = @CourseID", con);
                cmd.Parameters.AddWithValue("@ElectiveModules", Module);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                int result = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public bool checkRole(int uid)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM cms_user WHERE (userID = @uid) AND (roles LIKE '%CoursesAdmin%' OR roles LIKE '%Administrator%')", con))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    int i = (int)cmd.ExecuteScalar();
                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
            }
        }
     
        public DataTable getClassDetails(int ClassID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM aci_class WHERE ClassID=@ClassID"))
                {
                    cmd.Parameters.AddWithValue("@ClassID", ClassID);
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
        public string getCoreArray(int CourseID)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string checkuser = "SELECT CoreModules from aci_course where CourseID=@CourseID";
            SqlCommand cmd = new SqlCommand(checkuser, myConnect);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            string CoreModules = cmd.ExecuteScalar().ToString();
            myConnect.Close();
            return CoreModules;
        }

        public string getElectiveArray(int CourseID)
        {
            SqlConnection myConnect = new SqlConnection(constr);
            myConnect.Open();
            string checkuser = "SELECT ElectiveModules from aci_course where CourseID=@CourseID";
            SqlCommand cmd = new SqlCommand(checkuser, myConnect);
            cmd.Parameters.AddWithValue("@CourseID", CourseID);
            string ElectiveModules = cmd.ExecuteScalar().ToString();
            myConnect.Close();
            return ElectiveModules;
        }

        public DataTable getProgramList()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ProgramID,ProgramName FROM aci_program ORDER BY DisplayOrder ASC"))
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

        public DataTable getTableData1()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT aci_course.CourseID, aci_course.CourseName, aci_course.ProgramID, aci_course.CourseVersion, aci_program.ProgramName  FROM aci_course INNER JOIN aci_program ON aci_course.ProgramID = aci_program.ProgramID "))
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
        public DataTable getTableData2(int programID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT aci_course.CourseID, aci_course.CourseName, aci_course.ProgramID, aci_course.CourseVersion, aci_program.ProgramName  FROM aci_course INNER JOIN aci_program ON aci_course.ProgramID = aci_program.ProgramID  WHERE aci_course.ProgramID=@ProgramID"))
                {                  
                    cmd.Parameters.AddWithValue("@ProgramID", programID);
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
        public DataTable getTableData3(int publishmode)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT aci_course.CourseID, aci_course.CourseName, aci_course.ProgramID, aci_course.CourseVersion, aci_program.ProgramName  FROM aci_course INNER JOIN aci_program ON aci_course.ProgramID = aci_program.ProgramID  WHERE aci_course.PublishMode=@PublishMode"))
                {
                    cmd.Parameters.AddWithValue("@PublishMode", publishmode);                  
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

        public DataTable getTableData4(int publishmode, int programID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT aci_course.CourseID, aci_course.CourseName, aci_course.ProgramID, aci_course.CourseVersion, aci_program.ProgramName  FROM aci_course INNER JOIN aci_program ON aci_course.ProgramID = aci_program.ProgramID  WHERE aci_course.PublishMode=@PublishMode AND aci_course.ProgramID=@ProgramID"))
                {
                    cmd.Parameters.AddWithValue("@PublishMode",publishmode);
                    cmd.Parameters.AddWithValue("@ProgramID",programID);
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

        public DataTable getCKdata(int CourseID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CourseName,ProgramID, PublishMode, Overview, TargetAudience, EntryRequirements, OtherInfo, RefundPolicy, CourseFees,CourseFeesText,PublishedBefore FROM aci_course WHERE CourseID=@CourseID"))
                {
                    cmd.Parameters.AddWithValue("@CourseID", CourseID);               
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

        public int UpdateCourse(int CourseID, int ProgramID, int PublishMode, string Overview, string TargetAudience,string  EntryRequirements, string OtherInfo, string RefundPolicy,string CourseFeesText)
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_course SET ProgramID = @ProgramID, PublishMode=@PublishMode, Overview=@Overview, TargetAudience=@TargetAudience, EntryRequirements=@EntryRequirements, OtherInfo=@OtherInfo, RefundPolicy=@RefundPolicy, CourseFeesText =@CourseFeesText WHERE CourseID = @CourseID", con);
                cmd.Parameters.AddWithValue("@ProgramID", ProgramID);
                cmd.Parameters.AddWithValue("@PublishMode", PublishMode);
                cmd.Parameters.AddWithValue("@Overview", Overview);
                cmd.Parameters.AddWithValue("@TargetAudience", TargetAudience);
                cmd.Parameters.AddWithValue("@EntryRequirements", EntryRequirements);
                cmd.Parameters.AddWithValue("@RefundPolicy", RefundPolicy);      
                cmd.Parameters.AddWithValue("@CourseFeesText", CourseFeesText);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@OtherInfo", OtherInfo);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;               
            }
        }
        public void UpdateCoursePublishedBefore(int CourseID)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_course SET PublishedBefore=1 WHERE CourseID = @CourseID", con);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);               
                cmd.ExecuteNonQuery();
                con.Close();
               
            }
        }

        public DataTable getclasses(int CourseID, int PublishMode)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ClassID, ClassCode, StartDate,EndDate FROM aci_class WHERE PublishMode=@PublishMode AND CourseID=@CourseID"))
                {
                    cmd.Parameters.AddWithValue("@CourseID", CourseID);
                    cmd.Parameters.AddWithValue("@PublishMode", PublishMode);
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

        public void setpublishmode(int ClassID, int publishMode)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_class SET PublishMode=@PublishMode WHERE ClassID = @ClassID", con);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                cmd.Parameters.AddWithValue("@PublishMode", publishMode);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public int updateClassDetails(int ClassID, string EndTime, string StartTime, string Language, string Remarks)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE aci_class SET ClassEndTime = @ClassEndTime, ClassStartTime=@ClassStartTime, Language=@Language, Remarks=@Remarks WHERE ClassID = @ClassID", con);
                cmd.Parameters.AddWithValue("@ClassEndTime", EndTime);
                cmd.Parameters.AddWithValue("@ClassStartTime", StartTime);
                cmd.Parameters.AddWithValue("@Language", Language);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
           
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
    }
}
