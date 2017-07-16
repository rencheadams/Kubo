using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QBO_Events_Management.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set;}
        public String MobileNumber { get; set; }
        public bool Gender { get; set; }
        //Problem with Select Sector
        public String Sector { get; set; }
        
        public virtual List<HQ> HQs { get; set; }
        public virtual List<Participant> Participant {get; set;}
    }
}