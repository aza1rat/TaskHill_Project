using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TaskHill.ViewModels;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTask.xaml
    /// </summary>
    public partial class PageTask : Page
    {
        private string _code;
        private int taskPerformer = 0;
        private List<TaskControl> tasks = new List<TaskControl>();
        private List<ViewUser> users = new List<ViewUser>();
        public PageTask()
        {
            InitializeComponent();
        }

        public PageTask(string code, string name)
        {
            InitializeComponent();
            ProjectName.Text = name;
            this._code = code;
            CheckRole();
            UpdateTaskList();
        }

        private async void UpdateTaskList()
        {
            tasks.Clear();
            StackPanelSprint.Children.Clear();
            users.Clear();
            JObject jsonUpdateUsers = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",_code }
            };
            Request request = new Request("/projects/team", jsonUpdateUsers.ToString(), "POST");
            try
            {
                Response response = await request.Send();
                foreach (JObject jsonUser in response.BodyArray.Cast<JObject>())
                {
                    ViewUser viewUser = new ViewUser(
                        jsonUser["nickname"].ToString(),
                        jsonUser["lastname"].ToString(),
                        jsonUser["firstname"].ToString(),
                        jsonUser["patronymic"].ToString()
                    );
                    users.Add(viewUser);
                }
                ComboBoxPerformer.ItemsSource = users;
                ComboBoxPerformer.Items.Refresh();
            }
            catch
            {
                this.NavigationService.GoBack();
            }

            Request requestTask = new Request("/tasks/method", jsonUpdateUsers.ToString(), "POST");
            try
            {

                Response response = await requestTask.Send();
                foreach (JObject jsonSprint in response.BodyArray.Cast<JObject>())
                {
                    int taskCount = 0;
                    taskCount = jsonSprint["tasks"].Count();
                    DateTime dateStart = new DateTime(1, 1, 1);
                    DateTime dateEnd = new DateTime(1, 1, 1);
                    int sprintId = int.Parse(jsonSprint["id"].ToString());
                    string sprintName = jsonSprint["name"].ToString();
                    var dateStartValue = jsonSprint["date_start"];
                    var dateEndValue = jsonSprint["date_end"];
                    if (dateStartValue.Type != JTokenType.Null && dateEndValue.Type != JTokenType.Null)
                    {
                        dateStart = DateTime.Parse(dateStartValue.ToString());
                        dateEnd = DateTime.Parse(dateEndValue.ToString());
                    }
                    SprintControl sprint = new SprintControl(sprintId, sprintName, taskCount, dateStart, dateEnd);
                    Thickness margin = sprint.Margin;
                    margin.Left = margin.Top = margin.Right = margin.Bottom = 4;
                    sprint.Margin = margin;
                    sprint.StackPanelTask.Children.Clear();
                    if (jsonSprint["tasks"].HasValues)
                    {
                        sprint = AddElements(sprint, jsonSprint);
                    }
                    StackPanelSprint.Children.Add(sprint);
                }
                //Sprint.TaskCount = taskCount;
            }
            catch
            {
                this.NavigationService.GoBack();
            }
        }

        private SprintControl AddElements(SprintControl sprint, JObject jsonSprint)
        {
            foreach (JObject jsonTask in jsonSprint["tasks"].Cast<JObject>())
            {
                string name = jsonTask["name"].ToString();
                int id = int.Parse(jsonTask["local_id"].ToString());
                string status = null;
                if (jsonTask["status"].Type != JTokenType.Null)
                    status = jsonTask["status"].ToString();
                TaskControl task = new TaskControl(name, id, status, _code);
                task.PerformerSelected += Task_PerformerSelected;
                Thickness margin = task.Margin;
                margin.Left = margin.Top = margin.Right = margin.Bottom = 4;
                task.Margin = margin;
                sprint.StackPanelTask.Children.Add(task);

            }
            return sprint;
        }

        private void Task_PerformerSelected(object sender, EventArgs e)
        {
            Image performerAvatar = sender as Image;
            taskPerformer = int.Parse(performerAvatar.Tag.ToString());

        }

        private async void CheckRole()
        {
            JObject jsonCheckRole = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",_code }
            };
            Request request = new Request("/projects/role", jsonCheckRole.ToString(), "POST");
            try
            {
                Response response = await request.Send();
                string role = response.Body["role"].ToString();
                if (role == "Участник")
                {
                    ComboBoxPerformer.Visibility = Visibility.Collapsed;
                    TextBlockInputTask.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                this.NavigationService.GoBack();
            }
        }

        private void ImageBackToCatalogue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private async void TextBlockInputTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            string name = TextBlockInputTask.Text;
            JObject jsonTask = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",_code },
                {"name",name }
            };
            Request request = new Request("/tasks/method", jsonTask.ToString(), "PUT");
            try
            {
                Response response = await request.Send();
                UpdateTaskList();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить задачу");
            }
        }

        private async void ComboBoxPerformer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (taskPerformer <= 0)
                return;
            if (ComboBoxPerformer.SelectedIndex < 0)
                return;
            ViewUser viewUser = ComboBoxPerformer.SelectedItem as ViewUser;
            JObject jsonStatus = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",_code },
                {"task_id",taskPerformer },
                {"user",viewUser.Nickname }
            };
            Request request = new Request("/tasks/addPerformer", jsonStatus.ToString(), "PUT");
            try
            {
                Response response = await request.Send();
                UpdateTaskList();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить исполнителя");
            }
        }
    }
}