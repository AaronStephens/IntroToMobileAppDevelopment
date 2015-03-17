using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace IntroToMobileAppDevelopment.Xamarin.Presenters
{
	public interface IMainPagePresenter
	{
		void SetView(IMainPageView view) ;

	}

	public class MainPagePresenter : IMainPagePresenter
	{
		private IMainPageView _view;
		private IDatabaseProvider _dbProvider;

		public MainPagePresenter (IDatabaseProvider databaseProvider)
		{
			_dbProvider = databaseProvider;
		}

		public void SetView(IMainPageView view) 
		{
			_view = view;
			_view.OnGetANumberClicked += HandleOnGetANumberClicked;
		}

		protected async void HandleOnGetANumberClicked (object sender, EventArgs e)
		{
			string resultJson = "-1";

			//Get the number
			var client = new HttpClient (new ModernHttpClient.NativeMessageHandler ());
			client.DefaultRequestHeaders.Accept.TryParseAdd ("application/json");
			resultJson = await client.GetStringAsync ("http://introtomobileappdevelopment.azurewebsites.net/api/RandomNumber");

			var result = JsonConvert.DeserializeObject<RandomNumberResult>(resultJson);
			_view.DisplayNumberMessage(new MainPageModel() { NumberMessage = "Your number is\n" + result.Result.ToString() });

			_dbProvider.AddNumber (result.Result.ToString());

			_view.DisplayNumberList ();
		}
	}
}

