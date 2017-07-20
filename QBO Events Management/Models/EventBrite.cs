﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace QBO_Events_Management.Models
{
	public class EventBrite
	{
		[JsonProperty("events")]
		public List<EventList> Events { get; set; }

		[JsonProperty("attendees")]
		public List<AttendeeList> Attendees { get; set; }

    }

	public class EventList
		{
			[JsonProperty("id")]
			public string ID { get; set; }

			[JsonProperty("name")]
			public Name Names { get; set; }

			[JsonProperty("url")]
			public string URL { get; set; }

			[JsonProperty("description")]
			public Description Descriptions { get; set; }

			[JsonProperty("start")]
			public Start Start { get; set; }

			[JsonProperty("end")]
			public End End { get; set; }

			[JsonProperty("created")]
			public DateTime Created { get; set; }

			[JsonProperty("changed")]
			public DateTime Changed { get; set; }

			[JsonProperty("status")]
			public String Status { get; set; }

			[JsonProperty("capacity")]
			public String Tickets { get; set; }

			[JsonProperty("logo")]
			public Orig Images { get; set; }
        }

		public class Name
			{
				[JsonProperty("text")]
				//[Display(Name = "Name")]
				public String Text { get; set; }
			}

		public class Description
			{
				[JsonProperty("text")]
				public String Text { get; set; }
			}

		public class Start
			{
				[JsonProperty("local")]
				public DateTime Local { get; set; }
			}

		public class End
			{
				[JsonProperty("local")]
				public DateTime Local { get; set; }
			}

		public class Orig
		{
			[JsonProperty("original")]
			public ImageUrl Original { get; set; }
		
		}

		public class ImageUrl
		{
			[JsonProperty("url")]
			public string ImgUrl { get; set; }
		}







	public class AttendeeList
	{
		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("profile")]
		public Profile Profiles { get; set; }

		[JsonProperty("resource_uri")]
		public string Uri { get; set; }

		[JsonProperty("created")]
		public string DateRegistered { get; set; }

	}

	public class Profile
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	
	}


