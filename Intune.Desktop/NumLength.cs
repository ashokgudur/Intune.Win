using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public static class NumLength
    {
        public static bool IsIntegerLong(TextBox textbox)
        {
            var result = false;
            var hasMinus = textbox.Text.Contains('-');
            var hasDecimal = textbox.Text.Contains('.');
            const int requiredLength = 10;

            if (!hasDecimal)
            {
                if (hasMinus)
                    result = (textbox.Text.Substring(1, textbox.TextLength - 1).Length == requiredLength);
                else
                    result = (textbox.Text.Substring(0, textbox.TextLength).Length == requiredLength);
            }
            else
            {
                if (hasMinus)
                {
                    if (textbox.SelectionStart < requiredLength + 2)
                        result = (textbox.Text.Substring(1, textbox.Text.IndexOf('.') - 1).Length == requiredLength);
                }
                else
                {
                    if (textbox.SelectionStart < requiredLength + 1)
                        result = (textbox.Text.Substring(0, textbox.Text.IndexOf('.')).Length == requiredLength);
                }
            }
            return result;
        }
    }
}
