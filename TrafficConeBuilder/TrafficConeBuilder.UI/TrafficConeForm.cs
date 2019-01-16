﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TrafficConeBuilder.Parameters;

namespace TrafficConeBuilder.UI
{
    /// <summary>
    /// Основное окно плагина
    /// </summary>
    public partial class TrafficConeForm : Form
    {
        private readonly KompasConnector _kompasConnector = new KompasConnector();

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        public TrafficConeForm()
        {
            InitializeComponent();
            closeKompasButton.Enabled = false;
            buildConeButton.Enabled = false;
        }

        /// <summary>
        /// Получить <see cref="Parameters"/> из <see cref="TextBox"/>
        /// </summary>
        /// <returns>параметры дорожного конуса</returns>
        private Parameters.Parameters GetParametersFromTextBoxes()
        {
            var bValue = GetParameterValueFromTextBox(baseConeTextBox);
            var aValue = GetParameterValueFromTextBox(lowerHoleTextBox);
            var cValue = GetParameterValueFromTextBox(baseHeightTextBox);
            var dValue = GetParameterValueFromTextBox(coneWidthTextBox);
            var eValue = GetParameterValueFromTextBox(baseWidthTextBox);
            var parameters = new List<Parameter>
            {
                new Parameter(ParameterName.B, 100, 5, bValue),
                new Parameter(ParameterName.A, 0.5 * dValue, 1, aValue),
                new Parameter(ParameterName.C, bValue * 0.4, 0.5, cValue),
                new Parameter(ParameterName.D, eValue * 0.8, aValue * 1.5, dValue),
                new Parameter(ParameterName.E, 100, dValue * 1.2, eValue)
            };

            return new Parameters.Parameters(parameters);
        }

        /// <summary>
        /// Получить вещественное число из конкретного <see cref="TextBox"/>
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private double GetParameterValueFromTextBox(TextBox textBox)
        {
            if (double.TryParse(textBox.Text, out double result) && result != 0)
            {
                return result;
            }

            throw new ArgumentException($"Error in one or more textbox (value is not a real number or 0)");
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Start Kompas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            try
            {
                _kompasConnector.Open();
                closeKompasButton.Enabled = true;
                buildConeButton.Enabled = true;
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Close Kompas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseKompasButton_Click(object sender, EventArgs e)
        {
            try
            {
                _kompasConnector.Close();
                closeKompasButton.Enabled = false;
                buildConeButton.Enabled = false;
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработка события нажатия на клавишу клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseConeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty((sender as TextBox).Text) && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Build"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildConeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var parameters = GetParametersFromTextBoxes();
                var errors = parameters.CheckAllParametersValue();

                if (errors.All(string.IsNullOrEmpty))
                {
                    _kompasConnector.Application.Build(parameters);
                }
                else
                {
                    string commonError = string.Empty;
                    foreach (var error in errors)
                    {
                        commonError += $"{error}\n";
                    }
                    MessageBox.Show(commonError, "Parameters value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
