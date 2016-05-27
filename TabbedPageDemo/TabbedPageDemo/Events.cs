using System;
using System.Collections.Generic;

namespace HSE_APP
{
	public class Event
	{
		public string game { get; set; }
		public string id { get; set; }
		public string time { get; set; }
		public string picture { get; set; }
	}

	public class Events
	{
		public IList<Event> events { get; set; }
	}


}
	
