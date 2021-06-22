﻿using System;
using Prism.Commands;
using Prism.Navigation;
using UsePrism.Conditions;
using UsePrism.Views;

namespace UsePrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
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

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ButtonC = new DelegateCommand(SetText);
            NextCommand = new DelegateCommand(PageBShow);

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
    }
}
