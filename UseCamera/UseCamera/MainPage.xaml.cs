using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
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

        // 参考
        //[Obsolete]
        //private async void PermissionButton_Clicked(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("許可ボタンが押されました。");
        //    try
        //    {
        //        // Permission状態を取得
        //        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //        if (status != PermissionStatus.Granted)
        //        {
        //            // 許可されていなければユーザーに許可してもらうためにPermissionのリクエストを行う。
        //            status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera))[Permission.Camera];
        //        }
        //        if (status == PermissionStatus.Granted)
        //        {
        //            Debug.WriteLine("許可されました。");
        //        }
        //        else
        //        {
        //            Debug.WriteLine("許可されていません。");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("PermissionButton_Clicked Error = " + ex.Message);
        //    }
        //}

        /// <summary>
        /// 写真撮影ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureButton_Clicked(object sender, System.EventArgs e)
        {
            // 初期化処理
            await CrossMedia.Current.Initialize();

            // カメラが使用可能、かつ写真が撮影可能かを判定する。
            if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            // メディアオプション（保存先ディレクトリ、画像ファイル名を設定）
            var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PictureTest", // 保存先ディレクトリ
                Name = $"{DateTime.UtcNow}.jpg" // 保存ファイル名
            };

            // 写真撮影
            var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

            // キャンセルが押された場合
            if (file == null)
            {
                return;
            }

            // await DisplayAlert("画像ファイルの保存先", file.Path, "OK");
            // Image領域に撮影した画像を表示する。
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void albumButton_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!Plugin.Media.CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            {
                return;
            }

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}
