using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class MyStack<T>
    {
        T[] arr;
        int lastIndex = -1;

        public MyStack(int size)
        {
            arr = new T[size];
        }

        public void Push()
        {
            if (lastIndex < arr.Length - 1) { lastIndex++; }
            else { throw new Exception("Стек полностью заполнен!"); }
            
        }

        public T Pop()
        {
            if (lastIndex >= 0) { lastIndex--; }
            else { throw new Exception("Стек пустой!"); }
            return arr[lastIndex];
        }

        /// <summary>
        /// Возвращает индекс последнего элемена в Стеке или -1, если Стек пустой
        /// </summary>
        /// <returns>Возвращает индекс последнего элемена в Стеке или -1, если Стек пустой</returns>
        public int GetCurrentIndex()
        {
            return lastIndex;
        }

    }
}
