using System;
using System.Windows;
using System.Windows.Controls;
using VectoLib;
using VectorUI.Components;
using VectorUI.Windows;

namespace VectorUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для CrossProduct.xaml
    /// </summary>
    public partial class CrossProduct : Page
    {
        MainWindow _parentWindow;
        public CrossProduct()
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
                
                if (a == null || b == null)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Требуется корректно указать оба вектора.", OperationStatus.Error));
                    return;
                }



                var result = a.Cross(b);
                
                
                _parentWindow.vectorOperationResultBlock.AddResult(
                    new VectorOperationResult("Векторное произведение векторов " + a.ToString() + " и " + b.ToString(),
                        "Результат: "+result.ToString(), OperationStatus.Success)
                    );
            }
            catch (Exception exception)
            {
                ErrorExceptionWindow w = new ErrorExceptionWindow(exception.Message, exception.StackTrace);
                w.Show();
            }
        }
    }
}