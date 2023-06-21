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

namespace TaskHill.Controls
{
    /// <summary>
    /// Логика взаимодействия для SprintControl.xaml
    /// </summary>
    
    public partial class SprintControl : UserControl
    {
        public int TaskCount { get; set; }
        public int SprintId { get; set; }
        public string SprintName { get; set; }
        public DateTime DateStart { get; set; } 
        public DateTime DateEnd { get; set; }
        public string SprintDates { get; set; }

        public SprintControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public SprintControl(int sprintId, string sprintName, int taskCount)
        {
            InitializeComponent();
            DataContext = this;
            SprintId = sprintId;
            SprintName = sprintName;
            TaskCount = taskCount;
        }

        public SprintControl(int sprintId, string sprintName, int taskCount, DateTime dateStart, DateTime dateEnd)
        {
            InitializeComponent();
            DataContext = this;
            SprintId = sprintId;
            SprintName = sprintName;
            TaskCount = taskCount;
            if (dateStart.Year != 1 && dateEnd.Year != 1)
            {
                DateStart = dateStart;
                DateEnd = dateEnd;
                SprintDates = dateStart.ToShortDateString() + "-" + dateEnd.ToShortDateString();
            }
            
        }
    }
}
