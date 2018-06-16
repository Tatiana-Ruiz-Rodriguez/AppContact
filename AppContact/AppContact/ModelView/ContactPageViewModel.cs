using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AppContact.Helpers;
using AppContact.Models;
using AppContact.ModelView;
using Xamarin.Forms;
using AppContact.Views;

namespace AppContact.ModelView
{
    public class ContactPageViewModel
    {

        public ObservableCollection<Grouping<string, Contact>> ContactLists { get; set; }

        public Command AddContactCommand { get; set; } 

        public INavigation Navigation { get; set; }

        public ContactPageViewModel()
        {
            Task.Run(async () => ContactLists = await App
            .DataBase.GetAllGrouped().Wait());

            AddContactCommand = new Command(
                
                async () => await GoToDetailContact()

                );
        }

        private async GoToDetailContact()
        {
            await.Navigation.PushAsync(new ContactPage());
        }

    }
}
