using System;
using System.Windows.Forms;
using _3Commas.BulkEditor.Misc;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ChooseSignal
{
    public partial class ChooseSignal : Form
    {
        private BotStrategy _strategy;

        public ChooseSignal()
        {
            InitializeComponent();

            ControlHelper.AddValuesToCombobox<TradingViewTime>(cmbTradingViewTime);
            ControlHelper.AddValuesToCombobox<TradingViewIndicatorType>(cmbTradingViewType);
            ControlHelper.AddValuesToCombobox<IndicatorTime>(cmbRsiTime);
        }

        public BotStrategy Strategy => _strategy;

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            panelRsi.Visible = (sender == radioButtonRsi);
            panelTradingView.Visible = (sender == radioButtonTradingView);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (radioButtonRsi.Checked)
            {
                if (cmbRsiTime.SelectedItem == null)
                {
                    MessageBox.Show("Time is missing");
                    return;
                }

                IndicatorTime.TryParse(cmbRsiTime.SelectedItem.ToString(), out IndicatorTime time);
                _strategy = new RsiBotStrategy() {Options = new RsiOptions(time, (int) numRsiPoints.Value)};
            }

            if (radioButtonTradingView.Checked)
            {
                if (cmbTradingViewTime.SelectedItem == null)
                {
                    MessageBox.Show("Time is missing");
                    return;
                }
                if (cmbTradingViewType.SelectedItem == null)
                {
                    MessageBox.Show("Type is missing");
                    return;
                }

                TradingViewTime.TryParse(cmbTradingViewTime.SelectedItem.ToString(), out TradingViewTime time);
                TradingViewIndicatorType.TryParse(cmbTradingViewType.SelectedItem.ToString(), out TradingViewIndicatorType type);
                _strategy = new TradingViewBotStrategy() { Options = new TradingViewOptions(type, time) };
            }

            if (radioButtonManual.Checked) _strategy = new ManualStrategy();
            if (radioButtonNonstop.Checked) _strategy = new NonStopBotStrategy();

            this.DialogResult = DialogResult.OK;
        }
    }
}
