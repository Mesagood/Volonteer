using Android.Widget;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using Volunteer.Commands;
using Volunteer.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Volunteer.ViewModels.Login
{
    /// <summary>
    /// ViewModel for reset password page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ResetPasswordViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string newPassword;

        private string confirmPassword;
        public string Code { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordViewModel" /> class.
        /// </summary>
        public ResetPasswordViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Submit button is clicked.
        /// </summary>
        public Command SubmitCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Public property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the new password from user in the reset password page.
        /// </summary>
        public string NewPassword
        {
            get
            {
                return this.newPassword;
            }

            set
            {
                if (this.newPassword == value)
                {
                    return;
                }

                this.newPassword = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the new password confirmation from the user in the reset password page.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }

                this.confirmPassword = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the Submit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SubmitClicked(object obj)
        {
            ConvertURL.Convert(NewPassword);
            var code = ForgotPasswordViewModel.Code;
            var email = ForgotPasswordViewModel.EmailR;
            var password = ConvertURL.Convert22(NewPassword);
            email = ConvertURL.Convert22(email);
            if (Code == code.ToString())
            {
                if (NewPassword == ConfirmPassword)
                {
                    string url = "http://v95289qa.beget.tech/UpdateVolunteer.php?email=" + email + "&password=" + password;
                    using (var web = new WebClient())
                    {
                        var response = web.DownloadString(url);
                        Toast.MakeText(Android.App.Application.Context, "Пароль успешно восстановлен.", ToastLength.Long).Show();
                        Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
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