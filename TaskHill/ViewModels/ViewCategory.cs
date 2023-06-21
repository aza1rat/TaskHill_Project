using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TaskHill.ViewModels
{
    public class ViewCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public ViewCategory(int id,string name,string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
