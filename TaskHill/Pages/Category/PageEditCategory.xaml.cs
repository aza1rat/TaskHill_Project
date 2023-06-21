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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskHill.Classes;
using TaskHill.ViewModels;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditCategory.xaml
    /// </summary>
    public partial class PageEditCategory : Page
    {
        private List<ViewCategory> _categoriees = new List<ViewCategory>();
        public PageEditCategory()
        {
            InitializeComponent();
            this.Loaded += PageEditCategory_Loaded;
            
        }

        private async void PageEditCategory_Loaded(object sender, RoutedEventArgs e)
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
                _categoriees.Clear();
                foreach (JObject jCategory in jCategories.Cast<JObject>())
                {
                    int id = int.Parse(jCategory["id"].ToString());
                    string name = jCategory["category"].ToString();
                    string description = jCategory["description"].ToString();
                    ViewCategory viewCategory = new ViewCategory(id, name, description);
                    _categoriees.Add(viewCategory);
                }
                DataGridCategory.ItemsSource = _categoriees;
                DataGridCategory.Items.Refresh();
            }
            catch
            {
                ProjectWindow.CloseWindow();
            }
        }

        private async void HyperLinkDelete_Click(object sender, RoutedEventArgs e)
        {
            bool isDeleted;
            ViewCategory viewCategory = (ViewCategory)DataGridCategory.SelectedItem;
            isDeleted = await DeleteCategory(viewCategory.Id);
            if (isDeleted)
                PageEditCategory_Loaded(null, null);
        }

        private void HyperLinkChange_Click(object sender, RoutedEventArgs e)
        {
            ButtonCategoryChanging.Content = "Изменить";
            ButtonCategoryCancel.Visibility = Visibility.Visible;
            ViewCategory viewCategory = (ViewCategory)DataGridCategory.SelectedItem;
            TextBoxCategoryName.Text = viewCategory.Name;
            TextBoxCategoryDescription.Text = viewCategory.Description;
        }

        private async Task<bool> AddCategory(string name, string description = null)
        {
            JObject jAddCategory = new JObject()
            {
                { "token",Helper.SessionToken },
                { "categoryname", name}
            };
            if (description != null)
                jAddCategory.Add("categorydescription", description);
            Request requestAddCategory = new Request("/categories/method", jAddCategory.ToString(), "PUT");
            try
            {
                Response response = await requestAddCategory.Send();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateCategory(int id, string name, string description = null)
        {
            JObject jChangeCategory = new JObject()
            {
                { "token",Helper.SessionToken },
                { "categoryid", id},
                { "categoryname", name}
            };
            if (description != null)
                jChangeCategory.Add("categorydescription", description);
            Request requestChangeCategory = new Request("/categories/method", jChangeCategory.ToString(), "POST");
            try
            {
                Response response = await requestChangeCategory.Send();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> DeleteCategory(int id)
        {
            JObject jDeleteCategory = new JObject()
            {
                { "token",Helper.SessionToken },
                { "categoryid", id}
            };
            Request requestDeleteCategory = new Request("/categories/method", jDeleteCategory.ToString(), "DELETE");
            try
            {
                Response response = await requestDeleteCategory.Send();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void ButtonCategoryChanging_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonCategoryChanging.Content.ToString() == "Добавить")
            {
                bool isAdded;
                if (!String.IsNullOrEmpty(TextBoxCategoryDescription.Text))
                    isAdded = await AddCategory(TextBoxCategoryName.Text, TextBoxCategoryDescription.Text);
                else
                    isAdded = await AddCategory(TextBoxCategoryName.Text);
                if (isAdded)
                {
                    PageEditCategory_Loaded(null, null);
                }
                return;
            }
            if (ButtonCategoryChanging.Content.ToString() == "Изменить")
            {
                ViewCategory viewCategory = (ViewCategory) DataGridCategory.SelectedItem;
                bool isChanged;
                if (!String.IsNullOrEmpty(TextBoxCategoryDescription.Text))
                    isChanged = await UpdateCategory(viewCategory.Id, TextBoxCategoryName.Text, TextBoxCategoryDescription.Text);
                else
                    isChanged = await UpdateCategory(viewCategory.Id, TextBoxCategoryName.Text);
                if (isChanged)
                {
                    PageEditCategory_Loaded(null, null);
                }
                return;
            }
                
        }

        private void ButtonCategoryCancel_Click(object sender, RoutedEventArgs e)
        {
            ButtonCategoryChanging.Content = "Добавить";
            ButtonCategoryCancel.Visibility = Visibility.Hidden;
        }
    }
}
