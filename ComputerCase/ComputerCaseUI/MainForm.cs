using ComputerCase;
using System;
using System.Drawing;
using System.Windows.Forms;
using ComputerCase.Exceptions;

namespace ComputerCaseUI
{
    public partial class MainForm : Form
    {
        private Color _errorTextBoxColor = Color.LightSalmon;
        private Color _successTextBoxColor = Color.LightGreen;
        private CaseParameters _caseParameter;
        private CaseBuilder _caseBuilder;

        private const string UpperSizeExceptionMessage = "Отверстия под вентиляторы с заданным размером " 
                                                         + "не могут быть умещены на корпусе с указанной длиной";

        private const string FrontSizeExceptionMessage = "Отверстия под вентиляторы с заданным размером " 
                                                         + "не могут быть умещены на корпусе с указанной высотой";

        public MainForm()
        {
            InitializeComponent();
            _caseParameter = new CaseParameters();
            _caseParameter.TryValueChange += CheckButtonActivation;
            _caseBuilder = new CaseBuilder(new KompasAPI.KompasAPI());
            motherboardComboBox.SelectedIndex = 0;
            upperFansComboBox.SelectedIndex = 0;
            frontFansComboBox.SelectedIndex = 0;
            //var controls = splitContainer1.Panel1.Controls.Cast<Control>()
            //    .Where(c => c.GetType() == typeof(GroupBox)).ToList();
            //List<Control> textBoxes = new List<Control>();
            //foreach (var control in controls)
            //{
            //    textBoxes = control.Controls.Cast<Control>()
            //        .Where(c => c.GetType() == typeof(TextBox)).Concat(textBoxes).ToList();
            //}
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(heightTextBox.Text);
                _caseParameter.Height = value;
                SetSuccessColorAndRemoveToolTip(heightTextBox);
                
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(heightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(frontFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(heightTextBox, exception.Message);
                RemoveFrontError();
            }
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(lengthTextBox.Text);
                _caseParameter.Length = value;
                SetSuccessColorAndRemoveToolTip(lengthTextBox);
                
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(lengthTextBox,exception.Message);
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(lengthTextBox, exception.Message);
                RemoveUpperError();
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(widthTextBox.Text);
                _caseParameter.Width = value;
                SetSuccessColorAndRemoveToolTip(widthTextBox);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(widthTextBox, exception.Message);
            }
        }
        private void UpperFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(UpperFansDiameterTextBox.Text);
                _caseParameter.UpperFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(UpperFansDiameterTextBox);
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(lengthTextBox, exception.Message);
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                RemoveUpperError();
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
        }

        private void FrontFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(frontFansDiameterTextBox.Text);
                _caseParameter.FrontFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(frontFansDiameterTextBox);
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(heightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(frontFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                RemoveFrontError();
                SetErrorColorAndAddToolTip(frontFansDiameterTextBox, exception.Message);
            }
            
        }

        private void motherboardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _caseParameter.MotherboardType = (MotherboardType)motherboardComboBox.SelectedIndex;
        }

        private void UpperFansComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(upperFansComboBox.Text, out var upperFansCount))
                {
                    _caseParameter.UpperFansCount = upperFansCount;
                }
                RemoveUpperError();
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(lengthTextBox, exception.Message);
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            
        }

        private void frontFansComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(frontFansComboBox.Text, out var frontFansCount))
                {
                    _caseParameter.FrontFansCount = frontFansCount;
                }
                RemoveFrontError();
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(heightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(frontFansDiameterTextBox, exception.Message);
            }

        }

        private void SetSuccessColorAndRemoveToolTip(TextBox textBox)
        {
            textBox.BackColor = _successTextBoxColor;
            toolTip1.SetToolTip(textBox, null);
        }

        private void SetErrorColorAndAddToolTip(TextBox textBox, string message)
        {
            toolTip1.SetToolTip(textBox, message);
            textBox.BackColor = _errorTextBoxColor;
        }

        private void RemoveUpperError()
        {
            if (toolTip1.GetToolTip(UpperFansDiameterTextBox) == Validator.LengthDependencyExceptionMessage)
            {
                UpperFansDiameterTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(UpperFansDiameterTextBox, null);
            }
            if (toolTip1.GetToolTip(lengthTextBox) == Validator.LengthDependencyExceptionMessage)
            {
                lengthTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(lengthTextBox, null);
            }
        }
        private void RemoveFrontError()
        {
            if (toolTip1.GetToolTip(frontFansDiameterTextBox) == Validator.HeightDependencyExceptionMessage)
            {
                frontFansDiameterTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(frontFansDiameterTextBox, null);
            }
            if (toolTip1.GetToolTip(heightTextBox) == Validator.HeightDependencyExceptionMessage)
            {
                heightTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(heightTextBox, null);
            }
        }

        private void CheckButtonActivation()
        {
            BuildButton.Enabled = true;
            try
            {
                new CaseParameters
                {
                    FrontFansCount = int.Parse(frontFansComboBox.Text),
                    FrontFansDiameter = int.Parse(frontFansDiameterTextBox.Text),
                    Height = int.Parse(heightTextBox.Text),
                    Length = int.Parse(lengthTextBox.Text),
                    Width = int.Parse(widthTextBox.Text),
                    UpperFansCount = int.Parse(upperFansComboBox.Text),
                    UpperFansDiameter = int.Parse(UpperFansDiameterTextBox.Text)
                };
            }
            catch (Exception)
            {
                BuildButton.Enabled = false;
            }
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _caseBuilder.CrateCase(_caseParameter);
        }
    }
}
