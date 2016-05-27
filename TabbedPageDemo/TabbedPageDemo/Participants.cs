using System;
using System.Collections.Generic;

namespace HSE_APP
{
	public class Participant
	{
		public string name { get; set; }
		public string num_group { get; set; }
	}

	public class Participants
	{
		public IList<Participant> events { get; set; }
	}
}

