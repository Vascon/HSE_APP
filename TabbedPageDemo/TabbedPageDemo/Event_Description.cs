using System;
using System.Collections.Generic;

namespace HSE_APP
{
	public class Event_Description
	{
		public string description { get; set; }
		public string picture { get; set; }
		public string time { get; set; }
		public string place { get; set; }
		public string name { get; set; }
	}

	public class Events_Description
	{
		public IList<Event_Description> events { get; set; }
	}

}

