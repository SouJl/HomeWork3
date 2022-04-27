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

        public static Complex operator +(Complex a, Complex b)=> new Complex
        {
            re = a.re + b.re,
            im = a.im + b.im
        };

        public static Complex operator -(Complex a, Complex b)=> new Complex
        {
            re = a.re - b.re,
            im = a.im - b.im
        };

        public static Complex operator *(Complex a, Complex b) => new Complex
        {
            im = a.re * b.im + a.im * b.re,
            re = a.re * b.re - a.im * b.im
        };


        public string ToString() => $"{re} + {im}i";


        public static Complex Parse(string complexValue)
        {
            string[] elemArray = complexValue.Split(' ');
            double re = double.Parse(elemArray[0]);
            double im;
            if (elemArray[1] == "+")
            {
                im = double.Parse(elemArray[2].Replace('i', ' '));
            }
            else
            {
                im = -double.Parse(elemArray[2].Replace('i', ' '));
            }
            return new Complex
            {
                re = re,
                im = im
            };
        }


    }
}
