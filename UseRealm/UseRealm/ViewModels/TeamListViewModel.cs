using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using UseRealm.Models;
using UseRealm.Views;

namespace UseRealm.ViewModels
{
    public class TeamListViewModel : BaseViewModel
    {
        private ObservableCollection<Team> allTeams;
        public ObservableCollection<Team> AllTeams
        {
            get { return allTeams; }
            set
            {
                allTeams = value;
            }
        }

        public ICommand AddTeamCommand { get; private set; }

        public TeamListViewModel()
        {

            Realm context = Realm.GetInstance();

            AllTeams = new ObservableCollection<Team>(context.All<Team>());

            AddTeamCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddTeamPage()));
        }
    }
}
