using System;
using Parse;
using System.Collections.Generic;

namespace BeepBeep
{
	public class Station
	{
		public string Brand{ get; set;}
		public string Address{ get; set;}
		public ParseGeoPoint Location{ get; set;}
		public double Price95{ get; set;}
		public double Price98{ get; set;}
		public double PriceD{ get; set;}
		public double PriceGas{ get; set;}
		public double PriceE{ get; set;}
		public double PriceDz{ get; set;}
		private static IEnumerable<ParseObject> results;

		public Station() 
		{

		}
		public Station(string brand, string address,ParseGeoPoint location, double price95, 
			double price98, double priceD, double priceGas,double priceE,double priceDz) 
		{
			Brand=brand;
			Address=address;
			Location=location;
			Price95 = price95;
			Price98 = price98;
			PriceD = priceD;
			PriceGas = priceGas;
			PriceE = priceE;
			PriceDz = priceDz;

		}


		public static List<Station> GetStations(ParseGeoPoint location, double radius) 
		{
			List<Station> temp = new List<Station>();
			GetStationFromParse (location, radius);
			foreach (ParseObject po in results)
			{
				temp.Add(new Station(po.Get<string>("Brand"),po.Get<string>("Address"),po.Get<ParseGeoPoint>("Location"),
					po.Get<double>("Price95"),po.Get<double>("Price98"),po.Get<double>("PriceD"),po.Get<double>("PriceGas"),
					po.Get<double>("PriceE"),po.Get<double>("PriceDz")));
			}
				return temp;

		}

		private static async void GetStationFromParse(ParseGeoPoint location, double radius) 
		{
			double lat = location.Latitude;
			double lon = location.Longitude;
			ParseGeoPoint userLocation = new ParseGeoPoint(lat,lon);
			var query = ParseObject.GetQuery ("Station").WhereWithinDistance ("Location", userLocation,
				ParseGeoDistance.FromKilometers (radius));
			results = await query.FindAsync ();
		}


	}
}

