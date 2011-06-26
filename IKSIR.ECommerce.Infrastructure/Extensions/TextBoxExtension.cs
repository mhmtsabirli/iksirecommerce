using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.Infrastructure.Extensions
{
    public static class TextBoxExtension
    {
        public static void ClearText(this TextBox textBox)
        {
            textBox.Text = string.Empty;
        }

        public static DateTime ToDateTime(this TextBox textBox)
        {
            return Convert.ToDateTime(textBox.Text);
        }

        public static int ToInt32(this TextBox textBox)
        {
            return Convert.ToInt32(textBox.Text);
        }
    }
}
