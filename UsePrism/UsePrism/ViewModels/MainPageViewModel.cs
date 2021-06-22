using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Mvvm;
using UsePrism.Conditions;
using UsePrism.Views;
using UsePrism.Objects;

namespace UsePrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService;
        private IDevice _device;

        private string _labelC = string.Empty;
        public string LabelC
        {
            get { return _labelC; }
            set
            {
                SetProperty(ref _labelC, value);
            }
        }

        public DelegateCommand ButtonC { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand MessageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDevice device)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _device = device;

            ButtonC = new DelegateCommand(SetText);
            NextCommand = new DelegateCommand(PageBShow);
            MessageCommand = new DelegateCommand(MessageShow);

            Title = "Main Page";
            LabelC = "DDD";
        }

        private void SetText()
        {
            LabelC = "EEE";
        }

        private void PageBShow()
        {
            var param = new NavigationParameters();
            param.Add(nameof(PageBCondition), new PageBCondition("XXXX", "TEST"));

            NavigationService.NavigateAsync(nameof(PageBView), param);
        }

        private async void MessageShow()
        {
            var result = await _pageDialogService.DisplayAlertAsync("たいとる", "めっせーじ", "OK", "キャンセル");

            if (result)
            {
                // OKの時の処理
            }
            else
            {
                // キャンセルの時の処理
            }

            Title = _device.GetDeviceName();
        }
    }
}
