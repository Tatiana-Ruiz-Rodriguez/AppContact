using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppContact.Views;

using Xamarin.Forms;

namespace AppContact
{
    using AppContact.Data;
    using AppContacts.Services;
    using System.Diagnostics;

	public partial class App : Application
	{

        private ContactsDataBase dataBase;

        public ContactsDataBase DataBase
        {
            get
            {

                if(dataBase == null){

                    try
                    {
                        dataBase = new ContactsDataBase(DependencyService.Get<IFileHelper>()
                            .GetLocalFilePath("Contacts.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message); 
                    }
                }

                return dataBase;
            }
        }


        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ContactPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
