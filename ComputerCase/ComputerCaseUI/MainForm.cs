using ComputerCase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComputerCase.Exceptions;
using KompasAPI;
using InventorAPI = InventorAPI.InventorAPI;
using KompasAPI = KompasAPI.KompasAPI;

namespace ComputerCaseUI
{
    //TODO: XML
    /// <summary>
    /// Конструктор главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Цвет ошибки
        /// </summary>
        private readonly Color _errorTextBoxColor = Color.LightSalmon;
        
        /// <summary>
        /// Цвет правильно введенного значения
        /// </summary>
        private readonly Color _successTextBoxColor = Color.LightGreen;
        
        /// <summary>
        /// Данные корпуса
        /// </summary>
        private readonly CaseParameters _caseParameter;
        
        /// <summary>
        /// Строитель корпуса
        /// </summary>
        private readonly CaseBuilder _caseBuilder;
        
        /// <summary>
        /// Словарь, содержащий зависимые экшены
        /// </summary>
        private readonly Dictionary<Control, Action<double>> _dependentActions = new();

        /// <summary>
        /// Словарь, содержащий зависимые контролы
        /// </summary>
        private readonly Dictionary<Control, List<Control>> _dependentControls = new();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _caseParameter = new CaseParameters();
            _caseParameter.TryValueChange += CheckButtonActivation;
            _caseBuilder = new CaseBuilder(new global::InventorAPI.InventorAPI());
            motherboardComboBox.SelectedIndex = 0;
            upperFansComboBox.SelectedIndex = 0;
            frontFansComboBox.SelectedIndex = 0;
            SetActionDictionary();
            SetDependentControls();
        }

        private void SetActionDictionary()
        {
            _dependentActions[widthTextBox] 
                = delegate (double value) { _caseParameter.Width = value; };
            _dependentActions[heightTextBox] 
                = delegate (double value) { _caseParameter.Height = value; };
            _dependentActions[lengthTextBox] 
                = delegate (double value) { _caseParameter.Length = value; };
            _dependentActions[upperFansDiameterTextBox] 
                = delegate (double value) { _caseParameter.UpperFansDiameter = value; };
            _dependentActions[frontFansDiameterTextBox] 
                = delegate (double value) { _caseParameter.FrontFansDiameter = value; };
            _dependentActions[upperFansComboBox]
                = delegate (double value) { _caseParameter.UpperFansCount = (int)value; };
            _dependentActions[frontFansComboBox]
                = delegate (double value) { _caseParameter.FrontFansCount = (int)value; };
        }

        private void SetDependentControls()
        {
            _dependentControls[lengthTextBox] = new List<Control> { upperFansDiameterTextBox };
            _dependentControls[upperFansDiameterTextBox] = new List<Control> { lengthTextBox };
            _dependentControls[heightTextBox] = new List<Control> { frontFansDiameterTextBox };
            _dependentControls[frontFansDiameterTextBox] = new List<Control> { heightTextBox };
            _dependentControls[upperFansComboBox] = new List<Control> 
            {
                upperFansDiameterTextBox,
                lengthTextBox 
            };
            _dependentControls[frontFansComboBox] = new List<Control> 
            {
                frontFansDiameterTextBox,
                heightTextBox
            };
        }

        private void CheckDependencyInfo(Control control)
        {
            //todo: сделать через dictionary с action-ами: _caseParameter.Height = value;
            try
            {
                var value = double.Parse(control.Text);
                _dependentActions[control].Invoke(value);
                SetSuccessColorAndRemoveToolTip(control);
            }
            catch (SizeDependencyException exception)
            {
                SetErrorColorAndAddToolTip(control, exception.Message);
                foreach (var dependentControl in _dependentControls[control])
                {
                    SetErrorColorAndAddToolTip(dependentControl, exception.Message);
                }
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(control, exception.Message);
                RemoveFrontError();
            }
        }

        private void CheckFansCountDependecy(Control control)
        {
            try
            {
                if (int.TryParse(control.Text, out var value))
                {
                    _dependentActions[control].Invoke(value);
                }
                RemoveUpperError();
            }
            catch (Exception exception)
            {
                foreach(var dependentConrol in _dependentControls[control])
                {
                    SetErrorColorAndAddToolTip(dependentConrol, exception.Message);
                }
            }
        }

        /// <summary>
        /// Изменение текста в поле, отвечающем за высоту корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: duplication
            CheckDependencyInfo((Control)sender);
        }

        //TODO: RSDN
        /// <summary>
        /// Изменение текста в поле, отвечающем за тип материнской платы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherboardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO:
            var motherboardType = (MotherboardType)motherboardComboBox.SelectedIndex;
            heightBordersLabel.Text = 
                motherboardType == MotherboardType.ATX
                ? "(от 391 мм до 500 мм)" 
                : "(от 330 мм до 500 мм)";
            _caseParameter.MotherboardType = (MotherboardType)motherboardComboBox.SelectedIndex;
            
        }

        /// <summary>
        /// Изменение текста в поле, отвечающем за кол-во верхних вентиляторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                SetErrorColorAndAddToolTip(upperFansDiameterTextBox, exception.Message);
            }
        }

        /// <summary>
        /// Изменение текста в поле, отвечающем за кол-во передних вентиляторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrontFansComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(frontFansComboBox.Text, out var frontFansCount))
                {
                    _caseParameter.FrontFansCount = frontFansCount;
                }
                RemoveUpperError();
            }
            catch (Exception exception)
            {
                SetErrorColorAndAddToolTip(lengthTextBox, exception.Message);
                SetErrorColorAndAddToolTip(upperFansDiameterTextBox, exception.Message);
            }
        }

        /// <summary>
        /// Установка цвета успешной операции и удаление текста об ошибке
        /// </summary>
        /// <param name="textBox"></param>
        private void SetSuccessColorAndRemoveToolTip(Control textBox)
        {
            textBox.BackColor = _successTextBoxColor;
            toolTip1.SetToolTip(textBox, null);
        }

        /// <summary>
        /// Установка цвета ошибки и добавление текста об ошибке
        /// </summary>
        /// <param name="textBox">Поле в которое необходимо добавить</param>
        /// <param name="message">Сообщение об ошибке</param>
        private void SetErrorColorAndAddToolTip(Control textBox, string message)
        {
            toolTip1.SetToolTip(textBox, message);
            textBox.BackColor = _errorTextBoxColor;
        }

        /// <summary>
        /// Проверка и удаление ошибок связанных с зависимыми размерами:
        /// Длина, диаметр верхних вентиляторов и их кол-во
        /// </summary>
        private void RemoveUpperError()
        {
            if (toolTip1.GetToolTip(upperFansDiameterTextBox) == Validator.LengthDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(upperFansDiameterTextBox);
            }
            if (toolTip1.GetToolTip(lengthTextBox) == Validator.LengthDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(lengthTextBox);
            }
        }
        
        /// <summary>
        /// Проверка и удаление ошибок связанных с зависимыми размерами:
        /// Длина, диаметр верхних вентиляторов и их кол-во
        /// </summary>
        private void RemoveFrontError()
        {
            if (toolTip1.GetToolTip(frontFansDiameterTextBox) == Validator.HeightDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(frontFansDiameterTextBox);
            }
            if (toolTip1.GetToolTip(heightTextBox) == Validator.HeightDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(heightTextBox);
            }
        }

        /// <summary>
        /// Проверка данных для активации/деактивации кнопки построения
        /// </summary>
        private void CheckButtonActivation()
        {
            BuildButton.Enabled = true;
            try
            {
                new CaseParameters
                {
                    MotherboardType = (MotherboardType)motherboardComboBox.SelectedIndex,
                    FrontFansCount = int.Parse(frontFansComboBox.Text),
                    FrontFansDiameter = int.Parse(frontFansDiameterTextBox.Text),
                    Height = int.Parse(heightTextBox.Text),
                    Length = int.Parse(lengthTextBox.Text),
                    Width = int.Parse(widthTextBox.Text),
                    UpperFansCount = int.Parse(upperFansComboBox.Text),
                    UpperFansDiameter = int.Parse(upperFansDiameterTextBox.Text)
                };
            }
            catch (Exception)
            {
                BuildButton.Enabled = false;
            }
        }

        //TODO: XML
        /// <summary>
        /// Обработчик нажатия на кнопку построения корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _caseBuilder.CrateCase(_caseParameter);
        }

        private void ParametersTextChanged(object sender, EventArgs e)
        {
            CheckDependencyInfo((Control)sender);
        }
    }
}
