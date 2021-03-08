using System;
using Prism.Navigation;

namespace UsePrism.ViewModels
{
    public class MainPageViewModel
    {
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
