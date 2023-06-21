using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHill.ViewModels
{
    public class ViewTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ViewTask(int id, string name, string description, string status)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
        }
    }
}
