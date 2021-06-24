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

            QueryTest2();
        }

        private void QueryTest1()
        {
            var realm = Realm.GetInstance();

            //Realmデータベースのパスを出力
            Debug.WriteLine(realm.Config.DatabasePath);

            realm.Write(() =>
            {
                realm.Add(new Person { Name = "山田太郎", Age = 23 });
                realm.Add(new Person { Name = "佐藤花子", Age = 18 });
                realm.Add(new Person { Name = "田中哲朗", Age = 33 });
            });

            /** 検索 */

            //var people = realm.All<Person>().Where(p => p.Age > 20);
            //foreach (var person in people)
            //{
            //    Debug.WriteLine("Name=" + person.Name);
            //}

            /** 更新 */

            //１件目の山田さんのみ抽出
            var person = realm.All<Person>().Where(p => p.Name.Contains("山田")).FirstOrDefault<Person>();

            //プロパティにセットするだけでデータ更新される
            realm.Write(() =>
            {
                person.Age = 30;
            });

            var peoples = realm.All<Person>().Where(p => p.Age > 20);
            foreach (var per in peoples)
            {
                Debug.WriteLine("Name=" + per.Name + " Age=" + per.Age);
            }

            /** 削除 */
            person = realm.All<Person>().Where(p => p.Name.Contains("山田")).FirstOrDefault<Person>();
            realm.Write(() =>
            {
                realm.Remove(person);
            });
        }

        private void QueryTest2()
        {
            var realm = Realm.GetInstance();

            //Realmデータベースのパスを出力
            Debug.WriteLine(realm.Config.DatabasePath);

            using (var trans = realm.BeginWrite())
            {
                try
                {
                    realm.Add(new Person { Name = "山田太郎", Age = 23 });
                    realm.Add(new Person { Name = "佐藤花子", Age = 18 });
                    realm.Add(new Person { Name = "田中哲朗", Age = 33 });
                    //throw new Exception("Fail!");
                    trans.Commit();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("データ更新に失敗しました。" + ex.Message);
                    trans.Rollback();
                }

            }
        }
    }
}
