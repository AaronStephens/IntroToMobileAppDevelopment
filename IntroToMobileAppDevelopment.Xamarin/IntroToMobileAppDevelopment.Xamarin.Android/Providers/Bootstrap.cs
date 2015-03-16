using System;
using TinyIoC;
using IntroToMobileAppDevelopment.Xamarin.Presenters;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{
	public class Bootstrap
	{
		private static Bootstrap _instance;
		public static Bootstrap Instance 
		{
			get {
				if (_instance == null) {
					_instance = new Bootstrap ();
				}
				return _instance;
			}
		}

		public Bootstrap ()
		{
		}

		public void Register()
		{
			TinyIoCContainer.Current.Register<IDatabaseProvider,DatabaseProvider>().AsSingleton();
			TinyIoCContainer.Current.Register<IMainPagePresenter,MainPagePresenter> ().AsSingleton ();
		}
	}
}

