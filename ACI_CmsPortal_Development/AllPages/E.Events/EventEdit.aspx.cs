﻿using System;
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
        EventsBLL BLL = new EventsBLL();
        EventsDAL DAL = new EventsDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int EventID = int.Parse(Request.QueryString["EventID"]);
                tbeventTitle.Text = DAL.getEventTitle(EventID);
                tblocation.Text = DAL.getLocation(EventID);
                startDate.Value = DAL.getsDate(EventID).ToString();
                endDate.Value = DAL.geteDate(EventID).ToString();
                CKEditor1.Text = DAL.getDescription(EventID);
                regCheckbox(EventID);
                rDeadline.Value = DAL.getDeadline(EventID).ToString();
                //FeaturedH(EventID);
               // featureorder.Value = DAL.fOrder(EventID).ToString();
                pStatus.Text = DAL.pubStatus(EventID);               
            }
           
        }

        
        public void regCheckbox(int input)
        {
            if (DAL.getRegStatus(input) == 1)
            {
                enableForm.Checked = true;

                //if registration is enabled, no more changes can be made
                tblocation.Enabled = false;
                CKEditor1.Enabled = false;
                enableForm.Enabled = false;
                startDate.Disabled = true;
                endDate.Disabled = true;
                rDeadline.Disabled = true;

            }
            else
            {
                enableForm.Checked = false;
            }
                

        }
       

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBoxValidator.IsValid && StartDateValidator.IsValid && DescriptionValidator.IsValid && EndDateValidator.IsValid)
            {
                int EventID = int.Parse(Request.QueryString["EventID"]);
                string eventTitle = tbeventTitle.Text;
                string description = CKEditor1.Text;
                FileUpload img = (FileUpload)imgUpload;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //Create a PostedFile
                    HttpPostedFile File = imgUpload.PostedFile;
                    //Create byte Array with file length
                    imgByte = new Byte[File.ContentLength];
                    //Force control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }

                byte[] photoBin = imgByte;
                string location = tblocation.Text;
                DateTime sDate = DateTime.ParseExact(startDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime eDate = DateTime.ParseExact(endDate.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                int regStatus = CheckBox(enableForm);
                int homeFeatured = 0;
                int fOrder = 0;
                int photoalbumid = 1;
                string pageslug = "asd";
                string status = pStatus.Text;
                int publishStatus = BLL.pubStatus(status);
                int createUserID = 1;
                Nullable<DateTime> deadline;
                if (string.IsNullOrWhiteSpace(rDeadline.Value))
                {
                    deadline = null;
                }
                else
                    deadline = DateTime.ParseExact(rDeadline.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
               

                 DateTime createDate = DateTime.Now;
                //DateTime deadline = DateTime.ParseExact(rDeadline.Value, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                //int LastModifiedUserID = 1;
                //DateTime LastModifiedDate = DateTime.Now;
                DAL.editEvent(eventTitle, description, photoBin, location, sDate, eDate, regStatus, deadline, homeFeatured, fOrder, photoalbumid, pageslug, publishStatus, createUserID, createDate, EventID);
                Response.Redirect("EventsAdmin.aspx");
            }
        }
        public static int CheckBox(CheckBox c)
        {
            if (c.Checked)
            {
                return 1;
            }
            else
                return 0;

        }
        //public void FeaturedH(int i)
        //{
        //    if (DAL.featured(i) == 1)
        //    {
        //        feature.Checked = true;

        //    }
        //    else
        //    {
        //        feature.Checked = false;
        //    }
        //}
    }
}