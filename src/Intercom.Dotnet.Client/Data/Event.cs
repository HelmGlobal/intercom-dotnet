using Intercom.Core;

namespace Intercom.Data
{
	public class Event : Model
	{
		public string event_name { get; set; }
		public long? created_at { get; set; }
		public string user_id { get; set; }
		public string email { get; set; }

		#if !NET_STANDARD
		[JsonConverter(typeof(MetadataJsonConverter))]
		public Metadata metadata { get; set; }
		#endif

		public Event()
		{
		}
	}
}
