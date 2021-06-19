using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UseRealm.ViewModels;

namespace UseRealm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPlayerPage : ContentPage
    {
        private string _playerId;

        public EditPlayerPage(string playerId)
        {
            InitializeComponent();

            _playerId = playerId;
        }

        protected override void OnAppearing()
        {

            BindingContext = new EditPlayerViewModel(_playerId);
        }
    }
}
