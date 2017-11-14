using DataAccessLayer.Page.B.Courses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Page.B.Courses
{
    public class CoursesBLL
    {
        CoursesDAL DAL = new CoursesDAL();

        public DataTable getClassDetails(int ClassID)
        {
            DataTable dt;
            dt = DAL.getClassDetails(ClassID);
            return dt;
        }
        public void updateClassDetails(int ClassID, string EndTime, string StartTime, string Language, string Remarks)
        {
            DAL.updateClassDetails(ClassID, EndTime, StartTime, Language, Remarks);
        }

        public string[] getCoreArray(int CourseID)
        {

            string roles = DAL.getCoreArray(CourseID);
            if (roles == "")
            {
                string[] arr = new string[] { };
                return arr;
            }
            else
            {
                string[] arr = roles.Split(new string[] { ";" }, StringSplitOptions.None);
                //  Array.Resize(ref arr, arr.Length - 1);
                return arr;
            }
        }
        public string[] getElectiveArray(int CourseID)
        {

            string roles = DAL.getElectiveArray(CourseID);
            if (roles == "")
            {
                string[] arr = new string[] { };
                return arr;
            }
            else
            {
                string[] arr = roles.Split(new string[] { ";" }, StringSplitOptions.None);
                //  Array.Resize(ref arr, arr.Length - 1);
                return arr;
            }
        }




        public DataTable getProgramList()
        {
            DataTable dt = DAL.getProgramList();
            return dt;
        }
        public DataTable getProgramListForEditpage()
        {
            DataTable dt = DAL.getProgramList();
            foreach (DataRow row in dt.Rows)
            {
                if (int.Parse(row["ProgramID"].ToString()) == 7)
                {
                    row.Delete();
                }
            }
            return dt;
        }

        public DataTable getTableData(int publishmode, int programID)
        {
            DataTable dt;

            if (publishmode == 0 && programID == 7)
            {
                dt = DAL.getTableData1();
            }
            else if (publishmode == 0 && programID != 7)
            {
                dt = DAL.getTableData2(programID);
            }
            else if (publishmode != 0 && programID == 7)
            {
                dt = DAL.getTableData3(publishmode);
            }
            else
            {
                dt = DAL.getTableData4(publishmode, programID);
            }
            return dt;
        }

        public void getCKdata(int CourseID, out string PublishStatus, out string ProgramID, out string description, out string targetaudience, out string refundpolicy, out string entryrequirements, out string otherinfo, out string CourseName, out double Coursefees, out string CourseFeesText, out int PublishedBefore)
        {
            PublishedBefore = -1;
            PublishStatus = "";
            ProgramID = "";
            description = "";
            targetaudience = "";
            refundpolicy = "";
            entryrequirements = "";
            otherinfo = "";
            CourseName = "";
            Coursefees = 0.0;
            CourseFeesText = "";
            DataTable dt;
            dt = DAL.getCKdata(CourseID);
            foreach (DataRow row in dt.Rows)
            {
                CourseName = row["CourseName"].ToString();
                PublishStatus = row["PublishMode"].ToString();
                ProgramID = row["ProgramID"].ToString();
                description = row["Overview"].ToString();
                targetaudience = row["TargetAudience"].ToString();
                refundpolicy = row["RefundPolicy"].ToString();
                entryrequirements = row["EntryRequirements"].ToString();
                otherinfo = row["OtherInfo"].ToString();
                Coursefees = double.Parse(row["CourseFees"].ToString());
                CourseFeesText = row["CourseFeesText"].ToString();
                PublishedBefore = int.Parse(row["PublishedBefore"].ToString());
            }
        }

        public int UpdateCourse(int CourseID, int ProgramID, int PublishMode, string Overview, string TargetAudience, string EntryRequirements, string OtherInfo, string RefundPolicy, string CourseFeesText)
        {
            if (PublishMode == 1)
            {
                //update publishedBefore to 1
                DAL.UpdateCoursePublishedBefore(CourseID);
            }
            int result = DAL.UpdateCourse(CourseID, ProgramID, PublishMode, Overview, TargetAudience, EntryRequirements, OtherInfo, RefundPolicy, CourseFeesText);
            return result;
        }

        public DataTable getClasses(int CourseID, int PublishMode)
        {
            DataTable dt;
            dt = DAL.getclasses(CourseID, PublishMode);
            return dt;
        }
        public void setpublishmode(int ClassID, int Publishmode)
        {
            DAL.setpublishmode(ClassID, Publishmode);
        }

    }
}
