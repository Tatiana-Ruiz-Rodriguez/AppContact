namespace AppContact
{
    using System;
    using System.Diagnostics;
    using Xamarin.Forms;
    using AppContact.Data;
    using AppContact.Views;
    using AppContacts.Services;

    public partial class App : Application
    {
        private static ContactsDataBase database;

        public static ContactsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        database = new ContactsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contacts.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                }
                return database;
            }

            set { Database = value; }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ContactsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
