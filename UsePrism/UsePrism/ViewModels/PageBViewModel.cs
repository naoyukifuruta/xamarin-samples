using System;
using Prism.Commands;
using Prism.Navigation;
using UsePrism.Conditions;

namespace UsePrism.ViewModels
{
    public class PageBViewModel : ViewModelBase
    {
        private string _labelG = string.Empty;
        public string LabelG
        {
            get { return _labelG; }
            set
            {
                SetProperty(ref _labelG, value);
            }
        }

        public PageBViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        // 画面遷移時
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var val = parameters[nameof(PageBCondition)] as PageBCondition;
            if (val == null)
            {
                throw new ArgumentException(nameof(PageBCondition));
            }

            Title = val.Title;
            LabelG = val.LabelG;
        }
    }
}
