﻿using System;
using Intercom.Core;
using System.Collections.Generic;

namespace Intercom.Data
{
	public class Company : Model
	{
		public bool? remove { set; get; }
		public string name { get; set; }
		public Plan plan { get; set; }
		public string company_id { get; set; }
		public int? remote_created_at { get; set; }
		public int? created_at { get; set; }
		public int? updated_at { get; set; }
		public int? last_request_at { get; set; }
		public int? monthly_spend { get; set; }
		public int? session_count { get; set; }
		public int? user_count { get; set; }
		public Dictionary<String, Object> custom_attributes { get; set; }
	}
}
