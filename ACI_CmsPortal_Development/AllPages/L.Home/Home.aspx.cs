using BussinessLogicLayer.Page.B.Courses;
using BussinessLogicLayer.Page.L.Home;
using DataAccessLayer.Page.E.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACI_CmsPortal_Development.AllPages.L.Home
{
    public partial class Home : System.Web.UI.Page
    {
        HomeBLL BLL = new HomeBLL();
        EventsDAL DALEvents = new EventsDAL();
        CoursesBLL BLLCourses = new CoursesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //loadRPTs
                loadImagesRPT();
                loadCoursesRPT();
                loadEventsRPT();

            }
        }
        private void loaddropdown()
        {
            DDLProgramme.DataSource = BLLCourses.getProgramList();
            DDLProgramme.DataValueField = "ProgramID";
            DDLProgramme.DataTextField = "ProgramName";
            DDLProgramme.DataBind();
        }

        private void loadImagesRPT()
        {
            DataTable dt = BLL.getCarouselData();
            CarouselRPT.DataSource = dt;
            CarouselRPT.DataBind();
        }

        private DataTable loadEventsRPT()
        {
            DataTable dt = BLL.getFeaturedEventsData();
            EventRPT.DataSource = dt;
            EventRPT.DataBind();
            return dt;
        }
        private DataTable loadCoursesRPT()
        {
            DataTable dt = BLL.getFeaturedCoursesData();
            CoursesRPT.DataSource = dt;
            CoursesRPT.DataBind();
            return dt;
        }
        private void bindEventtabledata()
        {
            //Populating a DataTable from database.
            DataTable dt = DALEvents.GetData();
            ModalEventRPT.DataSource = dt;
            ModalEventRPT.DataBind();
        }

        private void loadCoursesTabledata()
        {
            int publishmode = int.Parse(DDLpublish.SelectedValue.ToString());
            int programID = int.Parse(DDLProgramme.SelectedValue.ToString());
            DataTable dt = BLLCourses.getTableData(publishmode, programID);
            ModalcoursesRPT.DataSource = dt;
            ModalcoursesRPT.DataBind();

        }
        protected void DDLpublish_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Label1.Text = DDLpublish.SelectedValue.ToString() + "  programID = " + DDLProgramme.SelectedValue.ToString();
            loadCoursesTabledata();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupcourse();", true);
        }

        protected void DDLProgramme_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Label1.Text = DDLpublish.SelectedValue.ToString() + "  programID = " + DDLProgramme.SelectedValue.ToString();
            loadCoursesTabledata();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupcourse();", true);
        }


        protected void BtnAddImage_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        protected void uploadFile_Click(object sender, EventArgs e)
        {
            if (UploadImages.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                {
                    FileUpload img = (FileUpload)UploadImages;
                    Byte[] imgByte = null;
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "tiff" };
                    HttpPostedFile File = UploadImages.PostedFile;
                    string ext = System.IO.Path.GetExtension(File.FileName);
                    bool isValidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile = true;
                            break;
                        }
                    }
                    if (!isValidFile)
                    {
                        break;
                    }
                    //Create byte Array with file length
                    imgByte = new Byte[File.ContentLength];
                    //Force control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    byte[] photoBin = imgByte;
                    BLL.InsertCarouselImage(photoBin, uploadedFile.FileName, 0);
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("../../images/"), uploadedFile.FileName));

                }
            }
            loadImagesRPT();
        }

        protected void btnSearchEvents_Click(object sender, EventArgs e)
        {
            DataTable dt = loadEventsRPT();
            if (dt.Rows.Count != 3)
            {
                bindEventtabledata();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupevent();", true);
            }
        }

        protected void BtnCourses_Click(object sender, EventArgs e)
        {
            DataTable dt = loadCoursesRPT();
            if (dt.Rows.Count != 3)
            {
                loaddropdown();
                loadCoursesTabledata();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupcourse();", true);
            }

        }

        protected void CarouselRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CarouselRemove")
            {
                BLL.UpdateCarousel(int.Parse(e.CommandArgument.ToString()));
                loadImagesRPT();
            }
        }

        protected void EventRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EventRemove")
            {
                BLL.UpdateEventFeatured(int.Parse(e.CommandArgument.ToString()), 0);
                loadEventsRPT();
            }
        }

        protected void CoursesRPT_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CoursesRemove")
            {
                BLL.UpdateCourseFeatured(int.Parse(e.CommandArgument.ToString()), 0);
                loadCoursesRPT();
            }
        }

        protected void ModalEventRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ModalAddEvent")
            {
                BLL.UpdateEventFeatured(int.Parse(e.CommandArgument.ToString()), 1);
                loadEventsRPT();
            }
        }

        protected void ModalCoursesRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ModalAddCourse")
            {
                BLL.UpdateCourseFeatured(int.Parse(e.CommandArgument.ToString()), 1);
                Response.Redirect("Home.aspx");
                loadCoursesRPT();
            }
        }

    }
}