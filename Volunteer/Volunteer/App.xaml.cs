using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Volunteer
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = App.BaseImageUrl + "https://raw.githubusercontent.com/sumathij/essential-ui-kit-for-xamarin.forms/master/Images/";
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTMzMDk0QDMxMzcyZTMyMmUzMFJja1VMd1B2enU2YkpFWk95bVBMeTRoYWtGdk9zNzVFa3lxai84SS9DT009");
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
