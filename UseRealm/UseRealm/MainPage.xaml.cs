using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Realms;
using System.Collections.ObjectModel;

namespace UseRealm
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> items = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();

            // Realmから登録されたItemオブジェクトを取り出してソートする
            var realm = Realm.GetInstance();
            var allItems = realm.All<Item>().OrderByDescending((arg) => arg.TimeString);

            // データソースに時刻を追加する
            foreach (var i in allItems)
            {
                items.Add(i.TimeString);
            }
            listView.ItemsSource = items;
        }

        public void AddAction(object sender, System.EventArgs e)
        {
            var time = DateTime.UtcNow.ToString("HH:mm:ss");

            // RealmにItemオブジェクトを追加する
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(new Item { TimeString = time });
            });

            // ListViewの先頭にも時刻を表示させる
            items.Insert(0, time);
        }
    }
}
