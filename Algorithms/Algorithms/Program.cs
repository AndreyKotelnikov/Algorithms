using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Котельников Андрей
            //14. * Автоморфные числа.Натуральное число называется автоморфным, если оно равно последним цифрам 
            //своего квадрата. Например, 25 \ :sup: '2' = 625.Напишите программу, 
            //которая получает на вход натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
            const ulong N = 299999999999999; //19 знаков
            const int power = 2;
            List<ulong> listOfNumbers = new List<ulong>();
            List<ulong> listForPrint = new List<ulong>();

            int temp = 0;

            //Заполняем Лист полиморфными цифрами
            for (ulong i = 0; i < 10; i++)
            {
                if (CompareDigits((ulong)Math.Pow(i, power), i)) { listOfNumbers.Add(i); } 
            }

            foreach (var item in listOfNumbers)
            {
                if (item > N) { temp = -1; break; }
                listForPrint.Add(item);
            }
            
            //Ищем полиморфные цифры в более старших разрядах числа
            if (temp != -1)
            {
                for (int i = 0; i < listOfNumbers.Count; i++)
                {
                    temp = NextNumberPolymorphic(listOfNumbers[i], power, N);
                    if (temp != -1)
                    {
                        listOfNumbers[i] = AddFirstDigit(temp, listOfNumbers[i]);
                        listForPrint.Add(listOfNumbers[i]); i--; 
                    }
                }
            }

            Console.WriteLine($"Задание 14*: выводим автоморфные числа ({listForPrint.Count} шт.), не превосходящие {N}:");
            listForPrint.Sort();
            foreach (var item in listForPrint)
            {
                Console.Write($"{item} ");
            }
            

            Console.ReadKey();

        }

        public static int NextNumberPolymorphic(ulong number, int power, ulong limit)
        {
            decimal poweredNumber;
            ulong lastDigitsOfPoweredNumber;
            int numberOfDigits;
            ulong upgradeNumber;
            
            for (int i = 1; i < 1000; i++)
            {
                upgradeNumber = AddFirstDigit(i, number);
                if (upgradeNumber > limit) { return -1; }
                if (upgradeNumber == 40081787109376)
                {
                    ;
                }

                numberOfDigits = upgradeNumber.ToString().Length;
                if (power == 2) { poweredNumber = (decimal)upgradeNumber * (decimal)upgradeNumber; }
                else { poweredNumber = (decimal)Math.Pow(upgradeNumber, power); }
                lastDigitsOfPoweredNumber = 
                    ulong.Parse(poweredNumber.ToString("0").Substring(poweredNumber.ToString("0").Length - numberOfDigits));
                if (CompareDigits((ulong)lastDigitsOfPoweredNumber, upgradeNumber))
                {   return i;   }
            }
            return -1;
        }

        public static ulong AddFirstDigit(int firstDigit, ulong number)
        {
            int numberOfDigits = number.ToString().Length;
            return (ulong)(firstDigit * Math.Pow(10, numberOfDigits)) + number;
        }


        public static bool CompareDigits(ulong bigNumber, ulong smallNumber)
        {
            if (bigNumber == smallNumber) { return true; }
            while (smallNumber > 0)
            {
                if (smallNumber % 10 != bigNumber % 10) { return false; }
                smallNumber /= 10;
                bigNumber /= 10;
            }
            return true;
        }
    }
}
