using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs_work
{
    class Alert
    {
        public static DialogResult ShowMessage(string messageText)
        {
            return MessageBox.Show(messageText, "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(string messageText)
        {
            return MessageBox.Show(messageText, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarning(string messageText)
        {
            return MessageBox.Show(messageText, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
