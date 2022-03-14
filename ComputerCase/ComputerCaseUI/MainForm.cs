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
            _dependentControls[heightTextBox] = new List<Control> { frontFansDiameterTextBox };
            _dependentControls[frontFansDiameterTextBox] = new List<Control> { heightTextBox };
            _dependentControls[widthTextBox] = new List<Control> { UpperFansDiameterTextBox };
            _dependentControls[UpperFansDiameterTextBox] = new List<Control> { widthTextBox };
        }

        private void CheckDependencyInfo(Control control, ref double field)
        {
            try
            {
                var value = double.Parse(control.Text);
                field = value;
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

        /// <summary>
        /// Изменение текста в поле, отвечающем за высоту корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: duplication
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

        /// <summary>
        /// Изменение текста в поле, отвечающем за длину корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: duplication
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

        /// <summary>
        /// Изменение текста в поле, отвечающем за ширину корпуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Изменение текста в поле, отвечающем за диаметр верхних отверстий под вентиляторы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpperFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: duplication
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

        /// <summary>
        /// Изменение текста в поле, отвечающем за диаметр отверстий под передние вентиляторы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrontFansDiameterTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: duplication
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
                SetErrorColorAndAddToolTip(UpperFansDiameterTextBox, exception.Message);
            }
            
        }

        /// <summary>
        /// Изменение текста в поле, отвечающем за кол-во передних вентиляторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (toolTip1.GetToolTip(UpperFansDiameterTextBox) == Validator.LengthDependencyExceptionMessage)
            {
                SetSuccessColorAndRemoveToolTip(UpperFansDiameterTextBox);
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
                    UpperFansDiameter = int.Parse(UpperFansDiameterTextBox.Text)
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
    }
}
