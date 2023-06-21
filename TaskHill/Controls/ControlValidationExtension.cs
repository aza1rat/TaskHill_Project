using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaskHill.Classes;

namespace TaskHill.Controls
{
    static class ControlValidationExtension
    {
        public static Validator Rule (this TextBox control)
        {
            return new Validator(control, control.Text, "myTB");
        }
        public static Validator Rule (this PasswordBox control)
        {
            return new Validator(control, control.Password, "myPB");
        }
    }
}
