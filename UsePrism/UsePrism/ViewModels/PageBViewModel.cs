using System;
using Prism.Commands;
using Prism.Navigation;

namespace UsePrism.ViewModels
{
    public class PageBViewModel : ViewModelBase
    {
        public PageBViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Page B";
        }
    }
}
