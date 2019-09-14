using Android.Widget;
using Newtonsoft.Json;
using System.Net;
using Volunteer.Commands;
using Volunteer.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Volunteer.ViewModels.Login
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields
        public int id;
        private string name;

        private string password;
        private string surname;
        private string patronymic;
        private string age;
        private string country;
        private string phone;
        private string login;
        private string skills;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.OnPropertyChanged();
            }
        }
        public string Surname
        {
            get
            {
                return this.surname;
            }

            set
            {
                if (this.surname == value)
                {
                    return;
                }

                this.surname = value;
                this.OnPropertyChanged();
            }
        }
        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }

            set
            {
                if (this.patronymic == value)
                {
                    return;
                }

                this.patronymic = value;
                this.OnPropertyChanged();
            }
        }
        public string Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.age == value)
                {
                    return;
                }

                this.age = value;
                this.OnPropertyChanged();
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                if (this.country == value)
                {
                    return;
                }

                this.country = value;
                this.OnPropertyChanged();
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (this.phone == value)
                {
                    return;
                }

                this.phone = value;
                this.OnPropertyChanged();
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                if (this.login == value)
                {
                    return;
                }

                this.login = value;
                this.OnPropertyChanged();
            }
        }
        public string Skills
        {
            get
            {
                return this.skills;
            }

            set
            {
                if (this.skills == value)
                {
                    return;
                }

                this.skills = value;
                this.OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password confirmation from users in the Sign Up page.
        /// </summary>


        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            /*string lastId = "http://v95289qa.beget.tech/Last.php?last";
            id = 0;
            using (var last = new WebClient())
            {
                var response = last.DownloadString(lastId);
                var json = JsonConvert.DeserializeObject<Person>(response);
                id = json.VolunteerID + 1;

            }*/
            string surname = ConvertURL.Convert(Surname);
            string name = ConvertURL.Convert(Name);
            string patronymic = ConvertURL.Convert(Patronymic);
            string phone = ConvertURL.Convert(Phone);
            string login = ConvertURL.Convert(Login);
            string password = ConvertURL.Convert(Password);
            string email = ConvertURL.Convert(Email);
            string age = ConvertURL.Convert(Age);
            string country = ConvertURL.Convert(Country);
            string skills = ConvertURL.Convert(Skills);
            if (Surname != string.Empty && Name != string.Empty && Patronymic != string.Empty && Phone != string.Empty && Login != string.Empty && Password != string.Empty && Email != string.Empty&&Age!=string.Empty&&Country!=string.Empty)
            {
                string url = "http://v95289qa.beget.tech/ValidationLogin.php?login="+login;
                using (var web = new WebClient())
                {
                    var response = web.DownloadString(url);
                    var json = JsonConvert.DeserializeObject<Auth>(response);
                    if (json.Login != null)
                    {
                        Toast.MakeText(Android.App.Application.Context, "Введенный вами логин занят.", ToastLength.Long).Show();
                        return;
                    }
                    else
                    {
                        string reg = "http://v95289qa.beget.tech/CreateVolunteer.php?id=" + id + "&surname=" + surname + "&name=" + name + "&patr=" + patronymic + "&age=" + age + "&country=" + country + "&login=" + login + "&phone=" + login + "&skills=" + skills + "&pass=" + password;
                        using (var webClient = new WebClient())
                        {
                            var respons = webClient.DownloadString(reg);
                            Toast.MakeText(Android.App.Application.Context, "Вы успешно зарегистрированы.", ToastLength.Long).Show();
                        }
                    }
                }

            }
            else
            {
                return;
            }
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }

    #endregion
}