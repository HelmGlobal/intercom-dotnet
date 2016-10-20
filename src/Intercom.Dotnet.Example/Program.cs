using System;
using Intercom.Clients;
using Intercom.Core;
using Intercom.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var usersClient = new UsersClient(new Authentication("dG9rOmU5N2U0YmEzX2VlMThfNGRjNl84NWJmX2I2ZDM5Yjk2MTk5NzoxOjA="));
			var user = usersClient.View(new User { user_id = args[0] });
			foreach (var pair in JObject.Parse(JsonConvert.SerializeObject(user)))
				Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
		}
	}
}
