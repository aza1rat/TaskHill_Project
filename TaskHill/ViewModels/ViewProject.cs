using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace TaskHill.ViewModels
{
    public class ViewProject
    {
        public BitmapImage Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public ViewProject (BitmapImage image, string name, string description)
        {
            Image = image;
            Name = name;
            Description = description;
        }

        public ViewProject (string name, string description, string code)
        {
            Name = name;
            Description=description;
            Code = code;
        }
    }
}
