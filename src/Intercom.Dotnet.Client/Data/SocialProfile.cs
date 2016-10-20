using Intercom.Core;

namespace Intercom.Data
{
	public class SocialProfile : Model
	{
		public new string type { get; set; }
		public string username { get; set; }
		public string url { get; set; }
	}
}

