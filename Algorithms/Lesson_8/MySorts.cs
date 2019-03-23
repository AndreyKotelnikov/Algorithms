using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class MySorts
    {
        public delegate void SortDelegate(ref int[] arr, int startIndex = 0, int endIndex = -10, int avarage = 0);

        private List<int[]> arraysForTest;
        private SortDelegate[] sortMethods;

        public static int CountOp { get; private set; }
        public static int CountSwap { get; private set; }
        public static DateTime StartTime { get; private set; }
        public static DateTime FinishTime { get; private set; }

        public MySorts (int[] numberItemsInArrays, SortDelegate[] sortMethods)
        {
            this.sortMethods = sortMethods;
            arraysForTest = new List<int[]>();
            int[] arr;
            foreach (var item in numberItemsInArrays)
            {
                arr = CreateNewArray(item);
                arraysForTest.Add(arr);
                arr = arr.Clone() as int[];
                Array.Sort(arr, ReversComparer);
                arraysForTest.Add(arr);
                arr = arr.Clone() as int[];
                Array.Sort(arr);
                arraysForTest.Add(arr);
            }
        }

        int ReversComparer(int a, int b) => (a < b) ? 1 : ((a > b) ? -1 : 0);
        

        int[] CreateNewArray(int numberOfItems)
        {
            int[] arr = new int[numberOfItems];
            Random rand = new Random(numberOfItems);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(numberOfItems + 1);
            }
            return arr;
        }

        public void TestSortes()
        {
            Console.WriteLine($"{"Метод", 10}| {"Кол-во эл.",10}| {"Вид массива",14}| {"Сравнения",10}| " +
                $"{"Перестановки",12}| {"Время",10}| {"Сравнения/N",11}|");
            SortDelegate interrupt1 = new SortDelegate(Quick);
            SortDelegate interrupt2 = new SortDelegate(QuickPlus);

            for (int i = 0; i < arraysForTest.Count; i += 3)
            {
                foreach (var sortMethod in sortMethods)
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        CountOp = 0;
                        CountSwap = 0;
                        Console.Write($"{sortMethod.Method.ToString().Substring(5, sortMethod.Method.ToString().IndexOf('(') - 5), 10}| ");
                        Console.Write($"{arraysForTest[j].Length, 10}| ");
                        switch (j % 3)
                        {
                            case 0:
                                Console.Write("      Обычный | ");
                                break;
                            case 1:
                                Console.Write("     Обратный | ");
                                break;
                            case 2:
                                Console.Write("Сортированный | ");
                                break;
                            default:
                                break;
                        }
                        int[] arr = arraysForTest[j].Clone() as int[];
                        StartTime = DateTime.Now;
                        sortMethod(ref arr);
                        FinishTime = DateTime.Now;
                        
                        //Print(arr);
                        Console.WriteLine
                            ($"{((CountOp >= 45000000 && sortMethod == interrupt1) || (CountOp >= 50000000 && sortMethod == interrupt2) ? "Прерывание" : CountOp.ToString()), 10}| " +
                            $"{CountSwap, 12}| " +
                            $"{(int)(FinishTime - StartTime).TotalMilliseconds, 10}| {CountOp / arr.Length, 11}|");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public void TestSortesСompareTable()
        {

            for (int i = 0; i < arraysForTest.Count; i += 3)
            {
                foreach (var sortMethod in sortMethods)
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        CountOp = 0;
                        CountSwap = 0;

                        switch (j % 3)
                        {
                            case 0:
                                Console.Write($"      Обычный [{arraysForTest[j].Length}]: ");
                                break;
                            case 1:
                                Console.Write($"     Обратный [{arraysForTest[j].Length}]: ");
                                break;
                            case 2:
                                Console.Write($"Сортированный [{arraysForTest[j].Length}]: ");
                                break;
                            default:
                                break;
                        }
                        int[] arr = arraysForTest[j].Clone() as int[];
                        StartTime = DateTime.Now;
                        sortMethod(ref arr);
                        FinishTime = DateTime.Now;
                        Print(arr);
                        Console.WriteLine($"compare = {CountOp}, Свопов = {CountSwap}, " +
                            $"Время миллисекунд = {(int)(FinishTime - StartTime).TotalMilliseconds}, CountOp/N = {CountOp / arr.Length}," +
                            $" {sortMethod.Method.ToString().Substring(5, sortMethod.Method.ToString().IndexOf('(') - 5)}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static int BinarySearch(int item, ref int[] arr)
        {
            CountOp = 0;
            int L = 0;
            int R = arr.Length - 1;
            int index;
            while (L != R)
            {
                CountOp++;
                index = L + (R - L) / 2;
                if (arr[index] == item) { return index; }
                if (arr[index] > item) { R = index - 1; }
                else { L = index + 1; }
            }
            return -1;
        }


        public static void Shaker(ref int[] arr, int noUsed1 = 0, int noUsed2 = 0, int noUsed3 = 0)
        {
            int flagSwap = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                CountOp++;
                for (int j = i + 1; j < arr.Length - i; j++)
                {
                    CountOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        CountSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        flagSwap = 1;
                    }
                }
                if (flagSwap == 0) { break; } else { flagSwap = 0; }
                for (int j = arr.Length - 2 - i; j > i; j--)
                {
                    CountOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        CountSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        flagSwap = 1;
                    }
                }
                if (flagSwap == 0) { break; } else { flagSwap = 0; }
            }
        }

        public static void Buble(ref int[] arr, int noUsed1 = 0, int noUsed2 = 0, int noUsed3 = 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                CountOp++;
                for (int j = 1; j < arr.Length; j++)
                {
                    CountOp++;
                    if (arr[j - 1] > arr[j]) { CountSwap++; arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j]; }
                }
            }
        }

        public static void BublePlus(ref int[] arr, int noUsed1 = 0, int noUsed2 = 0, int noUsed3 = 0)
        {
            int flagSwap = 0;
            int indexJamp = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                CountOp++;
                for (int j = 1; j < arr.Length - count; j++)
                {
                    CountOp++;
                    if (arr[j - 1] > arr[j])
                    {
                        CountSwap++;
                        arr[j - 1] ^= arr[j]; arr[j] ^= arr[j - 1]; arr[j - 1] ^= arr[j];
                        if (flagSwap == 0) { indexJamp = j + 1; }
                        flagSwap = 1;
                    }

                }
                count++;
                i = indexJamp - 1;
                if (flagSwap == 0) { break; }
                else flagSwap = 0;
            }
        }

        public void Print()
        {
            foreach (var arr in arraysForTest)
            {
                foreach (var item in arr)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        public void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        public static void Quick(ref int[] arr, int startIndex = 0, int endIndex = -10, int noUsed = 0)
        {
            if (endIndex == -10) { endIndex = arr.Length - 1; }
            if (startIndex >= endIndex) { return; }
            int wall = startIndex - 1;
            int pillar = arr[endIndex];
            int temp;
            for (int i = startIndex; i <= endIndex; i++)
            {
                CountOp++;
                if (CountOp == 45000000) { return; }
                if (arr[i] <= pillar)
                {
                    if (i == wall + 1)
                    {
                        wall++;
                    }
                    else
                    {
                        CountSwap++;
                        temp = arr[wall + 1];
                        arr[wall + 1] = arr[i];
                        arr[i] = temp;
                        wall++;
                    }
                }
            }
            if (wall - startIndex > 0) { Quick(ref arr, startIndex, wall - 1); }
            if (endIndex - wall > 0) { Quick(ref arr, wall + 1, endIndex); }
        }

        public static void QuickPlus(ref int[] arr, int startIndex = 0, int endIndex = -10, int avarage = 0)
        {
            if (endIndex == -10) { endIndex = arr.Length - 1; avarage = arr[endIndex]; }
            if (startIndex >= endIndex) { return; }
            int wall = startIndex - 1;
            int pillar = avarage;
            int leftSum = 0;
            int rightSum = 0;
            int temp;
            for (int i = startIndex; i <= endIndex; i++)
            {
                CountOp++;
                if (CountOp >= 50000000) {
                    return; }
                if (arr[i] <= pillar)
                {
                    if (i == wall + 1)
                    {
                        wall++;
                        leftSum += arr[i];
                    }
                    else
                    {
                        leftSum += arr[i];
                        CountSwap++;
                        temp = arr[wall + 1];
                        arr[wall + 1] = arr[i];
                        arr[i] = temp;
                        wall++;
                    }
                }
                else { rightSum += arr[i]; }
            }
            if (wall - startIndex > 0)
                { QuickPlus(ref arr, startIndex, arr[wall] == pillar ? wall - 1 : wall, leftSum / (wall - startIndex + 1)); }
            if (endIndex - wall > 1) { QuickPlus(ref arr, wall + 1, endIndex, rightSum / (endIndex - wall)); }
        }
    }
}
