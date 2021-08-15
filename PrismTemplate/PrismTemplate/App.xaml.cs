using Prism;
using Prism.Ioc;
using PrismTemplate.ViewModels;
using PrismTemplate.Views;
using Xamarin.Forms;

namespace PrismTemplate
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        protected override void OnStart() { }

        protected override void OnResume() { }

        protected override void OnSleep() { }
    }
}
