using System;

namespace IntroToMobileAppDevelopment.Xamarin.Presenters
{
	public interface IRandomEntry
	{
		int Key {get;set;}
		string RandomNumber {get;set;}
		DateTime DateAdded {get;set;}
	}
}

