using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Complex
    {
        private double im;
        private double re;
     
        public Complex() { }

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }

        /// <summary>
        /// Перегрузка оператора +, сложение комплексных чисел
        /// </summary>
        /// <param name="a">Комплексное число</param>
        /// <param name="b">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static Complex operator +(Complex a, Complex b)=> new Complex
        {
            re = a.re + b.re,
            im = a.im + b.im
        };

        /// <summary>
        /// Перегрузка оператора -, вычитание комплексных чисел
        /// </summary>
        /// <param name="a">Комплексное число</param>
        /// <param name="b">Комплексное число</param>
        /// <returns>Результат вычитания комплексных чисел</returns>
        public static Complex operator -(Complex a, Complex b)=> new Complex
        {
            re = a.re - b.re,
            im = a.im - b.im
        };

        /// <summary>
        /// Перегрузка оператора -, умножение комплексных чисел
        /// </summary>
        /// <param name="a">Комплексное число</param>
        /// <param name="b">Комплексное число</param>
        /// <returns>Результат умножения комплексных чисел</returns>
        public static Complex operator *(Complex a, Complex b) => new Complex
        {
            im = a.re * b.im + a.im * b.re,
            re = a.re * b.re - a.im * b.im
        };


        public override string ToString() => $"{re} + {im}i";

        /// <summary>
        /// Преобразование строки в Complex
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Complex Parse(string complexValue)
        {
            string[] elemArray = complexValue.Split(' ', '+');
            return new Complex
            {
                re = double.Parse(elemArray[0]),
                im = double.Parse(elemArray[1].Replace('i', ' '))
            };
        }


    }
}
