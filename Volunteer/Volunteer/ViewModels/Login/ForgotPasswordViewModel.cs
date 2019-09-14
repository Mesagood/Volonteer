using Android.Widget;
using System;
using System.Net;
using Volunteer.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Volunteer.ViewModels.Login
{
    /// <summary>
    /// ViewModel for forgot password page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ForgotPasswordViewModel : LoginViewModel
    {
        #region Constructor
        public static int Code { get; set; }
        public static string EmailR { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForgotPasswordViewModel" /> class.
    /// </summary>
    public ForgotPasswordViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.SendCommand = new Command(this.SendClicked);
        }

        #endregion

        #region Command
        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        public Command SendCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Send button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SendClicked(object obj)
        {
            Random random = new Random();
            var code1 = random.Next(5, 100);
            string url = "http://v95289qa.beget.tech/Send.php?email="+Email+"&random="+code1;
            using (var web = new WebClient())
            {
                var client = web.DownloadString(url);
                EmailR = Email;
                Code = code1;
                Toast.MakeText(Android.App.Application.Context, "Код отправлен вам на почту.", ToastLength.Long).Show();
                Application.Current.MainPage.Navigation.PushAsync(new ResetPasswordPage());
            }
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        #endregion
    }
}