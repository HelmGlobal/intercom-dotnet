using Newtonsoft.Json;
using Intercom.Converters.ClassConverters;

namespace Intercom.Data
{
	
	[JsonConverter(typeof(ConversationAppCountJsonConverter))]
	public class ConversationAppCount
	{
		public int closed { set; get; }
		public int open { set; get; }
		public int assigned { set; get; }
		public int unassigned { set; get; }

		public ConversationAppCount()
		{
		}
	}
}
