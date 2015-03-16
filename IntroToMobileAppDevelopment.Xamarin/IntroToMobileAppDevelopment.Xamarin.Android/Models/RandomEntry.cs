using System;
using SQLite;
using IntroToMobileAppDevelopment.Xamarin.Presenters;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{


	[Table("RandomEntry")]
	public class RandomEntry  : IRandomEntry
	{
		[PrimaryKey,AutoIncrement]
		public int Key {get;set;}

		public string RandomNumber {get;set;}

		public DateTime DateAdded { get; set;}

		public RandomEntry ()
		{
			this.DateAdded = DateTime.Now;
		}
	}
}

