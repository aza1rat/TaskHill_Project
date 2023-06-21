using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageKeepRegistration.xaml
    /// </summary>
    public partial class PageKeepRegistration : Page
    {
        public PageKeepRegistration()
        {
            InitializeComponent();
            ButtonRegister.Click += ButtonRegister_Click;
        }

        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBoxLastName.Rule().IsNotNull().Validate())
                return;
            if (!TextBoxFirstName.Rule().IsNotNull().Validate())
                return;
            JObject jObject = new JObject
            {
                { "token", Helper.SessionToken },
                { "lastname", TextBoxLastName.Text },
                { "firstname", TextBoxFirstName.Text }
            };
            if (!String.IsNullOrEmpty(TextBoxPatronymic.Text))
                jObject.Add("patronymic", TextBoxPatronymic.Text);
            if (ImageAvatar.Source.ToString() != "pack://application:,,,/Resources/avatarProfile.png")
            {
                BitmapImage bImage = (BitmapImage)ImageAvatar.Source;
                MemoryStream ms = new MemoryStream();
                PngBitmapEncoder pngBitmap = new PngBitmapEncoder();
                pngBitmap.Frames.Add(BitmapFrame.Create(bImage));
                pngBitmap.Save(ms);
                string encodedImage = Convert.ToBase64String(ms.ToArray());
                jObject.Add("image", encodedImage);

            }
            Request request = new Request("/users/method", jObject.ToString(), "POST");
            this.IsEnabled = false;
            Response response = await request.Send();
            this.IsEnabled = true;
            if (response.Code == 200)
            {
                TextBoxLastName.Rule().Validate();
                TextBoxFirstName.Rule().Validate();
                TextBoxPatronymic.Rule().Validate();
                MainWindow.StartMainWindow();
            }
            else
            {
                TextBoxLastName.Rule().SetReason("Данные не прошли регистрацию").Validate();
                TextBoxFirstName.Rule().SetReason("Данные не прошли регистрацию").Validate();
                TextBoxPatronymic.Rule().SetReason("Данные не прошли регистрацию").Validate();
            }
        }

        private void ImageAvatar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageAvatar.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void ImageBackToLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             NavigationService.GoBack();
        }
    }
}
