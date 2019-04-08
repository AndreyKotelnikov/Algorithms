using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static int countOp;

        static void Main(string[] args)
        {
            //Андрей Котельников
            //1.	Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.
            int[] array = { 1, 10, 127, 256, 511, 512 };
            Console.WriteLine("1. Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.");
            Console.WriteLine("Выводим двоичное представление нескольких чисел в диапазоне от -512 до 511:");
            for (int i = 0; i < array.Length; i++)
            {
                countOp = 0;
                Console.WriteLine($"Число {array[i]}:");
                Console.WriteLine($"{ConvertToBinaryRecursion(array[i])} (кол-во операций = {countOp})");
                countOp = 0;
                Console.WriteLine($"Число {-array[i]}:");
                Console.WriteLine($"{ConvertToBinaryRecursion(-array[i])} (кол-во операций = {countOp})");
                Console.WriteLine();
            }

            //2.	Реализовать функцию возведения числа a в степень b:
            //a.Без рекурсии.
            Console.WriteLine("\n\n2. Реализовать функцию возведения числа a в степень b:");
            int a = 2, b = 8;
            countOp = 0;
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine("a.Без рекурсии.");
            Console.WriteLine($"{Power(a, b)} (кол-во операций = {countOp})");

            //b.Рекурсивно.
            countOp = 0;
            Console.WriteLine("\nb.Рекурсивно.");
            Console.WriteLine($"{PowerRecursion(a, b)} (кол-во операций = {countOp})");

            //c.  * Рекурсивно, используя свойство чётности степени.
            countOp = 0;
            Console.WriteLine("\nc. * Рекурсивно, используя свойство чётности степени.");
            Console.WriteLine($"{PowerRecursionEven(a, b)} (кол-во операций = {countOp})");
            countOp = 0;
            Console.WriteLine($"a = {a}, b = {b + 1}");
            Console.WriteLine($"{PowerRecursionEven(a, b + 1)} (кол-во операций = {countOp})");

            //3.  * *Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У исполнителя две команды, 
            //каждой присвоен номер: 
            //1.Прибавь 1.
            //2.Умножь на 2.
            //Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза.Определить, 
            //сколько существует программ, которые преобразуют число 3 в число 20:
            Console.WriteLine("\n\nПервая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза." +
                "\nОпределить, сколько существует программ, которые преобразуют число 3 в число 20:");
            //а.С использованием массива.
            List<int> list = new List<int>();
            countOp = 0;
            int startNumber = 3;
            int endNumber = 20;
            int increment = 1;
            int multiple = 2;
            int[] arr = new int[endNumber + 1];
            arr[startNumber] = 1;
            for (int i = startNumber + 1; i < arr.Length; i++)
            {
                countOp++;
                if (i % multiple == 0) { arr[i] = arr[i - increment] + arr[i / multiple]; }
                else { arr[i] = arr[i - increment]; }
            }

            Console.WriteLine("\nа.С использованием массива:");
            Console.WriteLine($"{arr[endNumber]} (кол-во операций = {countOp})");

            //b. * С использованием рекурсии.
            countOp = 0;
            Console.WriteLine("\nb. *С использованием рекурсии:");
            Console.WriteLine($"{CulcRecursion(3, 20, 1, 2)} (кол-во операций = {countOp})");

            //4. **Найти все возможные способы разбиения N человек на M команд. Команды могут быть пустыми.
            //DivisionBy2Commands(3, 2);
            Console.WriteLine("\n\n4. **Найти все возможные способы разбиения N человек на M команд. Команды могут быть пустыми.");
            int N = 3;
            int M = 3;
            Console.WriteLine($"Выводим разбиение {N} человек по {M} командам:");
            countOp = 0;
            DivisionByCommands(N, M);
            Console.WriteLine($"\nВсего получилось комбинаций: {countOp}");
            //Console.WriteLine(0<<3);

            Console.ReadKey();
        }

        //Функция, которая рекурсией считает все возможные комбинации разбиения N человек на M команд.
        public static void DivisionByCommands(int people, int command, int thisCommand = 0, int previousCommands = 0, int combination = -1, bool print = true)
        {
            if (people < 1) { return; }
            if (combination == -1) { thisCommand = command; }  //Заполняем поле thisCommand при первом запуске функции
            if (thisCommand == 1) { countOp++; }  //Считаем кол-во комбинаций, которые выводятся на экран
            if (!print && thisCommand == 1) { return; }

            //Определяем лимит комбинаций, который нам доступен, с учётом данных по другим командам
            int limit = 0;
            int temp = previousCommands;
            while (temp != 0)
            {
                temp = temp >> people;
                limit += temp % (1 << people); 
            }

            if (thisCommand <= 1) //Если это последняя команда, то переходим к выводу на экран нашей комбинации
            {
                //Сначала в поле кладём комбинацию из последней команды, которая должна заполнить все битовые нули, 
                //оставшиеся от других команд. 
                //Пример: из предыдущих команд у нас получился лимит 5, что означает в бинарной системе 101,
                //поэтому нам нужно заполнить средний 0 единицей: в бинарной системе это 10, а в десятеричной число 2.
                combination = (1 << people) - 1 - limit;
                temp = previousCommands;
                while (command > 0)
                {
                    for (int i = people - 1; i >= 0; i--)
                    {
                        //Проверяем включеность каждого бита и подставляем его номер позиции в бинарной системе исчисления или ноль.
                        if (((combination >> i) & 1) == 1) { Console.Write(people - i); }
                        else { Console.Write(0); }
                    }
                    Console.Write("  ");
                    temp = temp >> people;
                    combination = temp % (1 << people); //Получаем значение игроков из предыдущей команды
                    command--;
                }
                Console.WriteLine();
                return;
            }
            
            //Исключаем из прохода комбинации, которые были уже использованы в предыдущих командах, накладываю маску лимита
            //Например: лимит = 5 (в двоичной: 101), а комбинация = 1 (в двоичной: 001). При логическом "и" получится 001.
            //Ноль получится только если комбинация будет равна 010 или 000 в двоичной системе.
            while ((combination & limit) != 0) { combination++; }

            //Если комбинация превышает количество возможных переборов с учётом ограничений по предыдущим командам, 
            //то выходим из этого вызова функции.
            if (combination > (1 << people) - 1 - limit) { return; }

            //Делаем новый вызов функции со следующей возможной комбинацией в этой же команде
            DivisionByCommands(people, command, thisCommand, previousCommands, combination + 1, print);

            //Проверяем, что это не первый запуск функции
            //И делаем новый вызов функции с передачей предыдущих комбинаций и текущей комбинаций в следующую команду.
            if (combination >= 0)
            {
                DivisionByCommands(people, command, thisCommand - 1, (previousCommands + combination) << people, 0, print);
            }
            return;
        }

        //Старая версия рекурсии, которая работает только на 2-х командах... - кладбище моих функций, которые не взлетели ))
        public static int DivisionBy2Commands(int people, int command, int limit = -1)
        {
            if (command == 1) { limit = (1 << people) -2 - limit; }
            if (limit != -1)
            {
                Console.SetCursorPosition((command - 1) * people + (command - 1) * 2, ((1 << people) - 1) * (command % 2) + ((command + 1) % 2) * limit - (command % 2) * limit);
                //Console.WriteLine();
                //Console.Write($"{command} ");
                for (int i = people - 1; i >= 0; i--)
                {
                    if (((limit >> i) & 1) == 1) { Console.Write(people - i); }
                    else { Console.Write(0); }
                }
            }
            if (command == 1) { return 0; }
            if (limit == (1 << people) - 1) { return 0;  }
            return DivisionBy2Commands(people, command, limit + 1) + DivisionBy2Commands(people, command - 1, limit);
        }

        public static int ConvertToBinaryRecursion(int number)
        {
            countOp++;
            if (number >= 0 && (double)number / 2 < 1) { return number % 2; }
            else if (number >= 0) { return number % 2 + 10 * ConvertToBinaryRecursion(number / 2); }
            else { return ConvertToBinaryRecursion(1024 + number); }
        }

        public static int Power(int number, int power)
        {
            for (int i = 2; i <= power; i++) { number += number; countOp++; }
            return number;
        }

        public static int PowerRecursion(int number, int power)
        {
            countOp++;
            if (power < 2) { return number; }
            return number * PowerRecursion(number, power - 1);
        }

        public static int PowerRecursionEven(int number, int power)
        {
            countOp++;
            if (number == 0) { return 0; }
            if (power == 0) { return 1; }
            if (power == 1) { return number; }
            if (power % 2 == 0) { return PowerRecursionEven(number * number, power / 2); }
            else { return number * PowerRecursionEven(number * number, power / 2); }
        }

        public static int CulcRecursion(int startNumber, int endNumber, int increment, int multipler)
        {
            countOp++;
            if (startNumber == endNumber) { return 1; }
            if (startNumber > endNumber) { return 0; }
            return CulcRecursion(startNumber + increment, endNumber, increment, multipler) +
                CulcRecursion(startNumber * multipler, endNumber, increment, multipler);
        }
    }
}
