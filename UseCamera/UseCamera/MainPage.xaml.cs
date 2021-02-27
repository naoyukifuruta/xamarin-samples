using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace UseCamera
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void PermissionButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("許可ボタンが押されました。");
            try
            {
                // Permission状態を取得
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    // 許可されていなければユーザーに許可してもらうためにPermissionのリクエストを行う。
                    status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera))[Permission.Camera];
                }
                if (status == PermissionStatus.Granted)
                {
                    Debug.WriteLine("許可されました。");
                }
                else
                {
                    Debug.WriteLine("許可されていません。");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PermissionButton_Clicked Error = " + ex.Message);
            }
        }
    }
}
