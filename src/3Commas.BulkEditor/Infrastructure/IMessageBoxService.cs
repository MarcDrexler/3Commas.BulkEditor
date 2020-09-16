using System.Windows.Forms;

namespace _3Commas.BulkEditor.Infrastructure
{
    public interface IMessageBoxService
    {
        DialogResult ShowError(string text, string title = "Error");
        DialogResult ShowQuestion(string text);
        DialogResult ShowInformation(string text);
    }
}