using GeekBrainsLib;
using System;

namespace HomeWork3
{
    struct ComplexStruct
    {
        public double im;
        public double re;

        public ComplexStruct Plus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public ComplexStruct Minus(ComplexStruct x)
        {
            ComplexStruct y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }

        public ComplexStruct Multi(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public string ToString() => re + "+" + im + "i";
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI consoleUI = new ConsoleUI("Мельников Александр", "Практическое задание 3", 3);
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                consoleUI.PrintUserInfo();
                consoleUI.PrintMenu();
                int idx = int.Parse(Console.ReadLine());
                switch (idx)
                {
                    default:
                        break;
                    case 1: 
                        {
                            Console.Clear();
                            Exercise1();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Exercise2();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Exercise3();
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            isWork = false;
                            break;
                        }
                }
            }
        
        }


        static void Exercise1()
        {

        }

        static void Exercise2()
        {

        }

        static void Exercise3()
        {

        }
    }
}
