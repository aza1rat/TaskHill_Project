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
using TaskHill.Controls;
using TaskHill.ViewModels;

namespace TaskHill.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTestFrame.xaml
    /// </summary>
    public partial class PageTestFrame : Page
    {
        public PageTestFrame()
        {
            InitializeComponent();
            foreach (TaskControl task in StackPanelTask.Children)
            {
                task.MouseMove += Task_MouseMove;
            }
        }

        private void Task_MouseMove(object sender, MouseEventArgs e)
        {
            TaskControl task = sender as TaskControl;
            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(task, new DataObject(DataFormats.Serializable, task), DragDropEffects.Move);
        }

        private void StackPanelTask_Drop(object sender, DragEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;
            object dataTask = e.Data.GetData(DataFormats.Serializable);
            if (dataTask is UIElement element)
            {
                stackPanel.Children.Add(element);
            }
        }

        private void StackPanelTask_DragLeave(object sender, DragEventArgs e)
        {
            object dataTask = e.Data.GetData(DataFormats.Serializable);
            if (dataTask is UIElement element)
                {
                    StackPanelTask.Children.Remove(element);
                }
        }
    }
}
