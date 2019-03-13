using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Котельников Андрей
            //5.	*Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
            //Решение:
            //Вводим арифметическое выражение и проверяем его на корректность символов парность скобок
            string userInput;
            while (true)
            {
                Console.WriteLine("Введите арифметическое выражение:");
                userInput = Console.ReadLine();
                if (!ArithmeticExpression.CheckSymbols(userInput)) { Console.WriteLine("Выражение содержит недопустимые символы!"); continue; }
                if (!ArithmeticExpression.CheckBrackets(userInput)) { Console.WriteLine("Выражение содержит ошибки в выставлении скобок!"); }
                if (!ArithmeticExpression.CheckOperators(userInput)) { Console.WriteLine("Выражение содержит ошибки в указании операторов!"); }
                else { break; }
            }
            Console.WriteLine("\nВыражение введено корректно.");
            //Делаем вычисления выражения и выводим в консоль
            ArithmeticExpression expr = new ArithmeticExpression(userInput);
            try
            {
                Console.WriteLine($"\nПостфиксная форма выражения: {expr.ConvertInficsToPostfics()}");
                Console.WriteLine($"\nЗначение выражения: {expr.СalculateExpression()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
