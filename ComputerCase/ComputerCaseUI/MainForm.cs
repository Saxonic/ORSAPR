using ComputerCase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Windows.Forms;
using ComputerCase.Exceptions;

namespace ComputerCaseUI
{
    public partial class MainForm : Form
    {
        private Color _errorTextBoxColor = Color.LightSalmon;
        private Color _successTextBoxColor = Color.PaleGreen;
        private CaseParameters _caseParameter;

        private string _upperSizeExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                   "не могут быть умещены на корпусе с указанной длиной";
        private string _frontSizeExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                   "не могут быть умещены на корпусе с указанной высотой";

        public MainForm()
        {
            InitializeComponent();
            _caseParameter = new CaseParameters();
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
                var value = double.Parse(HeightTextBox.Text);
                _caseParameter.Height = value;
                SetSuccessColorAndRemoveToolTip(HeightTextBox);
                
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(HeightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(FrontFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(HeightTextBox, exception.Message);
                RemoveFrontError();
            }
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(LengthTextBox.Text);
                _caseParameter.Length = value;
                SetSuccessColorAndRemoveToolTip(LengthTextBox);
                
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(LengthTextBox,exception.Message);
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(LengthTextBox, exception.Message);
                RemoveUpperError();
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(WidthTextBox.Text);
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
                var value = double.Parse(UpperFansDiameterTextBox.Text);
                _caseParameter.UpperFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(UpperFansDiameterTextBox);
                
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(LengthTextBox, exception.Message);
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
                RemoveUpperError();
            }
        }

        private void FrontFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var value = double.Parse(FrontFansDiameterTextBox.Text);
                _caseParameter.FrontFansDiameter = value;
                SetSuccessColorAndRemoveToolTip(FrontFansDiameterTextBox);
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(HeightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(FrontFansDiameterTextBox, exception.Message);
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(FrontFansDiameterTextBox, exception.Message);
                RemoveFrontError();
            }
            
        }

        private void motherboardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _caseParameter.MotherboardType = (MotherboardType)motherboardComboBox.SelectedIndex;
        }

        private void upperFansComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                SetErrorColorAndAddToolTip(LengthTextBox, exception.Message);
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
                SetErrorColorAndAddToolTip(HeightTextBox, exception.Message);
                SetErrorColorAndAddToolTip(FrontFansDiameterTextBox, exception.Message);
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
            if (toolTip1.GetToolTip(UpperFansDiameterTextBox) == _upperSizeExceptionMessage)
            {
                UpperFansDiameterTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(UpperFansDiameterTextBox, null);
            }
            if (toolTip1.GetToolTip(LengthTextBox) == _upperSizeExceptionMessage)
            {
                LengthTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(LengthTextBox, null);
            }
        }
        private void RemoveFrontError()
        {
            if (toolTip1.GetToolTip(FrontFansDiameterTextBox) == _frontSizeExceptionMessage)
            {
                FrontFansDiameterTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(FrontFansDiameterTextBox, null);
            }
            if (toolTip1.GetToolTip(HeightTextBox) == _frontSizeExceptionMessage)
            {
                HeightTextBox.BackColor = _successTextBoxColor;
                toolTip1.SetToolTip(HeightTextBox, null);
            }
        }
    }
}
