using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Представляет класс дроби
    /// </summary>
    class Fraction
    {
        private int numerator;

        private int denumerator;

        #region Properties 

        /// <summary>
        /// Числитель
        /// </summary>
        public int Numerator
        {
            get => numerator;
            set
            {
                numerator = value;
            }
        }
        /// <summary>
        /// Знаменатель
        /// </summary>
        public int Denumerator
        {
            get => denumerator;
            set
            {
                if (value != 0)
                    denumerator = value;
                else
                    throw new ArgumentException("Знаменатель не может быть равен 0");
            }
        }

        /// <summary>
        /// Десятичное представление
        /// </summary>
        public double Decimal
        {
            get => (double)numerator / denumerator;
        }

        #endregion

        public Fraction() { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerator">числитель</param>
        /// <param name="denumerator">знаменатель</param>
        public Fraction(int numerator, int denumerator)
        {
            this.numerator = numerator;
            if (denumerator != 0)
            {
                this.denumerator = denumerator;
            }
            else throw new ArgumentException("Знаменатель не может быть равен 0");
        }


        /// <summary>
        /// Нахождение НОД
        /// </summary>
        /// <param name="a">числитель</param>
        /// <param name="b">знаменатель</param>
        /// <returns></returns>
        private int GetNOD(int a, int b)
        {
            while (Math.Abs(a) != Math.Abs(b))
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                    b -= a;
            }
            return a;
        }

        #region Public Methods

        /// <summary>
        /// Упрощение дроби
        /// </summary>
        public Fraction Normalize()
        {
            int nod = GetNOD(numerator, denumerator);
            return new Fraction(numerator / nod, denumerator / nod);
        }

        /// <summary>
        /// Перегрузка оператора +, сложение дробных чисел
        /// </summary>
        /// <param name="x">дробное число</param>
        /// <param name="y">дробное число</param>
        /// <returns>Результат сложения дробных чисел</returns>
        public static Fraction operator +(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator + y.numerator * x.denumerator,
            denumerator = x.denumerator * y.denumerator,
        };

        /// <summary>
        /// Перегрузка оператора -, вычитание дробных чисел
        /// </summary>
        /// <param name="x">дробное число</param>
        /// <param name="y">дробное число</param>
        /// <returns>Результат вычитания дробных чисел</returns>
        public static Fraction operator -(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator - y.numerator * x.denumerator,
            denumerator = x.denumerator * y.denumerator,
        };

        /// <summary>
        /// Перегрузка оператора *, умножение дробных чисел
        /// </summary>
        /// <param name="x">дробное число</param>
        /// <param name="y">дробное число</param>
        /// <returns>Результат умножения дробных чисел</returns>
        public static Fraction operator *(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.numerator,
            denumerator = x.denumerator * y.denumerator,
        };

        /// <summary>
        /// Перегрузка оператора /, деление дробных чисел
        /// </summary>
        /// <param name="x">дробное число</param>
        /// <param name="y">дробное число</param>
        /// <returns>Результат деления дробных чисел</returns>
        public static Fraction operator /(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator,
            denumerator = x.denumerator * y.numerator,
        };

        public static Fraction Parse(string complexValue)
        {
            string[] elemArray = complexValue.Split(' ', '/');
            return new Fraction(int.Parse(elemArray[0]), int.Parse(elemArray[1]));
        }


        public override string ToString() => $"{numerator} / {denumerator}";

        #endregion
    }
}
