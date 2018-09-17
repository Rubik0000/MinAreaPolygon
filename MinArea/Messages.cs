using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinArea
{
    //класс "Сообщения"
    class Messages
    {
        static public void ShowMessage(string mess)
        {
            MessageBox.Show(mess, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static public void ShowError(string mess)
        {
            MessageBox.Show(mess, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void ShowWarning(string mess)
        {
            MessageBox.Show(mess, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static public DialogResult InputQuery(string mess)
        {
            return MessageBox.Show(mess, "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }


    }
}
