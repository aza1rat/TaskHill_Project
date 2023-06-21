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

namespace TaskHill.Controls
{
    /// <summary>
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public int TaskId { get; set; }
        public string NameOfTask { get; set; }
        public List<string> Categories { get; set; } = new List<string>() { "Не выпущена", "К выполнению", "Готово" };

        private string _code;

        public event EventHandler PerformerSelected;

        public TaskControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public TaskControl(string name, int id, string status, string code)
        {
            InitializeComponent();
            DataContext = this;
            NameOfTask = name;
            TaskId = id;
            if (status == "null")
                ComboBoxTaskStatus.SelectedIndex = 0;
            foreach (string category in Categories)
            {
                if (category == status)
                    ComboBoxTaskStatus.SelectedItem = status;
            }
            _code = code;
        }

        private async void ComboBoxTaskStatus_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTaskStatus.SelectedIndex < 0)
                return;
            JObject jsonStatus = new JObject()
            {
                {"token",Helper.SessionToken },
                {"code",_code },
                {"task_id",TaskId}
            };
            if (ComboBoxTaskStatus.SelectedIndex > 0)
                jsonStatus.Add("status", ComboBoxTaskStatus.SelectedIndex);
            Request request = new Request("/tasks/updateStatus", jsonStatus.ToString(), "POST");
            try
            {
                Response response = await request.Send();
            }
            catch
            {
                MessageBox.Show("Обновление статуса отклонено");
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PerformerSelected?.Invoke(sender, EventArgs.Empty);
        }
    }
}
