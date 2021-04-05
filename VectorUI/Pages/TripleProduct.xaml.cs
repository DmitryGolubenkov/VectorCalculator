using System;
using System.Windows;
using System.Windows.Controls;
using VectoLib;
using VectorUI.Components;
using VectorUI.Windows;

namespace VectorUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для TripleProduct.xaml
    /// </summary>
    public partial class TripleProduct : Page
    {
        MainWindow _parentWindow;
        public TripleProduct()
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
                Vector3 c = VectorInput3.Value;
                
                if (a == null || b == null)
                {
                    _parentWindow.vectorOperationResultBlock.AddResult(new VectorOperationResult("Ошибка",
                        "Требуется корректно указать все вектора.", OperationStatus.Error));
                    return;
                }



                var result = Vector3.Triple(a, b, c);
                
                
                _parentWindow.vectorOperationResultBlock.AddResult(
                    new VectorOperationResult("Смешанное произведение векторов " + a.ToString() + ", " + b.ToString() + " и " + c.ToString(),
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