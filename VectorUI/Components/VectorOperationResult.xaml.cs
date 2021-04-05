using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorUI.Components
{
    /// <summary>
    /// Логика взаимодействия для VectorOperationResult.xaml
    /// </summary>
    public partial class VectorOperationResult : UserControl
    {

        public string ActionTopTextBoxText { get; set; }
        public string ActionBottomTextBoxText { get; set; }

        public VectorOperationResult(OperationResult result)
        {
            InitializeComponent();

            ActionTopTextBox.Text = result.headerText;
            ActionBottomTextBox.Text = result.bottomText;

            switch (result.status)
            {
                case OperationStatus.Success:
                    ActionBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(10, 180, 10));
                    break;
                case OperationStatus.Error:
                    ActionBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(180, 10, 10));
                    break;
                case OperationStatus.Message:
                    ActionBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 130, 230));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result.status), result.status, null);
            }
        }

        public VectorOperationResult(string headerText, string bottomText, OperationStatus status)
        {
            InitializeComponent();

            ActionTopTextBox.Text = headerText;
            ActionBottomTextBox.Text = bottomText;

            switch (status)
            {
                case OperationStatus.Success:
            ActionBorder.BorderBrush= new SolidColorBrush(Color.FromRgb(10, 180,10));
                    break;
                case OperationStatus.Error:
            ActionBorder.BorderBrush= new SolidColorBrush(Color.FromRgb(180, 10,10));
                    break;
                case OperationStatus.Message:
                    ActionBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 130, 230));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        [Obsolete]
        public VectorOperationResult()
        {
            //Костыль. Иначе Visual Studio выводит ошибки в работающем коде.
            throw new NotImplementedException("Метод не предназначен для использования. Используйте следующий конструктор: VectorOperationResult((string headerText, string bottomText, OperationStatus status).");
        }
    }
}
