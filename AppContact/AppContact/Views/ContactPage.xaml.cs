using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContact.Views;
using AppContact.Models;
using AppContact.ModelView;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContact.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactPage : ContentPage
	{

        public ContactDetailPageViewModel ViewModel { get; set; }

        public ContactPage ()
		{
			InitializeComponent ();

            ViewModel = new ContactDetailPageViewModel(Navigation);
		}
	}
}