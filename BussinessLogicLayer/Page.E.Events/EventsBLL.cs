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

       public int fo(string input)
       {
           if (string.IsNullOrWhiteSpace(input))
           {
               return 1;
           }
           else
           {
               return Int32.Parse(input);
           }
       }
    }
}
