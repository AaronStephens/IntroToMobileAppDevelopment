
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IntroToMobileAppDevelopment.Xamarin.Presenters;
using TinyIoC;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{
	[Activity (Label = "RandomListActivity", Icon="@drawable/icon")]			
	public class RandomListActivity : ListActivity
	{
		private IDatabaseProvider _dbProvider;
		private string[] items;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			_dbProvider = TinyIoCContainer.Current.Resolve<IDatabaseProvider> ();

			DisplayNumberList ();
		}

		public void DisplayNumberList()
		{
			items = _dbProvider.GetNumbers().Cast<RandomEntry> ().Select(t => t.RandomNumber).ToArray();
			ListAdapter = new ArrayAdapter<String>(this, 17367043, items);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			var number = items [id];
			Toast.MakeText (this, string.Format("Your number is {0}",number), ToastLength.Short).Show ();
		}
	}
}

