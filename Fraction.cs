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

        public double Decimal
        {
            get => (double)numerator / denumerator;
        }

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
        /// Упрощение дроби
        /// </summary>
        public void Normalize()
        {
            int nod = GetNOD(numerator, denumerator);
            numerator = numerator / nod;
            denumerator = denumerator / nod;
        }

        public override string ToString() => $"{numerator} / {denumerator}";

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

        public static Fraction operator +(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator + y.numerator * x.denumerator,
            denumerator = x.denumerator * y.denumerator,
        };

        public static Fraction operator -(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator - y.numerator * x.denumerator,
            denumerator = x.denumerator * y.denumerator,
        };

        public static Fraction operator *(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.numerator,
            denumerator = x.denumerator * y.denumerator,
        };
        public static Fraction operator /(Fraction x, Fraction y) => new Fraction
        {
            numerator = x.numerator * y.denumerator,
            denumerator = x.denumerator * y.numerator,
        };
    }
}
