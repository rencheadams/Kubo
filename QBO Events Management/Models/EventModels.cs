using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace QBO_Events_Management.Models
{
	
	public class Event
	{
		public string EventsID { get; set; }
		public string Name { get; set; }
		public string URL { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
        public String Status { get; set; }
        public String Tickets { get; set; }

        /*
        public DateTime Created { get; set; }
		public DateTime Changed { get; set; }
        */

		//public int eventID { get; set; }

		//      [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
		//      [Required]
		//      [StringLength(50)]
		//      public string Name { get; set; }

		//      [DataType(DataType.Date)]
		//      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		//      public DateTime Date { get; set; }

		//      [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
		//      [Required]
		//      [StringLength(200)]
		//      public String Venue { get; set; }

		//      [DataType(DataType.Time)]
		//      public TimeSpan Time { get; set; }

		//      [DataType(DataType.MultilineText)]
		//      public string Details { get; set; }

		//      public bool IsPublished { get; set; }

		//      public string Status { get; set; }
	}
}