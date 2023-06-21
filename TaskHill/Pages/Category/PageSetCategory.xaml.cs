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
    /// Логика взаимодействия для PageSetCategory.xaml
    /// </summary>
    public partial class PageSetCategory : Page
    {
        public List<ViewCategory> Categories { get; set; } = new List<ViewCategory>();
        private List<ViewProject> projects { get; set; } = new List<ViewProject>();
        public PageSetCategory()
        {
            InitializeComponent();
            this.Loaded += PageSetCategory_Loaded;
        }

        private void PageSetCategory_Loaded(object sender, RoutedEventArgs e)
        {
             UpdateCategories();
             LoadProjects();
        }

        public async void LoadProjects()
        {
            projects.Clear();
            Response response = await UpdateProjects();
            foreach (JObject jProject in response.BodyArray.Cast<JObject>())
            {
                string name = jProject["name"].ToString();
                string code = jProject["code"].ToString();
                ViewProject viewProject = new ViewProject(name, null, code);
                projects.Add(viewProject);
            }
            DataGridProject.ItemsSource = projects;
            DataGridProject.Items.Refresh();
        }

        public async void UpdateCategories()
        {
            JObject jObject = new JObject()
            {
                {"token",Helper.SessionToken }
            };
            Request requestCategory = new Request("/categories/my", jObject.ToString(), "POST");
            try
            {
                Response responseCategory = await requestCategory.Send();
                JArray jCategories = responseCategory.BodyArray;
                Categories.Clear();
                Categories.Add(new ViewCategory(-1, "Нет категории", "Нет категории"));
                foreach (JObject jCategory in jCategories.Cast<JObject>())
                {
                    int id = int.Parse(jCategory["id"].ToString());
                    string name = jCategory["category"].ToString();
                    string description = jCategory["description"].ToString();
                    ViewCategory viewCategory = new ViewCategory(id, name, description);
                    Categories.Add(viewCategory);
                }
                DataGridComboBoxColumn dCombo = (DataGridComboBoxColumn) DataGridProject.Columns[2];
                dCombo.ItemsSource = Categories;
                DataGridProject.Columns[2] = dCombo;
            }
            catch
            {
                ProjectWindow.CloseWindow();
            }
        }

        public async Task<Response> UpdateProjects()
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
                return response;
            }
            catch
            {
                ProjectWindow.CloseWindow();
            }
            return null;
        }

        public async void ClearCategory(string code)
        {
            JObject jClearCategory = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",code}
            };
            Request requestClearCategory = new Request("/projects/my/removeCategory", jClearCategory.ToString(), "DELETE");
            try
            {
                Response responseClearCategory = await requestClearCategory.Send();
                MessageBox.Show("У проекта удалена категория");
            }
            catch
            {
                return;
            }
        }

        public async void SetCategory(string code, int categoryId)
        {
            JObject jSetCategory = new JObject()
            {
                {"token",Helper.SessionToken },
                {"categoryid",categoryId },
                {"code",code}
            };
            Request requestSetCategory = new Request("/projects/my/setCategory",jSetCategory.ToString(), "POST");
            try
            {
                Response responseSetCategory = await requestSetCategory.Send();
                MessageBox.Show("Проекту назначена категория");
            }
            catch
            {
                return;
            }
        }

        private void DataGridProject_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DataGridProject.SelectedIndex < 0)
                return;
            int x = e.Column.DisplayIndex;
            if (x < 2)
                return;
            ComboBox comboBox = (ComboBox)e.EditingElement;
            if (comboBox.SelectedItem == null)
                return;
            ViewCategory viewCategory = (ViewCategory) comboBox.SelectedItem;
            ViewProject viewProject = (ViewProject)DataGridProject.SelectedItem;
            if (comboBox.SelectedIndex == 0)
            {
                ClearCategory(viewProject.Code);
                return;
            }
            SetCategory(viewProject.Code, viewCategory.Id);
        }
    }
}
