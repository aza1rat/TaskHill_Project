using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskHill.Properties;
using Brushes = System.Windows.Media.Brushes;

namespace TaskHill.Classes
{
    class Validator
    {
        private readonly Control control;
        private readonly string input;
        private readonly string styleName;
        private string reason;
        private bool success = true;
        public Validator(Control control, string input, string styleName)
        {
            this.control = control;
            this.input = input;
            this.styleName = styleName;
        }

        public Validator Matches(string value)
        {
            if (input != value)
            {
                success = false;
                reason = "Данные должны совпадать";
            }
            return this;
        }

        public Validator IsNotNull()
        {
            if (String.IsNullOrEmpty(input))
            {
                success = false;
                reason = "Не допускается пустое значение";
            }
            return this;
        }

        public Validator SetReason(string reason)
        {
            success = false;
            this.reason = reason;
            return this;
        }

        public bool Validate()
        {
            if (success == false)
            {
                control.ToolTip = reason;
                control.BorderBrush = Brushes.Red;
            }
            else
            {
                control.ToolTip = null;
                control.Style = (Style) Application.Current.Resources[styleName];
            }
            return success;
        }
    }
}
