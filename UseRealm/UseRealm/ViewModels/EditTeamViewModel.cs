﻿using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using UseRealm.Models;

namespace UseRealm.ViewModels
{
    public class EditTeamViewModel : BaseViewModel
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string manager;
        public string Manager
        {
            get { return manager; }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        private string stadiumName;
        public string StadiumName
        {
            get { return stadiumName; }
            set
            {
                stadiumName = value;
                OnPropertyChanged("StadiumName");
            }
        }

        public ICommand SaveTeamCommand { get; private set; }

        private string _teamId;

        public EditTeamViewModel(string teamId)
        {

            Realm context = Realm.GetInstance();

            var team = context.Find<Team>(teamId);
            _teamId = team.TeamId;

            Title = team.Title;
            Manager = team.Manager;
            StadiumName = team.StadiumName;
            City = team.City;

            SaveTeamCommand = new Command(SaveTeam);
        }

        async void SaveTeam()
        {

            Realm context = Realm.GetInstance();

            var team = context.Find<Team>(_teamId);

            context.Write(() => {

                team.Title = Title;
                team.Manager = Manager;
                team.StadiumName = StadiumName;
                team.City = City;

                context.Add<Team>(team, update: true);
            });

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
