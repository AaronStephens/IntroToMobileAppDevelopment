using System;
using SQLite;
using IntroToMobileAppDevelopment.Xamarin.Presenters;
using System.Collections.Generic;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{
	public class DatabaseProvider : IDatabaseProvider
	{

		public void CreateDatabase()
		{
			var conn = new SQLiteConnection(System.IO.Path.Combine (path, databaseName));
			conn.CreateTable<RandomEntry>();
		}

		public void AddRecord<T>(T record)
		{
			var conn = new SQLiteConnection(System.IO.Path.Combine (path, databaseName));
			conn.Insert (record);
		}

		public void AddNumber(string number)
		{
			RandomEntry record = new RandomEntry ();
			record.RandomNumber = number;
			this.AddRecord (record);
		}

		public IEnumerable<IRandomEntry> GetNumbers()
		{
			var conn = new SQLiteConnection(System.IO.Path.Combine (path, databaseName));
			IEnumerable<RandomEntry> ret = conn.Table<RandomEntry> ().OrderByDescending(i => i.DateAdded);
			return ret;
		}

		private string databaseName = "RandomNunmbers.db";
		private string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);

		public DatabaseProvider ()
		{

		}
	}
}

