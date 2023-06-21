using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
using TaskHill.Properties;

namespace TaskHill
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            try
            {
                Helper.LoadSession();
                if (Helper.SessionToken != null)
                    StartMainWindow();
            }
            catch
            {

            }
        }

        public static async void StartMainWindow()
        {
            JObject keys = new JObject()
            {
                {"token",Helper.SessionToken }
            };
            Request request = new Request("/sessions/method",keys.ToString(), "POST");
            try
            {
                Response response = await request.Send();
            }
            catch
            {
                return;
            }
            ProjectWindow projectWindow = new ProjectWindow();
            mainWindow.Close();
            projectWindow.ShowDialog();
        }
    }
}
