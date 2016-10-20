using System.Collections.Generic;

namespace Intercom.Data
{
	public class ConversationMessage : Message
	{
		public string subject { get; set; }
		public Author author { get; set; }
		public List<Attachment> attachments { get; set; }
		public object url { get; set; }
	}
}

