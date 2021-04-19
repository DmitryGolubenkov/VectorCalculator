using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VectoLib.Tests
{
    [TestClass]
    public class Vector3Tests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Vector3 v = new Vector3(10,15,-23);
            //Проверка конструктора с 3 параметрами
            Assert.AreEqual(10, v.x);
            Assert.AreEqual(15, v.y);
            Assert.AreEqual(-23, v.z);
            //Проверка конструктора с 2 параметрами
            Vector3 v1 = new Vector3(32, 1);
            Assert.AreEqual(32, v1.x);
            Assert.AreEqual(1, v1.y);
            Assert.AreEqual(0, v1.z);

            //Проверка работы конструктора с типом данных double
            Vector3 v2 = new Vector3(3121112322232.324132322, 132212312321123212.1231321, -3232322323232323232323.111333232222123412);
            Assert.AreEqual(3121112322232.324132322, v2.x);
            Assert.AreEqual(132212312321123212.1231321, v2.y);
            Assert.AreEqual(-3232322323232323232323.111333232222123412, v2.z);
        }

        [TestMethod]
        public void TestEqual()
        {
            Vector3 v1 = new Vector3(1,2,3);
            Vector3 v2 = new Vector3(1,2,3);
            Assert.AreEqual(true, v1.Equals(v2));

            v2 = new Vector3(123,32,3);
            Assert.AreEqual(false, v1.Equals(v2));

            Assert.AreEqual(true, 
                new Vector3(2322.333332, 12, 13).EqualApprox( 
                new Vector3(2322.333322, 12, 13), 0.0001)
                );
        }


        [TestMethod]
        public void TestOperands()
        {
            //Тест сложения
            Assert.AreEqual(new Vector3(2,5,3), new Vector3(1,2,5)+new Vector3(1,3,-2));
            //Тест вычитания
            Assert.AreEqual(new Vector3(2,5,3), new Vector3(1,2,5)+new Vector3(1,3,-2));
            //Тест равенства
            Assert.AreEqual(true, new Vector3(1231.232, 2321, 1231) == new Vector3(1231.232, 2321, 1231));
            Assert.AreEqual(false, new Vector3(1231.232, 2321.02, 1231) == new Vector3(1231.232, 2321, 1231));
            //Тест "Не равно"
            Assert.AreEqual(true, new Vector3(23, 32, 5) != new Vector3(1,0,55));
            Assert.AreEqual(false, new Vector3(23, 32, 5) != new Vector3(23,32,5));
            //Тест умножения
            Assert.AreEqual(10, new Vector3(1,2,3)*new Vector3(3,2,1));
            //Тест умножения на число
            Assert.AreEqual(new Vector3(-15,21.75,36), new Vector3(-5,7.25, 12)*3);
            //Тест деления на число
            Assert.AreEqual(new Vector3(7, -5, 2053.2), new Vector3(14,-10,4106.4)/2 );
        }

        [TestMethod]
        public void TestDot()
        {
            Assert.AreEqual(true, CompareDouble(Vector3.DotProduct(
                new Vector3(2.231231, 8.23215122, 5.2315121),
                new Vector3(3.9762634, 1.2186482235, 2.1512351232)), 30.1582700619));
        }

        [TestMethod]
        public void TestCross()
        {
            Assert.AreEqual(new Vector3(-1, -2, 7), Vector3.Cross(new Vector3(3, 2, 1), new Vector3(4, 5, 2)));
        }


        [TestMethod]
        public void TestTriple()
        {
            Assert.AreEqual
            (
                2, 
                Vector3.Triple(new Vector3(3, 2, 1), new Vector3(4, 5, 2), new Vector3(2,5,2))
                );
            
            Assert.AreEqual
            (
                -153.264, 
                Vector3.Triple(new Vector3(15, -2, 1.5), new Vector3(4, 0, 2.3), new Vector3(2.34,5,0))
                );

        }

        [TestMethod]
        public void TestAngle()
        {
            //Тестирование углов в градусах
            Assert.AreEqual(true, CompareDouble( Vector3.AngleDegrees(new Vector3(0,5,5), new Vector3(0,2)), 45));
            Assert.AreEqual(true, CompareDouble(Vector3.AngleDegrees(Vector3.forward, Vector3.up), 90));

            //Тестирование углов в радианах
            Assert.AreEqual(true, CompareDouble(Vector3.Angle(new Vector3(2, 4, 5), new Vector3(-2, 2, 5)), 0.718872087));
            Assert.AreEqual(true, CompareDouble(Vector3.Angle(new Vector3(2, 4, 5), new Vector3(-2, 2.345, 21)), 0.683698456));

        }

        [TestMethod]
        public void TestProject()
        {
            Assert.AreEqual( true, CompareDouble(Vector3.Project(new Vector3(1, 2, 5), new Vector3(51,13,-3)), 1.1761085741518913));
        }

        [TestMethod]
        public void TestSinCos()
        {
            Assert.AreEqual(true, CompareDouble(Vector3.Sin(new Vector3(3,2,5), new Vector3(0,2,1)), 0.57368421052));
            Assert.AreEqual(true, CompareDouble(Vector3.Cos(new Vector3(3,2,5), new Vector3(0,2,1)), 0.6529286250990105));
        }

        [TestMethod]
        public void TestLength()
        {
            Assert.AreEqual(true, CompareDouble(new Vector3(1,2,5).Length, 5.47722558));
        }

        private bool CompareDouble(double a, double b, double accuracy = 0.00001)
        {
            return Math.Abs(a - b) < accuracy;
        }
    }
}
