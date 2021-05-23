using System;

namespace VectoLib
{
    public class Vector3 : IEquatable<Vector3>
    {
        #region VariablesAndProperties

        public double x;
        public double y;
        public double z;

        /// <summary>
        /// Длина вектора, рассчитанная на основе координат.
        /// </summary>
        public double Length => Math.Sqrt(x * x + y * y + z * z);

        public double Magnitude => Length;
        public double sqrMagnitude => Length * Length;

        #endregion

        #region Constructors
        /// <summary>
        /// Создаёт вектор с координатами x и y и устанавливает координату z равной нулю.
        /// </summary>
        public Vector3(double x, double y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        /// <summary>
        /// Создаёт вектор с координатами x, y, z.
        /// </summary>
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Operators

        /// <summary>
        /// Возвращает сумму векторов a и b.
        /// </summary>
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x+b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Возвращает сумму векторов a и b.
        /// </summary>
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.x - b.x, 
                a.y - b.y, 
                a.z - b.z
                );
        }

        /// <summary>
        /// Возвращает скалярное произведение векторов a и b.
        /// </summary>
        public static double operator *(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }


        /// <summary>
        /// Возвращает произведение вектора vector на число number.
        /// </summary>
        public static Vector3 operator *(Vector3 vector, double number)
        {
            return new Vector3(
                vector.x * number, 
                vector.y * number, 
                vector.z * number
                );
        }

        /// <summary>
        /// Возвращает произведение числа number на вектор vector.
        /// </summary>
        public static Vector3 operator *(double number, Vector3 vector)
        {
            return vector * number;
        }

        /// <summary>
        /// Возвращает частное после деления вектора a на число b.
        /// </summary>
        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(
                a.x / b,
                a.y / b,
                a.z / b
            );
        }

        /// <summary>
        /// Возвращает true, если векторы точно равны. Используйте Vector3.EqualApprox, чтобы сравнить векторы с заданной точностью.
        /// </summary>
        public static bool operator == (Vector3 a, Vector3 b)
        {
            //Если оба значения - null, то идёт проверка на null. Возвращаем true.
            if (a is null && b is null)
                return true;
            //Если одно значение null, то идет проверка на null, которая не проходит. Возвращаем false.
            if (a is null || b is null)
                return false;

            //Если сравнение векторов - проверяем их координаты
            if (a.x == b.x &&
                a.y == b.y && a.z == b.z)
                return true;

            return false;
        }
        /// <summary>
        /// Возвращает true, если векторы не равны.
        /// </summary>
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Сравнивает вектора a и b с погрешностью maxDifference и возвращает true, если они примерно равны, и false, если нет.
        /// </summary>
        public static bool EqualApprox(Vector3 a, Vector3 b, double maxDifference = 0.000000005)
        {
            if (Math.Abs(a.x - b.x) < maxDifference 
                && Math.Abs(a.y - b.y) < maxDifference 
                && Math.Abs(a.z - b.z) < maxDifference)
                return true;

            return false;
        }

        /// <summary>
        /// Сравнивает вектор с вектором other с погрешностью maxDifference и возвращает true, если они примерно равны, и false, если нет.
        /// </summary>
        public bool EqualApprox(Vector3 other, double maxDifference = 0.000000005)
        {
            return Vector3.EqualApprox(this, other, maxDifference);
        }

        #endregion

        #region DotProduct

        /// <summary>
        /// Возвращает скалярное произведение векторов a и b.
        /// </summary>
        public static double DotProduct(Vector3 a, Vector3 b)
        {
            return a * b;
        }

        /// <summary>
        /// Возвращает скалярное произведение данного вектора и вектора other.
        /// </summary>
        public double DotProduct(Vector3 other)
        {
            return this * other;
        }

        #endregion

        #region CrossProduct
        /// <summary>
        /// Возвращает векторное произведение векторов a и b.
        /// </summary>
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.y*b.z-b.y*a.z,
                (b.x * a.z) - (a.x * b.z),
                (a.x * b.y) - (b.x * a.y)
                );
        }

        /// <summary>
        /// Возвращает векторное произведение данного вектора, и вектора other.
        /// </summary>
        public Vector3 Cross(Vector3 other)
        {
            return Vector3.Cross(this, other);
        }

        #endregion

        #region TripleProduct

        /// <summary>
        /// Находит смешанное произведение векторов a, b, c.
        /// При этом скалярное произведение вектора a умножается на векторное произведение векторов b и c.
        /// </summary>
        public static double Triple(Vector3 a, Vector3 b, Vector3 c)
        {
            return a * Cross(b, c);
        }

        #endregion

        #region Angles
        /// <summary>
        /// Возвращает косинус угла между векторами a и b.
        /// </summary>
        public static double Cos(Vector3 a, Vector3 b)
        {
            return (a*b)/(a.Length*b.Length);
        }

        /// <summary>
        /// Возвращает синус угла между векторами a и b.
        /// </summary>
        public static double Sin(Vector3 a, Vector3 b)
        {
            var cos = Cos(a, b);
            return 1 - cos*cos;
        }

        /// <summary>
        /// Возвращает угол между векторами в радианах.
        /// </summary>
        public static double Angle(Vector3 a, Vector3 b)
        {
            var cos = Cos(a, b);
            return Math.Acos(cos);
        }

        /// <summary>
        /// Возвращает угол между векторами в градусах.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double AngleDegrees(Vector3 a, Vector3 b)
        {
            var cos = Cos(a, b);
            return Math.Acos(cos)*180 / Math.PI;
        }
        #endregion

        #region Projections

        /// <summary>
        /// Возвращает число - проекцию вектора vector на ось axis.
        /// </summary>
        public static double Project(Vector3 vector, Vector3 axis)
        {
            return vector.Length * Cos(vector, axis);
        }

        /// <summary>
        /// Возвращает число - проекцию данного вектора на ось axis.
        /// </summary>
        public double Project(Vector3 axis)
        {
            return Project(this, axis);
        }

        /// <summary>
        /// Возвращает вектор-проекцию вектора vector на ось axis.
        /// </summary>
        public static Vector3 ProjectVector(Vector3 vector, Vector3 axis)
        {
            return Project(vector, axis) * axis.NormalizeMagnitude();
        }
        #endregion

        #region Equality
        public bool Equals(Vector3 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }
        #endregion

        #region ShortcutVectors
        public static Vector3 one => new Vector3(1,1,1);
        public static Vector3 zero => new Vector3(0,0,0);

        public static Vector3 up => new Vector3(0,1,0);
        public static Vector3 down => new Vector3(0,-1,0);

        public static Vector3 forward => new Vector3(0,0,1);
        public static Vector3 back => new Vector3(0,0,-1);

        public static Vector3 left => new Vector3(-1,0,0);
        public static Vector3 right => new Vector3(1,0,0);

        #endregion

        /// <summary>
        /// Возвращает единичный вектор того же направления.
        /// </summary>
        public Vector3 NormalizeMagnitude()
        {
            return this / Length;
        }

        public override string ToString()
        {

            return  "("+ x + "; " + y + "; " + z + ')';
            
        }
    }
}