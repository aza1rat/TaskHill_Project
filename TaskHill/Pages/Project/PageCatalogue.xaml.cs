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
using System.Windows.Shell;
using TaskHill.Classes;
using TaskHill.ViewModels;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCatalogue.xaml
    /// </summary>
    public partial class PageCatalogue : Page
    {
        private List<ProjectControl> viewProjects = new List<ProjectControl>();
        private List<ViewCategory> viewCategories = new List<ViewCategory>();
        public PageCatalogue()
        {
            InitializeComponent();
            UpdateCategories();
        }

        private async void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCategory.SelectedItem == null)
                return;
            if (ComboBoxCategory.SelectedIndex == 0)
            {
                await RequestAllProject();
                return;
            }
            if (ComboBoxCategory.SelectedIndex == ComboBoxCategory.Items.Count - 1)
            {
                this.NavigationService.Navigate(new PageCategory());
                ComboBoxCategory.SelectedIndex = 0;
                return;
            }
            ViewCategory selectedCategory = (ViewCategory) ComboBoxCategory.SelectedItem;
            int categoryId = selectedCategory.Id;
            await RequestSort(categoryId);
            
        }

        private async void UpdateCategories()
        {
            viewCategories.Clear();
            viewCategories.Add(new ViewCategory(-1, "Все", "Фильтр отключен"));
            JObject jCategory = new JObject()
            {
                { "token",Helper.SessionToken }
            };
            Request requestGetCategory = new Request("/categories/my", jCategory.ToString(), "POST");
            Response responseGetCategory;
            try
            {
                responseGetCategory = await requestGetCategory.Send();
            }
            catch
            {
                ProjectWindow.CloseWindow();
                return;
            }
            foreach (JObject categoryJSON in responseGetCategory.BodyArray.Cast<JObject>())
            {
                int id = int.Parse(categoryJSON["id"].ToString());
                string category = categoryJSON["category"].ToString();
                string description = categoryJSON["description"].ToString();
                ViewCategory viewCategory = new ViewCategory(id, category, description);
                viewCategories.Add(viewCategory);
            }
            viewCategories.Add(new ViewCategory(-2, "Управление категориями", "Управление"));
            ComboBoxCategory.ItemsSource = viewCategories;
            ComboBoxCategory.SelectedIndex = 0;
        }

        private async Task<bool> RequestAllProject()
        {
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken }
            };
            Request request = new Request("/projects/my", jObject.ToString(), "POST");
            Response response;
            try
            {
                response = await request.Send();
            }
            catch
            {
                ProjectWindow.CloseWindow();
                return false;
            }
            UpdateCatalogue(response);
            return true;
        }

        private async Task<bool> RequestSort(int categoryId)
        {
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken },
                {"categoryid", categoryId}
            };
            Request request = new Request("/projects/my/sort", jObject.ToString(), "POST");
            Response response;
            try
            {
                response = await request.Send();
            }
            catch
            {
                ProjectWindow.CloseWindow();
                return false;
            }
            UpdateCatalogue(response);
            return true;
        }

        private void UpdateCatalogue(Response response)
        {
            viewProjects.Clear();
            foreach (JObject projectJSON in response.BodyArray.Cast<JObject>())
            {
                string name = projectJSON["name"].ToString();
                string description = projectJSON["description"].ToString();
                string image = projectJSON["logotype"].ToString();
                string code = projectJSON["code"].ToString();
                BitmapImage bImage;
                if (String.IsNullOrEmpty(description))
                    description = null;
                if (String.IsNullOrEmpty(image))
                {
                    bImage = new BitmapImage(new Uri("pack://application:,,,/Resources/avatarProfile.png"));
                }
                else
                {
                    byte[] imageDecoded = Convert.FromBase64String(image);
                    bImage = new BitmapImage();
                    bImage.BeginInit();
                    bImage.StreamSource = new MemoryStream(imageDecoded);
                    bImage.EndInit();
                }
                ProjectControl projectControl = new ProjectControl(name, code, description, bImage);
                projectControl.ProjectChanged += ProjectControl_ProjectChanged;
                
                viewProjects.Add(projectControl);
                
            }
            ListViewProject.ItemsSource = viewProjects;
            
            ListViewProject.Items.Refresh();
        }

        private void ProjectControl_ProjectChanged(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ProjectControl selectedProject = null;
            foreach(ProjectControl project in viewProjects)
            {
                if (project.ProjectCode == menuItem.Tag.ToString())
                {
                    selectedProject = project;
                    break;
                } 
            }
            this.NavigationService.Navigate(new PageProject(menuItem.Tag.ToString(),selectedProject));
        }

        private async void ProjectControl_ProjectDrop(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            string projectCode = menuItem.Tag.ToString();
            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить проект с кодом {projectCode} ? Вск задачи и участники будут удалены из проекта!",
                "Удаление проекта", MessageBoxButton.YesNo, MessageBoxImage.Stop);
            if (result == MessageBoxResult.Yes)
            {
                JObject jObject = new JObject()
                {
                    {"token",Helper.SessionToken },
                    { "code",projectCode}
                };
                Request request = new Request("/projects/method", jObject.ToString(), "DELETE");
                try
                {
                    Response response = await request.Send();
                }
                catch
                {
                    MessageBox.Show("Не удалось удалить проект");
                }
            }
            await RequestAllProject();
        }

        private void ButtonAddProject_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageProject());
        }

        private void ListViewProject_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProjectControl project = ListViewProject.SelectedItem as ProjectControl;
            if (project == null)
                return;
            this.NavigationService.Navigate(new PageTask(project.ProjectCode, project.ProjectName));
        }

       
    }
}
