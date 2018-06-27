using Xamarin.Forms;

namespace AppContact.ModelView
{
    internal class ContactPageViewModel
    {
        private INavigation navigation;

        public ContactPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}