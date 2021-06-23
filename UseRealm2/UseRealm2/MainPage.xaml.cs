using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;

namespace UseRealm2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var realm = Realm.GetInstance();

            //Realmデータベースのパスを出力
            Debug.WriteLine(realm.Config.DatabasePath);

            realm.Write(() =>
            {
                realm.Add(new Person { Name = "山田太郎", Age = 23 });
                realm.Add(new Person { Name = "佐藤花子", Age = 18 });
                realm.Add(new Person { Name = "田中哲朗", Age = 33 });
            });

            var people = realm.All<Person>().Where(p => p.Age > 20);

            foreach (var person in people)
            {
                Debug.WriteLine("Name=" + person.Name);
            }
        }
    }
}
