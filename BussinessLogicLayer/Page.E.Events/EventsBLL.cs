using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Page.E.Events
{
   public class EventsBLL
    {
       public int pubStatus(string status)
       {
           if (status == "Draft")
           {
               return 1;
           }
           else if (status == "Published")
           {
               return 2;
           }
           else
               return 3;
       }

    }
}
