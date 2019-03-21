using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public class MyStack<T>
    {
        T[] arr;
        int lastIndex = -1;

        public MyStack(int size)
        {
            arr = new T[size];
        }

        public void Push(T item)
        {
            if (lastIndex < arr.Length - 1) { lastIndex++; arr[lastIndex] = item; }
            else { throw new Exception("Стек полностью заполнен!"); }
            
        }

        public T Pop()
        {
            T value;
            if (lastIndex >= 0) { value = arr[lastIndex]; lastIndex--; }
            else { throw new Exception("Стек пустой!"); }
            return value;
        }

        /// <summary>
        /// Возвращает индекс последнего элемена в Стеке или -1, если Стек пустой
        /// </summary>
        /// <returns>Возвращает индекс последнего элемена в Стеке или -1, если Стек пустой</returns>
        public int GetCurrentIndex()
        {
            return lastIndex;
        }

        public void Clean()
        {
            lastIndex = -1;
        }
    }
}
