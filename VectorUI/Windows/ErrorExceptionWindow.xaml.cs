using System.Windows;

namespace VectorUI.Windows
{
    /// <summary>
    /// Логика взаимодействия для ErrorExceptionWindow.xaml
    /// </summary>
    public partial class ErrorExceptionWindow : Window
    {
        private int expandedWindowMinHeight = 400;
        public ErrorExceptionWindow(string message, string stackTrace)
        {
            InitializeComponent();

            ErrorTextMainTextBox.Text = "Ошибка: " + message;
            StackTraceTextMainTextBox.Text = stackTrace;
        }

        private void Expander_OnExpanded(object sender, RoutedEventArgs e)
        {
            if (Height < expandedWindowMinHeight)
                Height = expandedWindowMinHeight;
        }
    }
}
