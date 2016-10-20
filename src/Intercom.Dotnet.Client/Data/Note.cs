using Intercom.Core;

namespace Intercom.Data
{
	public class Note : Model
	{
		public int? created_at { get; set; }
		public string body { get; set; }
		public Admin author { get; set; }
		public User user { get; set; }

		public Note()
		{
		}
	}
}
