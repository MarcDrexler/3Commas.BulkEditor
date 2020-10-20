using System.Windows.Forms;

namespace _3Commas.BulkEditor.Infrastructure
{
    public class MessageBoxService : IMessageBoxService
    {
        public DialogResult ShowError(string text, string title = "Error")
        {
            return MessageBox.Show(Form.ActiveForm, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowQuestion(string text)
        {
            return MessageBox.Show(Form.ActiveForm, text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult ShowInformation(string text)
        {
            return MessageBox.Show(Form.ActiveForm, text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
