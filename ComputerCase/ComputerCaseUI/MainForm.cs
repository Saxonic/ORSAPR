using ComputerCase;
using System;
using System.Drawing;
using System.Windows.Forms;
using ComputerCase.Exceptions;

namespace ComputerCaseUI
{
    public partial class MainForm : Form
    {
        private Color errorTextBoxColor = Color.LightSalmon;
        private Color successTextBoxColor = Color.PaleGreen;
        private CaseParameters _caseParameter;

        public MainForm()
        {
            InitializeComponent();
            _caseParameter = new CaseParameters();
            
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse(HeightTextBox.Text);
                _caseParameter.Height = value;
                SetSuccessColorAndRemoveToolTip(HeightTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(HeightTextBox, exception.Message);
            }
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse(LengthTextBox.Text);
                _caseParameter.Length = value;
                SetSuccessColorAndRemoveToolTip(LengthTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(LengthTextBox, exception.Message);
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse(WidthTextBox.Text);
                _caseParameter.Width = value;
                SetSuccessColorAndRemoveToolTip(WidthTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(WidthTextBox, exception.Message);
            }
        }
        private void UpperFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse(UpperFansDiameterTextBox.Text);
                _caseParameter.UpperFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(UpperFansDiameterTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
        }

        private void FrontFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse(FrontFansDiameterTextBox.Text);
                _caseParameter.FrontFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(FrontFansDiameterTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(FrontFansDiameterTextBox, exception.Message);
            }
        }

        private void SetSuccessColorAndRemoveToolTip(TextBox textBox)
        {
            textBox.BackColor = successTextBoxColor;
            toolTip1.SetToolTip(textBox, null);
        }

        private void  SetErrorColorAndAddToolTip(TextBox textBox, string message)
        {
            toolTip1.SetToolTip(textBox, message);
            textBox.BackColor = errorTextBoxColor;
        }

        private void MotherboardRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ATXRadio_CheckedChanged(object sender, EventArgs e)
        {
            _caseParameter.MotherboardType = MotherboardType.ATX;
        }

        private void microATXRadio_CheckedChanged(object sender, EventArgs e)
        {
            _caseParameter.MotherboardType = MotherboardType.MicroATX;
        }

        private void upperFanCountRadio_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            _caseParameter.UpperFansCount = int.Parse(radio.Text);
        }

        private void frontFanCountRadio_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            _caseParameter.FrontFansCount = int.Parse(radio.Text);
        }
    }
}
