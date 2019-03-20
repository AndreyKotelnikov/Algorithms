using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    class Graf
    {
        private int[,] weightMatrix;

        public Graf(int numberOfVertices)
        {
            weightMatrix = new int[numberOfVertices, numberOfVertices];
        }

        public void SetEdge(int firstVertice, int secondVertice, int weight, bool direction = false)
        {
            weightMatrix[firstVertice, secondVertice] = weight;
            if (!direction) { weightMatrix[secondVertice, firstVertice] = weight; }
        }

        public void PrintMatrix()
        {
            Console.Write("   ");
            for (int i = 0; i < weightMatrix.GetLength(0); i++)
            {
                Console.Write($"{i, 2} ");
            }
            Console.WriteLine();
            for (int i = 0; i < weightMatrix.GetLength(1); i++)
            {
                Console.Write($"{i,2} ");
                for (int j = 0; j < weightMatrix.GetLength(0); j++)
                {
                    Console.Write($"{(i == j ? "-" : weightMatrix[i, j].ToString()), 2} ");
                }
                Console.WriteLine();
            }
        }

    }
}
