using GeekBrainsLib;
using System;
using System.Collections.Generic;

namespace HomeWork3
{
    enum OperationMenuSelectType
    {
        toAddition = 1,
        toSubtraction = 2,
        toMultiplication = 3,
        toDivision = 4, 
        toDecimal = 5,
        toNod = 6,
        back = 0
    }

    /// <summary>
    /// Структура комплексных чисел
    /// </summary>
    struct ComplexStruct
    {
        double im;
        double re;
        
        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Plus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        /// <summary>
        /// Операция вычитания
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Minus(ComplexStruct x)
        {
            ComplexStruct y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }

        /// <summary>
        /// Операция умножения
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ComplexStruct Multi(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public override string ToString() => $"{re} + {im}i";

        /// <summary>
        /// Преобразование строки в ComplexStruct
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ComplexStruct Parse(string complexValue)
        {
            string[] elemArray = complexValue.Split(' ', '+');
            return new ComplexStruct
            {
                re = double.Parse(elemArray[0]),
                im = double.Parse(elemArray[1].Replace('i', ' '))
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
                if(int.TryParse(Console.ReadLine(), out int ndx))
                {
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
                else
                {
                    Console.Clear();
                    ModifiedConsole.Print("Формат ввода неверен!");
                    ModifiedConsole.Pause();
                }
            }

        }

        /// <summary>
        /// Задание 1 -> Работа с структурой или классом комплексных чисел
        /// </summary>
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
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
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
                                ExecuteComplexWithClass();
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    ModifiedConsole.Print("Формат ввода неверен!");
                    ModifiedConsole.Pause();
                }
            }
        }

        /// <summary>
        /// Задание 2 -> Вывод нечётных положительных чисел и их суммы
        /// </summary>
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

        /// <summary>
        ///  Задание 3 -> Работа с классом дробей
        /// </summary>
        static void Exercise3()
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Работа с дробными числами");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1) -> Сложение");
                Console.WriteLine("2) -> Вычитание");
                Console.WriteLine("3) -> Произведение");
                Console.WriteLine("4) -> Деление");
                Console.WriteLine("5) -> Преобразование в десятичное число");
                Console.WriteLine("6) -> Упрощение дробей");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                OperationMenuSelectType selectType = (OperationMenuSelectType)int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selectType)
                {
                    default:
                        break;
                    case OperationMenuSelectType.toAddition:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите первое дробное число: ");
                            Fraction fraction1 = Fraction.Parse(Console.ReadLine());

                            Console.Write("Введите второе дробное число: ");
                            Fraction fraction2 = Fraction.Parse(Console.ReadLine());

                            string result = (fraction1 + fraction2).Numerator == 0 ? "0" : (fraction1 + fraction2).ToString();
                            Console.WriteLine($"( {fraction1} ) + ( {fraction2} ) = {result}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toSubtraction:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите первое дробное число: ");
                            Fraction fraction1 = Fraction.Parse(Console.ReadLine());

                            Console.Write("Введите второе дробное число: ");
                            Fraction fraction2 = Fraction.Parse(Console.ReadLine());

                            string result = (fraction1 - fraction2).Numerator == 0 ? "0" : (fraction1 - fraction2).ToString();
                            Console.WriteLine($"( {fraction1} ) - ( {fraction2} ) = {result}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toMultiplication:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите первое дробное число: ");
                            Fraction fraction1 = Fraction.Parse(Console.ReadLine());

                            Console.Write("Введите второе дробное число: ");
                            Fraction fraction2 = Fraction.Parse(Console.ReadLine());

                            string result = (fraction1 * fraction2).Numerator == 0 ? "0" : (fraction1 * fraction2).ToString();
                            Console.WriteLine($"( {fraction1} ) * ( {fraction2} ) = {result}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toDivision:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите первое дробное число: ");
                            Fraction fraction1 = Fraction.Parse(Console.ReadLine());

                            Console.Write("Введите второе дробное число: ");
                            Fraction fraction2 = Fraction.Parse(Console.ReadLine());

                            string result = (fraction1 / fraction2).Numerator == 0 ? "0" : (fraction1 / fraction2).ToString();
                            Console.WriteLine($"( {fraction1} ) / ( {fraction2} ) = {result}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toDecimal:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите дробное число: ");
                            Fraction fraction = Fraction.Parse(Console.ReadLine());

                            Console.WriteLine($"Десятичное представление {fraction} = {fraction.Decimal}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toNod:
                        {
                            Console.WriteLine("Вводимый формат -> a / b");
                            Console.Write("Введите дробное число: ");
                            Fraction fraction = Fraction.Parse(Console.ReadLine());

                            Console.WriteLine($"Упрощение дроби: {fraction.Normalize()}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.back:
                        {
                            isWork = false;
                            break;
                        }
                }
            }
        }


        static void ExecuteComplexWithStruct()
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Работа с структурой ComplexStruct");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1) -> Сложение");
                Console.WriteLine("2) -> Вычитание");
                Console.WriteLine("3) -> Произведение");
                Console.WriteLine("0) -> Назад");
                Console.Write("Введите номер пункта: ");
                OperationMenuSelectType selectType = (OperationMenuSelectType)int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selectType)
                {
                    case OperationMenuSelectType.toAddition:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} + {complexValue2} = {complexValue1.Plus(complexValue2)}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toSubtraction:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} - {complexValue2} = {complexValue1.Minus(complexValue2)}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toMultiplication:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            ComplexStruct complexValue1 = ComplexStruct.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            ComplexStruct complexValue2 = ComplexStruct.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} * {complexValue2} = {complexValue1.Multi(complexValue2)}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.back:
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
                OperationMenuSelectType selectType = (OperationMenuSelectType)int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selectType)
                {
                    case OperationMenuSelectType.toAddition:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} + {complexValue2} = {complexValue1 + complexValue2}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toSubtraction:
                        {
                            Console.WriteLine("Вводимый формат -> a - bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} - {complexValue2} = {complexValue1 - complexValue2}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.toMultiplication:
                        {
                            Console.WriteLine("Вводимый формат -> a + bi");
                            Console.Write("Введите первое комплексное число: ");
                            Complex complexValue1 = Complex.Parse(Console.ReadLine());

                            Console.Write("Введите второе комплексное число: ");
                            Complex complexValue2 = Complex.Parse(Console.ReadLine());

                            Console.WriteLine($"{complexValue1} * {complexValue2} = {complexValue1 * complexValue2}");
                            ModifiedConsole.Pause();
                            break;
                        }
                    case OperationMenuSelectType.back:
                        {
                            isWork = false;
                            break;
                        }
                }
            }
        }

    }
}
