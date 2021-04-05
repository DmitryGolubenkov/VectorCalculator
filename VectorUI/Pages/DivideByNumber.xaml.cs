﻿using System;
using System.Windows;
using System.Windows.Controls;
using VectoLib;
using VectorUI.Components;
using VectorUI.Windows;

namespace VectorUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для DivideByNumber.xaml
    /// </summary>
    public partial class DivideByNumber : Page
    {
        MainWindow _parentWindow;
        public DivideByNumber()
        {

            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_parentWindow is null)
                    _parentWindow = Window.GetWindow(this) as MainWindow;
                
                Vector3 a = VectorInput1.Value;
                
                if (a == null || NumberTextBox.Text.Normalize() == "" || !Validate.NumberDoubleInput(NumberTextBox.Text))
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Требуется корректно указать и вектор, и число.", OperationStatus.Error));
                    return;
                }
                double b = Convert.ToDouble(NumberTextBox.Text.Normalize());

                if (b == 0)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(
                        new VectorOperationResult("Ошибка", "Деление на 0 невозможно.", OperationStatus.Error));
                    return;
                }


                var result = a / b;
                
                
                _parentWindow.vectorOperationResultBlock.AddResult(
                    new VectorOperationResult("Деление вектора " + a.ToString() + " на число " + b.ToString(),
                        "Результат: "+result.ToString(), OperationStatus.Success)
                    );
            }
            catch (Exception exception)
            {
                ErrorExceptionWindow w = new ErrorExceptionWindow(exception.Message, exception.StackTrace);
                w.Show();
            }
        }

        

        private void NumberTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Validate.NumberDoubleInput(NumberTextBox.Text))
                ErrorTextBlock.Text = "Число введено неверно.";
            else
                ErrorTextBlock.Text = "";
        }
    }
}