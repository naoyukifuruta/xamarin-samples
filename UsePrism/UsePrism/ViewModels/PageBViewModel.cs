using System;
using Prism.Commands;
using Prism.Navigation;

namespace UsePrism.ViewModels
{
    public class PageBViewModel : ViewModelBase
    {
        public PageBViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        // 画面遷移時
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters["title"].ToString();
        }
    }
}
