using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppContact.Models;
using Xamarin.Forms;

namespace AppContact.ModelView
{
    public class ContactDetailPageViewModel
    {

        public Command  CurrentContacto { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation) {

            this.Navigation = navigation;
            CurrentContacto = new Contact();
            SaveContactCommand = new Command(async() => await SaveContact);
            DeleteContactCommand = new Command(async() => await DeleteContact)

        }

        private async Task SaveContact()
        {
            await (App.DataBase.SaveItemAsync(CurrentContacto));
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            await (App.DataBase.DeleteItemAsync(CurrentContacto));
            await Navigation.PopToRootAsync();
        }

    }
}
