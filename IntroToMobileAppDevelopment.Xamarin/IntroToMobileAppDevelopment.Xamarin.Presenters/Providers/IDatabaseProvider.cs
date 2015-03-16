using System;
using System.Collections.Generic;

namespace IntroToMobileAppDevelopment.Xamarin.Presenters
{
	public interface IDatabaseProvider
	{
		void CreateDatabase();
		void AddRecord<T> (T record);
		void AddNumber (string number);
		IEnumerable<IRandomEntry> GetNumbers ();
	}
}

