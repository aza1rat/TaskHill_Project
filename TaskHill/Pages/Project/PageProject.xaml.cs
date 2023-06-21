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

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProject.xaml
    /// </summary>
    public partial class PageProject : Page
    {
        private string _projectCode;
        public PageProject()
        {
            InitializeComponent();
            _projectCode = null;
            ButtonProjectAdd.Content = "Добавить";
            TextBoxProjectCode.IsEnabled = true;
        }

        public PageProject(string code, ProjectControl project)
        {
            InitializeComponent();
            _projectCode = code;
            ButtonProjectAdd.Content = "Изменить";
            TextBoxProjectCode.Text = _projectCode;
            TextBoxProjectCode.IsEnabled = false;
            TextBoxProjectName.Text = project.ProjectName;
            TextBoxProjectDescription.Document.Blocks.Add(new Paragraph(new Run(project.ProjectDescription)));
            ImageProjectLogotype.Source = project.ProjectLogotype;
        }

        private void ImageBackToCatalogue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ImageProjectLogotype_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageProjectLogotype.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private async void ProjectChange()
        {
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code", TextBoxProjectCode.Text },
                {"name", TextBoxProjectName.Text }
            };
            string description = new TextRange(TextBoxProjectDescription.Document.ContentStart, TextBoxProjectDescription.Document.ContentEnd).Text;
            if (!String.IsNullOrEmpty(description))
                jObject.Add("description", description);
            if (ImageProjectLogotype.Source.ToString() != "pack://application:,,,/Resources/avatarProfile.png")
            {
                BitmapImage bImage = (BitmapImage)ImageProjectLogotype.Source;
                MemoryStream ms = new MemoryStream();
                PngBitmapEncoder pngBitmap = new PngBitmapEncoder();
                pngBitmap.Frames.Add(BitmapFrame.Create(bImage));
                pngBitmap.Save(ms);
                string encodedImage = Convert.ToBase64String(ms.ToArray());
                jObject.Add("logotype", encodedImage);
            }
            Request request = new Request("/projects/method", jObject.ToString(), "POST");
            try
            {
                Response response = await request.Send();
            }
            catch
            {
                MessageBox.Show("Не удалось обновить проект");
            }
        }

        private async void ButtonProjectAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_projectCode != null)
            {
                ProjectChange();
                return;
            }
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code", TextBoxProjectCode.Text },
                {"name", TextBoxProjectName.Text }
            };
            string description = new TextRange(TextBoxProjectDescription.Document.ContentStart, TextBoxProjectDescription.Document.ContentEnd).Text;
            if (!String.IsNullOrEmpty(description))
                jObject.Add("description", description);
            if (ImageProjectLogotype.Source.ToString() != "pack://application:,,,/Resources/avatarProfile.png")
            {
                BitmapImage bImage = (BitmapImage)ImageProjectLogotype.Source;
                MemoryStream ms = new MemoryStream();
                PngBitmapEncoder pngBitmap = new PngBitmapEncoder();
                pngBitmap.Frames.Add(BitmapFrame.Create(bImage));
                pngBitmap.Save(ms);
                string encodedImage = Convert.ToBase64String(ms.ToArray());
                jObject.Add("logotype", encodedImage);
            }
            Request request = new Request("/projects/method", jObject.ToString(), "PUT");
            try
            {
                Response response = await request.Send();
                string code = response.Body["code"].ToString();
                TextBoxProjectCode.Text = code;
            }
            catch
            {
                MessageBox.Show("Не удалось добавить проект");
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
