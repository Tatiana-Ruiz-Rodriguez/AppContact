using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContact.ModelView;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContact.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ContactPageViewModel(Navigation);
		}
	}
}