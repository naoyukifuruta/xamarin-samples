using System;
using UseRealm.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UseRealm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TeamsListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
