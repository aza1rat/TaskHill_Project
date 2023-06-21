using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskHill.Classes;
using TaskHill.Controls;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
            ButtonNewRegister.Click += ButtonNewRegister_Click;
            ButtonToKeepRegistration.Click += ButtonToKeepRegistration_Clcik;
        }

        /*Много повторений*/
        private async Task<bool> CanRegister()
        {
            if (!TextBoxUserEmail.Rule().IsNotNull().Validate())
                return false;
            if (!TextBoxUserLogin.Rule().IsNotNull().Validate())
                return false;
            if (!TextBoxUserPassword.Rule().IsNotNull().Validate())
                return false;
            if (!TextBoxUserPassword.Rule().Matches(TextBoxUserPassword2.Password).Validate())
                return false;
            JObject jObject = new JObject
            {
                { "user", TextBoxUserLogin.Text },
                { "email", TextBoxUserEmail.Text },
                { "password", TextBoxUserPassword.Password }
            };
            Request request = new Request("/users/method", jObject.ToString(), "PUT");
            Response response = await request.Send();
            if (response.Code == 200)
            {
                TextBoxUserLogin.Rule().Validate();
                TextBoxUserEmail.Rule().Validate();
                TextBoxUserPassword.Rule().Validate();
                TextBoxUserPassword2.Rule().Validate();
                Helper.SessionToken = response.Body["token"].ToString();
                return true;
            }
            else
            {
                TextBoxUserLogin.Rule().SetReason("Проверьте данные для регистрации").Validate();
                TextBoxUserEmail.Rule().SetReason("Проверьте данные для регистрации").Validate();
                return false;
            }
        }

        private async void ButtonNewRegister_Click(object sender, RoutedEventArgs e)
        {
            bool canRegister = await CanRegister();
            if (canRegister)
            {
                MainWindow.StartMainWindow();
            }

        }

        private async void ButtonToKeepRegistration_Clcik(object sender, RoutedEventArgs e)
        {
            bool canRegister = await CanRegister();
            if (canRegister)
            {
                this.NavigationService.Navigate(new PageKeepRegistration());
            }
        }

        private void TextBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (passwordBox.Password == "")
                passwordBox.Tag = "Пароль";
            else
                passwordBox.Tag = "";
        }

        private void ImageBackToLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
