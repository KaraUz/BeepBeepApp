using System;
using Parse;
using System.Collections.Generic;

namespace BeepBeep
{
	public static class CurrentUser
	{
		public static string Name{ get; set;}
		public static double LitersMon{ get; set;}
		public static double LitersAll{ get; set;}
		public static double SpentMon{ get; set;}
		public static double SpentAll{ get; set;}
		public static long LastMileage{ get; set;}
		public static long Mileage{ get; set;}
		private static IEnumerable<ParseObject> results;

		public static void GetCurrentUser(string id) 
		{
			GetCurrentUsernFromParse (id);
			foreach (ParseObject po in results)
			{
				Name = po.Get<string> ("Name");
				LitersMon = po.Get<double> ("LitersMon");
				LitersAll = po.Get<double> ("LitersAll");
				SpentMon = po.Get<double> ("SpentMon");
				SpentAll = po.Get<double> ("SpentAll");
				LastMileage = po.Get<long> ("LastMileage");
				Mileage = po.Get<long> ("Mileage");
			}
		}

		private static async void GetCurrentUsernFromParse(string id) 
		{
			var query = ParseObject.GetQuery ("Users").WhereContains("Name",id);
			results = await query.FindAsync ();
		}
	}
}

