using UseRealm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UseRealm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamPage : ContentPage
    {
        public AddTeamPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new AddTeamViewModel();
            base.OnAppearing();
        }
    }
}
