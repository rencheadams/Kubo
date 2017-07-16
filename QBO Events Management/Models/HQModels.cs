using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
    public class HQ
    {
        public int HQID { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public DateTime DateTime { get; set;}
        public String Purpose { get; set; }
    }

    public class HQPhoto
    {
        public int HQPhotoID { get; set; }
        public string PhotoURL { get; set; }
        public int HQID { get; set; }
        public virtual HQ HQ { get; set; }
    }
}