using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace UsePopupPagePlugin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void ClickPopupShowButton(object o, EventArgs e)
        {
            var page = new PopupTestPage();
            await PopupNavigation.Instance.PushAsync(page);
            await Task.Delay(5000);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
