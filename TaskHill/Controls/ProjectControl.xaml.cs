using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TaskHill
{
    /// <summary>
    /// Логика взаимодействия для ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {

        public BitmapImage ProjectLogotype { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectCode { get; set; }

        //public delegate void ProjectChangedHandler(string code);

        public event EventHandler ProjectChanged;

        public event EventHandler ProjectDrop;

        public ProjectControl()
        {
            InitializeComponent();
        }

        public ProjectControl(string name, string code, string description=null, BitmapImage image=null)
        {
            InitializeComponent();
            DataContext = this;
            ProjectName = name;
            ProjectCode = code;
            if (description != null)
                ProjectDescription = description;
            if (image != null)
                ProjectLogotype = image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button extra = sender as Button;
            ContextMenu menu = extra.ContextMenu;
            menu.PlacementTarget = extra;
            menu.IsOpen = true;
        }

        private void MenuItemChange_Click(object sender, RoutedEventArgs e)
        {
            ProjectChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            ProjectDrop?.Invoke(sender, EventArgs.Empty);
        }



        //private void MenuItemChange_Click(object sender, RoutedEventArgs e)
        //{
        //    MenuItem menuItem = sender as MenuItem;
        //    if (menuItem.Header.ToString() == "Изменить")
        //    {
        //        ProjectChangedHandler handler = ProjectChanged;
        //        handler?.Invoke("code");
        //    }

        //}
    }
}
