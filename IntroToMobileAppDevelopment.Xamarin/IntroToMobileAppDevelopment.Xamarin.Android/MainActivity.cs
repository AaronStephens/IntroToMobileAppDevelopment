﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IntroToMobileAppDevelopment.Xamarin.Presenters;
using TinyIoC;
using Xamarin;
using System.Linq;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{
	[Activity (Label = "Random Numbers", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IMainPageView
	{
		private Button btnGetANumber;
		private Button btnShowHistory;
		private TextView tvNumberMessage;
		private ListView lstPreviousNumbers;
		private IMainPagePresenter _presenter;
		private IDatabaseProvider _dbProvider;
		private string[] items;
		private ArrayAdapter ListAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Insights.Initialize("3323c8f77ac284ecb3e7a708f387c2c2344875f0", ApplicationContext);
			/*
			 * Insights.Track("QuestCompleted", new Dictionary<string, string> { { "Quest", CurrentQuest.ToString() } });
			 * Insights.Report(exception, new Dictionary <string, string> { {"Event Id", "00113"}, {"Other Data", "Goes Here"} });
			 */

			Bootstrap.Instance.Register ();
			_dbProvider = TinyIoCContainer.Current.Resolve<IDatabaseProvider> ();
			_dbProvider.CreateDatabase ();

			SetContentView (Resource.Layout.Main);

			_presenter = TinyIoCContainer.Current.Resolve<IMainPagePresenter> ();
			_presenter.SetView (this);

			btnGetANumber = FindViewById<Button> (Resource.Id.btnGetANumber);
			tvNumberMessage = FindViewById<TextView> (Resource.Id.tvNumberMessage);
			btnShowHistory = FindViewById<Button> (Resource.Id.btnShowHistory);

			btnShowHistory.Click += (object sender, EventArgs e) => {
				ShowHistory();
			};
			btnGetANumber.Click += (object sender, EventArgs e) => {
				if (OnGetANumberClicked != null)
					OnGetANumberClicked(this, EventArgs.Empty);
			};
		}

		#region IMainPageView implementation

		public event EventHandler OnGetANumberClicked;

		public void DisplayNumberMessage (MainPageModel model)
		{
			tvNumberMessage.Text = model.NumberMessage;
		}

		public void ShowHistory()
		{
			var intent = new Intent (this,typeof(RandomListActivity));
			StartActivity (intent);
		}

		#endregion
	}
}


