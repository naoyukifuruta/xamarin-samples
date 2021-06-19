using System;
using System.Collections.Generic;

using Xamarin.Forms;
using UseRealm.ViewModels;

namespace UseRealm.Views
{
    public partial class EditTeamPage : ContentPage
    {
        private string _teamId;

        public EditTeamPage(string teamId)
        {
            InitializeComponent();
            _teamId = teamId;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new EditTeamViewModel(_teamId);
        }
    }
}
