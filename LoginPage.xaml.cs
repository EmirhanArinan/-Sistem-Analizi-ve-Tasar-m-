using System;
using Microsoft.Maui.Controls;

namespace MobilSantiye
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // İstenilen kullanıcı adı ve şifre kontrolü
            if (username == "emir" && password == "123")
            {
                // Başarılı girişte doğrudan NavigationPage içinde MainPage'i açıyoruz
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                // Hatalı girişte uyarı
                await DisplayAlert("Hata", "Kullanıcı adı veya şifre yanlış!", "Tekrar Dene");

                // Şifre alanını temizle
                PasswordEntry.Text = string.Empty;
            }
        }
    }
}
