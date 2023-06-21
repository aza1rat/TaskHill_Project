using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
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

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageUpperMenu.xaml
    /// </summary>
    public partial class PageUpperMenu : Page
    {
        public PageUpperMenu()
        {
            InitializeComponent();
            this.Loaded += PageUpperMenu_Loaded;
        }

        private async void PageUpperMenu_Loaded(object sender, RoutedEventArgs e)
        {
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken }
            };
            Request request = new Request("/users/current", jObject.ToString(), "POST");
            Response response = null;
            try
            {
                response = await request.Send();
            }
            catch
            {
                ProjectWindow.CloseWindow();
                return;
            }
            string patronymic = response.Body["patronymic"].ToString() == "null" ? null : response.Body["patronymic"].ToString();
            string info = response.Body["nickname"].ToString() + "\n" + response.Body["lastname"].ToString() + "\n" + response.Body["firstname"].ToString();
            if (patronymic != null)
                info += "\n" + patronymic;
            if (response.Body["image"].ToString() == "null")
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/avatarProfile.png"));
                ImageAvatar.ImageSource = bitmapImage;
                return;
            }
            try
            {
                byte[] imageDecoded = Convert.FromBase64String(response.Body["image"].ToString());
                BitmapImage bImage = new BitmapImage();
                bImage.BeginInit();
                bImage.StreamSource = new MemoryStream(imageDecoded);
                bImage.EndInit();
                ImageAvatar.ImageSource = bImage;
            }
            catch
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/avatarProfile.png"));
                ImageAvatar.ImageSource = bitmapImage;
                return;
            }
            RectangleImageAvatar.ToolTip = info;
        }

        private void RectangleImageAvatar_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Helper.DropSession();
            ProjectWindow.CloseWindow();
        }
    }
}
