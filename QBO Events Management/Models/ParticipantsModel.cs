using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBO_Events_Management.Models
{
	public class Participant
	{
		public int ParticipantID { get; set; }
		public string PersonID { get; set; }
		public bool HasAttended { get; set; }
		public string Email { get; set; }
		public int EventsID { get; set; }
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