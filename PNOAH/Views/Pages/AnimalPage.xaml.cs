// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Views/Pages
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

using Newtonsoft;
using Newtonsoft.Json;
using PNOAH.Services;
using System.Threading.Tasks;
namespace PNOAH.Views.Pages
{
    public partial class SubmitAnimalPage : ContentPage
    {

        MediaFile _lastPhoto { get; set; }

        public SubmitAnimalPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void OnUploadClicked(object sender, EventArgs e)
        {

            if(_lastPhoto != null)
            {
                upphoto();
            }

        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            _lastPhoto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            if(_lastPhoto != null) photoHolder.Source = ImageSource.FromStream(_lastPhoto.GetStream);
        }

        async void upphoto()
        {
            await Upload(_lastPhoto);
            await DisplayAlert("Loading", "Animal added", "OK");
        }

        public  Task Upload(MediaFile mediaFile)
        {
            try
            {
                StreamContent scontent = new StreamContent(mediaFile.GetStream());

                scontent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = "avatar",
                    Name = "avatar"
                };
                scontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                var client = new HttpClient();
                var multi = new MultipartFormDataContent
                {
                    scontent
                };

                client.BaseAddress = new Uri(NOAHConst.BASE_SERVER);
                var result =  client.PostAsync( NOAHConst.UPLOAD, multi).Result;

                Debug.WriteLine(result.ReasonPhrase);
                var resstr = result.Content.ReadAsStringAsync();
                Debug.WriteLine( resstr.Result);
                return Task.CompletedTask;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Task.CompletedTask;
            }

        }
    }
}
