using System;
using System.Windows;
using System.Windows.Controls;
using VectoLib;

namespace VectorUI.Components
{
    /// <summary>
    /// Логика взаимодействия для VectorInput.xaml
    /// </summary>
    public partial class VectorInput : UserControl
    {

        public Vector3 Value;

        public VectorInput()
        {
            InitializeComponent();
            ErrorText.Text = "";
        }


        public bool CheckInput()
        {
            var inputX = VectorX.Text;
            var inputY = VectorY.Text;
            var inputZ = VectorZ.Text;


            if (inputX.Length == 0 && inputY.Length == 0 && inputZ.Length == 0)
            {
                ErrorText.Text = "";
                return false;
            }

            if (!IsValidCoordinate(inputX) || !IsValidCoordinate(inputY) || !IsValidCoordinate(inputZ))
            {
                ErrorText.Text = "Координаты вектора заданы неверно.";
                return false;
            }
            else
                ErrorText.Text = "";

            return true;
        }

        public bool IsValidCoordinate(string input)
        {
            input = input.Trim();
            if (input.Length == 0)
                return false;

            bool isCommaFound = false;
            foreach (char c in input)
            {
                if (c == ',')
                {
                    if (isCommaFound)
                        return false;
                    else
                    {
                        isCommaFound = true;
                    }

                }
                if ((c < '0' || c > '9') && c != '-' && c != ',')
                    return false;
            }

            return true;
        }

        private void VectorInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    var inputX = Convert.ToDouble(VectorX.Text);
                    var inputY = Convert.ToDouble(VectorY.Text);
                    var inputZ = Convert.ToDouble(VectorZ.Text);

                    Value = new Vector3(
                        inputX,
                        inputY,
                        inputZ
                    );
                }
                else
                {
                    Value = null;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            VectorX.Text = "";
            VectorY.Text = "";
            VectorZ.Text = "";

            Value = null;
        }
    }
}
