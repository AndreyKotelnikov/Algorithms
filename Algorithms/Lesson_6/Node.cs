using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    /// <summary>
    /// Узел бинарного дерева: имеет поле для хранения ключа data и 3 ссылки на родителя и сыновей.
    /// </summary>
    class Node
    {
        internal int Data { get; private set; }
        internal Node Left { get; set; }
        internal Node Right { get; set; }
        internal Node Parent { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }
}
