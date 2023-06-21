using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHill.ViewModels
{
    public class ViewUser
    {
        public string Nickname { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }

        public ViewUser(string nickname, string lastname, string firstname, string patronymic)
        {
            Nickname = nickname; Lastname = lastname; Firstname = firstname; Patronymic = patronymic;
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname + $" ({Nickname})";
        }
    }
}
