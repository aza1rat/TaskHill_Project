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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskHill.Classes;
using TaskHill.Controls;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
            ButtonRegister.Click += ButtonRegister_Click;
            ButtonLogIn.Click += ButtonLogIn_Click;
            TextBoxPassword.PasswordChanged += TextBoxPassword_PasswordChanged;
            
        }

        /*Вот тут костыль*/
        private void TextBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (passwordBox.Password == "")
                passwordBox.Tag = "Пароль";
            else
                passwordBox.Tag = "";
        }

        private async void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBoxLogin.Rule().IsNotNull().Validate())
                return;
            if (!TextBoxPassword.Rule().IsNotNull().Validate())
                return;
            JObject jObject = new JObject
            {
                { "user", TextBoxLogin.Text },
                { "password", TextBoxPassword.Password }
            };
            Request request = new Request("/sessions/method", jObject.ToString(), "PUT");
            Response response = null;
            try
            {
                response = await request.Send();
            }
            catch (Exception ex)
            {
                Logger.Write(new string[]
                {
                    ex.Message
                }, System.ConsoleColor.Magenta);
                TextBoxLogin.Rule().SetReason("Данные не прошли авторизацию").Validate();
                return;
            }
            if (response.Code == 200)
            {
                TextBoxLogin.Rule().Validate();
                Helper.SessionToken = response.Body["token"].ToString();
                Helper.SaveSession();
                MainWindow.StartMainWindow();
            }
            else
            {
                TextBoxLogin.Rule().SetReason("Данные не прошли авторизацию").Validate();
            }    
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageRegistration());
        }

        
    }
}
