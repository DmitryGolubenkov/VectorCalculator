using System.Windows;

namespace VectorUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitAppButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutAppButton_Click(object sender, RoutedEventArgs e)
        {
           AboutWindow window = new AboutWindow();
           window.Show();
        }
    }
}
