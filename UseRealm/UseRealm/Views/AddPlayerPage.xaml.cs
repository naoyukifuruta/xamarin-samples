using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UseRealm.Models;
using UseRealm.ViewModels;

namespace UseRealm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlayerPage : ContentPage
    {
        private string _teamId;

        public AddPlayerPage(string teamId)
        {
            InitializeComponent();

            _teamId = teamId;
        }

        protected override void OnAppearing()
        {
            BindingContext = new AddPlayerViewModel(_teamId);
        }
    }
}
