using ComputerCase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ApiFactory;
using ComputerCase.Exceptions;

namespace ComputerCaseUI
{
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
            SetActionDictionary();
            SetDependentControls();
            _caseParameter = new CaseParameters();
            _caseParameter.TryValueChange += CheckButtonActivation;
            motherboardComboBox.SelectedIndex = 0;
            upperFansComboBox.SelectedIndex = 0;
            frontFansComboBox.SelectedIndex = 0;
            SetApiGroupBox();
        }

        /// <summary>
        /// Установить значения в groupBox, ответсвенный за выбор api для построения
        /// </summary>
        private void SetApiGroupBox()
        {
            var enums = Enum.GetValues(typeof(BuilderProgramName))
                .Cast<BuilderProgramName>().Select(b=>b.ToString()).ToArray();
            apiTypeComboBox.Items.AddRange(enums);
            apiTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Установка экшенов. Привязка каждого экшена к конкретному элементу на форме
        /// </summary>
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

        /// <summary>
        /// Установка зависимых контролов
        /// </summary>
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
            _dependentControls[motherboardComboBox] = new List<Control>();
            _dependentControls[widthTextBox] = new List<Control>();
        }

        /// <summary>
        /// Проверка и внесение данных о корпусе
        /// </summary>
        /// <param name="control"></param>
        private void CheckAndSetInfo(Control control)
        {
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
                RemoveError(control);
                foreach (var dependentControl in _dependentControls[control])
                {
                    RemoveError(dependentControl);
                }
            }
        }

        /// <summary>
        /// Проверить и установить кол-во вентиляторов
        /// </summary>
        /// <param name="control"></param>
        private void CheckAndSetFansCount(Control control)
        {
            try
            {
                if (int.TryParse(control.Text, out var value))
                {
                    _dependentActions[control].Invoke(value);
                }
                RemoveError(control);
                foreach (var dependentControl in _dependentControls[control])
                {
                    RemoveError(dependentControl);
                }
            }
            catch (Exception exception)
            {
                foreach(var dependentControl in _dependentControls[control])
                {
                    SetErrorColorAndAddToolTip(dependentControl, exception.Message);
                }
            }
        }
        
        /// <summary>
        /// Изменение текста в поле, отвечающем за тип материнской платы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherboardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _caseParameter.MotherboardType = 
                (MotherboardType)motherboardComboBox.SelectedIndex;
            heightBordersLabel.Text = _caseParameter.CaseHeightLimitText;

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
        private void RemoveError(Control control)
        {
            if (toolTip1.GetToolTip(control) == Validator.LengthDependencyExceptionMessage
                || toolTip1.GetToolTip(control) == Validator.HeightDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(control);
            }
        }

        /// <summary>
        /// Проверка данных для активации/деактивации кнопки построения
        /// </summary>
        private void CheckButtonActivation(object sender, EventArgs e)
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
        
        /// <summary>
        /// Обработчик нажатия на кнопку построения корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(apiTypeComboBox.Text,
                out BuilderProgramName builderProgramName)) return;
            var builderApi = BuilderApiFactory.GetApi(builderProgramName);
            var builder = new CaseBuilder(builderApi);
            builder.CrateCase(_caseParameter);
        }

        /// <summary>
        /// Изменение значения текстового поля, отвественного за данные о размерах корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParametersTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckAndSetInfo((Control)sender);
        }

        /// <summary>
        /// Изменение значения кол-ва вентиляторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FansCountGroupBox_Click(object sender, EventArgs e)
        {
            CheckAndSetFansCount((Control)sender);
        }
    }
}
