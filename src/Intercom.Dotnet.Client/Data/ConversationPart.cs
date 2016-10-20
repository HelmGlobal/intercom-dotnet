﻿using Intercom.Core;
using System.Collections.Generic;

namespace Intercom.Data
{
	public class ConversationPart : Model
	{
		public string part_type { get; set; }
		public string body { get; set; }
		public int created_at { get; set; }
		public int updated_at { get; set; }
		public int notified_at { get; set; }
		public object assigned_to { get; set; }
		public Author author { get; set; }
		public List<Attachment> attachments { get; set; }
	}
}

