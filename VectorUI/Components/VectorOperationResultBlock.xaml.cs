using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace VectorUI.Components
{
    /// <summary>
    /// Логика взаимодействия для VectorOperationResultBlock.xaml
    /// </summary>
    public partial class VectorOperationResultBlock : UserControl
    {

        private ObservableCollection<VectorOperationResult> results = new ObservableCollection<VectorOperationResult>();
        public VectorOperationResultBlock()
        {
            InitializeComponent();
            ResultItemsItemControl.ItemsSource = results;

            CheckForEmptyCollection();
        }
    
        public void AddResult(VectorOperationResult vectorOperationResult)
        {
            results.Insert(0,vectorOperationResult);
            CheckForEmptyCollection();
        }

        private void CheckForEmptyCollection()
        {
            EmptyLabel.Content = results.Count == 0 ? "Здесь будут отображены результаты." : "";
        }
    }
}
