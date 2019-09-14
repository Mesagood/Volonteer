using Android.Widget;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Volunteer.Commands;
using Volunteer.Model.Navigation;
using Volunteer.Models.Navigation;
using Volunteer.ViewModels.Login;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Volunteer.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationTileCardPage
    {
        public string Message { get; set; }
        public NavigationTileCardPage()
        {
            this.InitializeComponent();
            Load();
            Organization();
        }
        public void Load()
        {
            DateTime dt = DateTime.Now;
            string url = "http://v95289qa.beget.tech/Select.php?all";

            using (var web = new WebClient())
            {
                var response = web.DownloadString(url);
                response = response.Replace("[", "").Replace("]", "");
                var list = Json.FromDelimitedJson<Orders>(new StringReader(response)).ToList();                
                foreach (var item in list)
                {
                    if (dt>item.DateFrom)
                    {
                        string delete = "http://v95289qa.beget.tech/Delete.php?id=" + item.ApplicationOrganizationID;
                        using (var webClient = new WebClient())
                        {
                               var query = webClient.DownloadString(delete);
                        }
                    }
                }
                Stack.ItemsSource = list.Select(x => "Начало практики: " + x.DateTo + "\n" + "Конец практики: " + x.DateFrom + "\n" + "Почта: " + x.AdditionalInformation + "\n" + "Необходимые умения: " + x.NecessarySkills);
            }
        }
        public void Organization()
        {
            string url = "http://v95289qa.beget.tech/SelectOrganization.php?all";
            using (var web = new WebClient())
            {
                var response = web.DownloadString(url);
                response = response.Replace("[", "").Replace("]", "");
                var list = Json.FromDelimitedJson<OrganizationClass>(new StringReader(response)).ToList();
                OrganizationList.ItemsSource = list.Select(x => "Название: " + x.OrganizationName + "\n" + "Телефон: " + x.OrganizationPhoneNUmber + "\n" + "Адресс: " + x.OrganizationAddress + "\n" + "Информация: " + x.OrganizationFieldActivity);
            }
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            string url = "http://v95289qa.beget.tech/SendApp.php?email=" + Message + "&message=" + MessageEntry.Text;
            using (var web = new WebClient())
            {
                var client = web.DownloadString(url);
                Toast.MakeText(Android.App.Application.Context, "Заявка отправлена организатору.", ToastLength.Long).Show();
            }
        }

        private void Stack_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (e.ItemData != null)
            {
                string str = string.Empty;
                str = e.ItemData.ToString();
                string[] mass = str.Split(':');
                Message = mass[7].Replace("Необходимые умения","");
            }
                
        }
    }
}