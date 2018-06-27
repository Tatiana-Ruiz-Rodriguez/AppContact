namespace AppContact.ModelView
{
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using AppContact.Models;

    public class ContactDetailPageViewModel
    {
        public Contact CurrentContact { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }
        
        public ContactDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CurrentContact = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
        }

        public async Task SaveContact()
        {
            await App.Database.SaveItemAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }
    }

   
    
}
