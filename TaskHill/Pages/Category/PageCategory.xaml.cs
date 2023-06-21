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
using TaskHill.ViewModels;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCategory.xaml
    /// </summary>
    public partial class PageCategory : Page
    {
        public PageCategory()
        {
            InitializeComponent();
            ButtonToEditCategory.Click += ButtonToEditCategory_Click;
            ButtonToSetCategory.Click += ButtonToSetCategory_Click;
            FrameCategory.JournalOwnership = JournalOwnership.OwnsJournal;
            ButtonToEditCategory.IsEnabled = false;
        }

        private void ButtonToSetCategory_Click(object sender, RoutedEventArgs e)
        {
            if (FrameCategory.Content.ToString().Contains("PageEditCategory"))
            {
                FrameCategory.Navigate(new PageSetCategory());
                ButtonToEditCategory.IsEnabled = true;
                ButtonToSetCategory.IsEnabled = false;
            }
                
        }

        private void ButtonToEditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (FrameCategory.CanGoBack)
            {
                FrameCategory.GoBack();
                ButtonToSetCategory.IsEnabled = true;
                ButtonToEditCategory.IsEnabled = false;
            }
                
        }

        private void ImageBackToCatalogue_MouseLeftButtonDown(object sender,EventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
