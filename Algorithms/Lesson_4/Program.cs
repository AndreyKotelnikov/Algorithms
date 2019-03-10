using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class Program
    {
        static decimal countOp = 0;
        static int[,] moves = {
            {  2,  1} , {  2, -1},
            {  1,  2} , { -1,  2},
            { -2, -1} , { -2,  1},
            { -1, -2} , {  1, -2} };

        //static int[,] moves = {
        //    {  2, -1}, 
        //    { -1,  2}, 
        //    { -2,  1}, 
        //    {  1, -2}, 
        //    {  2,  1},
        //    {  1,  2},
        //    { -2, -1},
        //    { -1, -2}};

        static void Main(string[] args)
        {
            //3. ***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу. 
            //Здесь алгоритм решения такой же, как и в задаче о 8 ферзях.Разница только в проверке положения коня.
            int N = 70;
            int M = 69;
            int startN = 7;
            int startM = 7;
            int[,] bourd = new int[N + 1, M + 1];
            DateTime start = DateTime.Now;
            if (SolutionToMoveHorse(startN, startM, N, M, ref bourd, ref moves))
            {
                for (int i = 1; i <= N * M; i++)
                {
                    for (int j = 1; j < bourd.GetLength(0); j++)
                    {
                        for (int k = 1; k < bourd.GetLength(1); k++)
                        {
                            if (bourd[j, k] == i)
                            { Console.WriteLine($"Ход {i, 2}: {j} {k}"); j = bourd.GetLength(0); break; }
                        }
                    }
                }
            }
            else { Console.WriteLine($"Решение для доски размером {N} x {M} не существует."); }
            Console.WriteLine($"\nРазмер доски {N} x {M}.");
            Console.WriteLine($"Начальное положение коня {startN} {startM}.");
            Console.WriteLine($"\nКоличество операций = {countOp}");
            DateTime finish = DateTime.Now;
            //Console.WriteLine($"Время работы алгоритма в минутах {(finish - start).TotalMinutes}");
            Console.WriteLine($"Время работы алгоритма в секундах {(finish - start).TotalSeconds}");
            Console.WriteLine($"Время работы алгоритма в миллиxсекундах {(finish - start).TotalMilliseconds}");
            Console.ReadKey();
        }

        private static bool SolutionToMoveHorse(int startN, int startM, int n, int m, ref int[,] bourd, ref int[,] moves, int number = 1)
        {
            countOp++;
            //if (startN < 1 || startM < 1 || startN >= bourd.GetLength(0) || startM >= bourd.GetLength(1)) { return false; }
            //if (bourd[startN, startM] != 0) { return false; }
            bourd[startN, startM] = number;
            if (number >= n * m) {  return true; }
            //int partOfBoard = startN < n / 2 ? startM < n / 2 ? 0 : 2 : startM > n / 2 ? 4 : 6;

            //for (int i = 1; i <= 8; i++)
            //{
            //    if (SolutionToMoveHorse(startN + moves[partOfBoard, 0], startM + moves[partOfBoard, 1], n, m, ref bourd, number + 1))
            //    { return true; };
            //    partOfBoard++;
            //    if (partOfBoard == moves.GetLength(0)) { partOfBoard = 0; }
            //}
            int index;
            int[] moveList = new int[moves.GetLength(0)];
            for (int i = 0; i < moves.Length; i++)
            {
                index = GreedyAlgorithm(startN, startM, ref moveList, ref moves, ref bourd);
                if (index < 0) { break; }
                moveList[index] = -2;
                if (SolutionToMoveHorse(startN + moves[index, 0], startM + moves[index, 1], n, m, ref bourd, ref moves, number + 1))
                { return true; };
            }
            bourd[startN, startM] = 0;
            return false; 
        }

        private static int GreedyAlgorithm(int startN, int startM, ref int[] moveList, ref int[,] moves, ref int[,] bourd)
        {
            for (int i = 0; i < moveList.Length; i++)
            {
                countOp++;
                if (moveList[i] < 0) { continue; }
                if (startN + moves[i, 0] < 1 || startM + moves[i, 1] < 1 || startN + moves[i, 0] >= bourd.GetLength(0) 
                    || startM + moves[i, 1] >= bourd.GetLength(1)) { moveList[i] = -1; continue; }
                if (bourd[startN + moves[i, 0], startM + moves[i, 1]] != 0) { moveList[i] = -2; continue; }
                moveList[i] = CountMoves(startN + moves[i, 0], startM + moves[i, 1], ref moves, ref bourd);
            }
            int min = moveList.Length + 1;
            int index = -1;
            for (int i = 0; i < moveList.Length; i++)
            {
                countOp++;
                if (moveList[i] < 0) { continue; }
                if (min > moveList[i]) { min = moveList[i]; index = i; }
            }
            return index;
        }

        private static int CountMoves(int startN, int startM, ref int[,] moves, ref int[,] bourd)
        {
            int countMoves = 0;
            bourd[startN, startM] = 1;
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                countOp++;
                if (startN + moves[i, 0] < 1 || startM + moves[i, 1] < 1 || startN + moves[i, 0] >= bourd.GetLength(0)
                    || startM + moves[i, 1] >= bourd.GetLength(1)) { continue; }
                if (bourd[startN + moves[i, 0], startM + moves[i, 1]] != 0) { continue; }
                countMoves++;
            }
            bourd[startN, startM] = 0;
            return countMoves;
        }
    }
}
