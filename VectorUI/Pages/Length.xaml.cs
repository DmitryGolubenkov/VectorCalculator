using System;
using System.Windows;
using System.Windows.Controls;
using VectoLib;
using VectorUI.Components;
using VectorUI.Windows;

namespace VectorUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sum.xaml
    /// </summary>
    public partial class Length : Page
    {
        MainWindow _parentWindow;
        public Length()
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


                if (a == null)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Требуется указать вектор.", OperationStatus.Error));
                    return;
                }

                double result = a.Length;

                _parentWindow.vectorOperationResultBlock.AddResult(
                    new VectorOperationResult("Вычисление длины вектора " + a.ToString(),
                        "Результат: "+ result.ToString(), OperationStatus.Success)
                    );
                //ResultTextBox.Text = result.ToString();
            }
            catch (Exception exception)
            {
                ErrorExceptionWindow w = new ErrorExceptionWindow(exception.Message, exception.StackTrace);
                w.Show();
            }
        }
    }
}