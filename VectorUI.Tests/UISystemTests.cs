using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlaUI.UIA3;
using System;
using System.IO;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using VectoLib;

namespace VectorUI.Tests
{
    [TestClass]
    public class UISystemTests
    {

        string Path
        {
            get
            {
                string path = Environment.CurrentDirectory;
                path = Directory.GetParent(path).FullName;
                path = Directory.GetParent(path).FullName;
                path = Directory.GetParent(path).FullName;
                path += "\\executable\\VectorUI.exe";
                return path;
            }
        }

        [TestMethod]
        public void TestSumUI()
        {
            var app = FlaUI.Core.Application.Launch(Path);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation, TimeSpan.FromSeconds(10));
                //Должно открыться окно приложения
                Assert.IsNotNull(window, "Приложение не было запущено.");


                //Переходим на вкладку "Сложение векторов"
                window.FindFirstDescendant(cf => cf.ByText("Сложение векторов")).AsButton().Click();

                //Находим элементы
                var firstVectorInput = window.FindFirstDescendant(cf => cf.ByAutomationId("Sum_VectorInput1")).As<VectorInput>();
                var secondVectorInput = window.FindFirstDescendant(cf => cf.ByAutomationId("Sum_VectorInput2")).As<VectorInput>();
                var executeButton = window.FindFirstDescendant(cf => cf.ByAutomationId("Sum_ExecuteButton")).AsButton();

                //Вписываем значения
                firstVectorInput.Value = new Vector3(5,10,15);
                secondVectorInput.Value= new Vector3(3,-6,9);
                
                //Выполняем подсчёты
                executeButton.Click();

                var resultBlock = window.FindFirstDescendant(cf => cf.ByAutomationId("ResultBlockHolder"));
                resultBlock.FindChildAt(0);
                //"(8,4,24)";
                Assert.AreEqual
                (true,
                    resultBlock.FindChildAt(0).FindFirstDescendant(cf=>cf.ByAutomationId("ActionBottomTextBox")).AsTextBox().Text.Contains("(8; 4; 24)")
                    );

                firstVectorInput.ClearButtonClick();
                Assert.IsNull(firstVectorInput.Value);
            }

            app.Close();
        }
        
    }

    public class VectorInput : AutomationElement
    {
        public VectorInput(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        public VectorInput(AutomationElement automationElement) : base(automationElement)
        {
        }

        public Vector3 Value
        {
            get
            {
                try
                {
                    return new Vector3(
                        Double.Parse(FindFirstDescendant(cf => cf.ByAutomationId("X")).AsTextBox().Text),
                        Double.Parse(FindFirstDescendant(cf => cf.ByAutomationId("Y")).AsTextBox().Text),
                        Double.Parse(FindFirstDescendant(cf => cf.ByAutomationId("Z")).AsTextBox().Text)
                    );
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set
            {
                FindFirstDescendant(cf => cf.ByAutomationId("X")).AsTextBox().Text = value.x.ToString();
                FindFirstDescendant(cf => cf.ByAutomationId("Y")).AsTextBox().Text = value.y.ToString();
                FindFirstDescendant(cf => cf.ByAutomationId("Z")).AsTextBox().Text = value.z.ToString();
            }
        }

        public void ClearButtonClick()
        {
            this.FindFirstDescendant(cf => cf.ByAutomationId("ClearButton")).AsButton().Click();
        }
    }
}
