using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinArea
{
    /// <summary>
    /// User messages
    /// </summary>
    class Messages
    {
        static public void ShowMessage(string mess)
        {
            MessageBox.Show(mess, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static public void ShowError(string mess)
        {
            MessageBox.Show(mess, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void ShowWarning(string mess)
        {
            MessageBox.Show(mess, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static public DialogResult InputQuery(string mess)
        {
            return MessageBox.Show(mess, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
