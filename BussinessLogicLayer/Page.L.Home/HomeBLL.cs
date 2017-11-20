using DataAccessLayer.Page.L.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Page.L.Home
{
    public class HomeBLL
    {
        HomeDAL DAL = new HomeDAL();
        public DataTable getCarouselData()
        {
            DataTable dt;
            dt = DAL.getCarouselData();
            return dt;

        }
        public DataTable getFeaturedEventsData()
        {
            DataTable dt;
            dt = DAL.getFeaturedEventsData();
            return dt;

        }
        public DataTable getFeaturedCoursesData()
        {
            DataTable dt;
            dt = DAL.getFeaturedCoursesData();
            return dt;
        }

        public void InsertCarouselImage(byte[] ImageBin, string FileName, int DisplayOrder)
        {
            DAL.InsertCarouselImage(ImageBin, FileName, DisplayOrder);
        }


        public void UpdateCourseFeatured(int CourseID, int featured)
        {
            DAL.UpdateCourseFeatured(CourseID, featured);
        }

        public void UpdateEventFeatured(int EventID, int featured)
        {
            DAL.UpdateEventFeatured(EventID, featured);
        }
        public void UpdateCarousel(int ImageID)
        {
            DAL.UpdateCarousel(ImageID);
        }




    }
}
