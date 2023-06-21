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
using TaskHill.Pages;

namespace TaskHill
{
    /// <summary>
    /// Логика взаимодействия для ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private static ProjectWindow projectWindow;
        public ProjectWindow()
        {
            InitializeComponent();
            projectWindow = this;
        }

        public static void CloseWindow()
        {
            MainWindow mainWindow = new MainWindow();
            projectWindow.Close();
            mainWindow.ShowDialog();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FlowPanel.Visibility = Visibility.Collapsed;
            FrameProjectAdd.Source = null;
        }
    }
}
