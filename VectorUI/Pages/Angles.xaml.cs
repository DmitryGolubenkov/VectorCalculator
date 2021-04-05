using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VectoLib;
using VectorUI.Components;
using VectorUI.Windows;

namespace VectorUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Angles.xaml
    /// </summary>
    public partial class Angles : Page
    {
        private MainWindow _parentWindow;

        public Angles()
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
                Vector3 b = VectorInput2.Value;

                int accuracy = 2;
                if (!Validate.NumberIntInput(AccuracyTextBox.Text))
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Значение точности неверно.", OperationStatus.Error));
                    return;
                }
                accuracy = Convert.ToInt32(AccuracyTextBox.Text);
                if (accuracy < 0 || accuracy > 16)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Точность вычислений должна быть от 0 до 16.", OperationStatus.Error));
                    return;
                }
                if (a == null || b == null)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Требуется корректно указать оба вектора и точность.", OperationStatus.Error));
                    return;
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine($"Угол между векторами в градусах { Vector3.AngleDegrees(a, b).ToString(format: "F" + accuracy)}");
                builder.AppendLine($"Угол в радианах: { Vector3.Angle(a, b).ToString(format: "F" + accuracy)}");
                builder.AppendLine($"Sin: {Vector3.Sin(a, b).ToString(format: "F" + accuracy)}");
                builder.AppendLine($"Cos: {Vector3.Cos(a, b).ToString(format: "F" + accuracy)}");
                builder.AppendLine($"Тангенс: {(Vector3.Sin(a, b) / Vector3.Cos(a, b)).ToString(format: "F" + accuracy)}");

                _parentWindow.vectorOperationResultBlock.AddResult(
                    new VectorOperationResult("Угол между векторами: " + a + " и " + b,
                        "Результат: \n" + builder.ToString(), OperationStatus.Success)
                );

            }

            catch (Exception exception)
            {
                ErrorExceptionWindow w = new ErrorExceptionWindow(exception.Message, exception.StackTrace);
                w.Show();
            }
        }

        private void AccuracyTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ErrorTextBlock is not null)
                if (Validate.NumberIntInput(AccuracyTextBox.Text) && Convert.ToDouble(AccuracyTextBox.Text) >= 0 &&
                    Convert.ToDouble(AccuracyTextBox.Text) <= 16)
                    ErrorTextBlock.Text = "";
                else
                {
                    ErrorTextBlock.Text = "Точность должна быть целым числом и находиться в пределах от 0 до 16.";
                }
        }
    }
}
