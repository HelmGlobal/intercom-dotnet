using Newtonsoft.Json;
using Intercom.Converters.ClassConverters;

namespace Intercom.Data
{
	[JsonConverter(typeof(CompanyCountJsonConverter))]
	public class CompanySegmentCount : SegmentCount
	{
		public CompanySegmentCount()
		{
		}
	}
}

