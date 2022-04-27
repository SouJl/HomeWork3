using GeekBrainsLib;
using System;
using System.Collections.Generic;

namespace HomeWork3
{
    struct ComplexStruct
    {
        double im;
        double re;

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

        public string ToString() => $"{re} + {im}i";


        public static ComplexStruct Parse(string complexValue)
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
            return new ComplexStruct
            {
                re = re,
                im = im
            };
        }

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
                int ndx = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (ndx)
                {
                    default:
                        break;
                    case 1:
                        {
                            Exercise1();
                            break;
                        }
                    case 2:
                        {
                            Exercise2();
                            break;
                        }
                    case 3:
                        {
                            Exercise3();
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
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Взаимодействие с комплексными числами");
                Console.WriteLine("1) -> Структура комплексных чисел");
                Console.WriteLine("2) -> Класс комплексных чисел");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                int ndx = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (ndx)
                {
                    default:
                        break;
                    case 1:
                        {
                            ExecuteComplexWithStruct();
                            break;
                        }
                    case 2:
                        {
                            ExecuteComplexWithStruct();
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

        static void Exercise2()
        {
            Console.WriteLine("Сумма нечетных положительных чисел пока не 0");
            List<string> inData = new List<string>();
            float summ = 0;
            do
            {
                Console.Write("Введите число: ");
                inData.Add(Console.ReadLine());
            }
            while (inData[inData.Count - 1] != "0");
            inData.RemoveAt(inData.Count - 1);

            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Результат выполнения программы");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Подходящие числа:");
            int ndx = 0;
            foreach (string data in inData)
            {
                bool isRight = float.TryParse(data, out float newValue);
                if (isRight)
                {
                    if (newValue % 2 != 0 && newValue > 0)
                    {
                        Console.WriteLine($"{ndx + 1}) -> {newValue}");
                        ndx++;
                        summ += newValue;
                    }
                }
            }
            Console.WriteLine($"Сумма чисел = {summ}");
            ModifiedConsole.Pause();
        }

        static void Exercise3()
        {

        }


        static void ExecuteComplexWithStruct()
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Работа с структуро ComplexStruct");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1) -> Сложение");
                Console.WriteLine("2) -> Вычитание");
                Console.WriteLine("3) -> Произведение");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                int ndx = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (ndx)
                {
                    case 1:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} + {complexValue2.ToString()} = {complexValue1.Plus(complexValue2).ToString()}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} - {complexValue2.ToString()} = {complexValue1.Minus(complexValue2).ToString()}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} * {complexValue2.ToString()} = {complexValue1.Multi(complexValue2).ToString()}");
                            ModifiedConsole.Pause();
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

        static void ExecuteComplexWithClass()
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Работа с классом Complex");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1) -> Сложение");
                Console.WriteLine("2) -> Вычитание");
                Console.WriteLine("3) -> Произведение");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                int ndx = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (ndx)
                {
                    case 1:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} + {complexValue2.ToString()} = {complexValue1 + complexValue2}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Вводимый формат -> a - bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} - {complexValue2.ToString()} = {complexValue1 - complexValue2}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1.ToString()} * {complexValue2.ToString()} = {complexValue1 * complexValue2}");
                            ModifiedConsole.Pause();
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

    }
}
