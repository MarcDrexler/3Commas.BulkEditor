using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Misc
{
    internal class TextBoxLogger : ILogger
    {
        private readonly TextBox txtOutput;

        public TextBoxLogger(TextBox txtOutput)
        {
            this.txtOutput = txtOutput;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = "";
            if (formatter != null)
            {
                message += formatter(state, exception);
            }

            txtOutput.AppendText($"{DateTime.Now} {logLevel}: {message}{Environment.NewLine}");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
