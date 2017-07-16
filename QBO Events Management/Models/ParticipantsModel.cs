using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
	public class Participant
	{
		public int ParticipantID { get; set; }

        //FK: Person Table
		public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        //FK: Event Table
       /* public string EventID { get; set; }
        public virtual EventList EventList { get; set; }*/

        public bool HasAttended { get; set; }


		public string EventsID { get; set; }
        public virtual Event Event { get; set; }

		public DateTime? Timestamp { get; set; }
	}

	public class ParticipantPhoto
	{
		public int ParticipantPhotoID { get; set; }
		public string PhotoURL { get; set; }
		public int ParticipantID { get; set; }
		public virtual Participant Participant { get; set; }
	}
}