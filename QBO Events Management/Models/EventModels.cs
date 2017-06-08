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
		public int eventID { get; set; }
		public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public String Venue { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
	}

    public class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}