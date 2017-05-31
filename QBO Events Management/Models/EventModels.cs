using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
	public class Event
	{
		public int eventID { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public DateTime Date { get; set; }
		public int NoOfGuests { get; set; }


	}
}