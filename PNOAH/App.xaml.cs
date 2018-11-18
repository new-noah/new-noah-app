using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

using PNOAH.Views.Pages;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PNOAH
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AnimalListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            AppCenter.Start("android=8011d2e1-9e2d-4bad-8069-d686596fcaff;" + "ios=a5abd485-21d7-4230-873d-399cabf53419", typeof(Analytics), typeof(Crashes), typeof(Distribute));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
