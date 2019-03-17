using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    /// <summary>
    /// Бинарное дерево
    /// </summary>
    class BinaryTree
    {
        public Node Root { get; private set; }
        public int CountNodes { get; private set; }
        public int Height { get; private set; } // Считает по максимальному количеству узлов в глубину 

        public BinaryTree(Node root)
        {
            Root = root;
            CountNodes = 1;
            Height = 1;
        }

        /// <summary>
        /// Добавляет элемент в дерево, вычисляя сразу нужное место, чтобы сохранялось свойство: все элементы меньше слева, все больше - справа
        /// </summary>
        /// <param name="newNode">Узел, который нужно добавить в дерево</param>
        /// <param name="nodeInTree">Текщий узел дерева, с которым сравниваем ключ нового узла</param>
        /// <param name="depth">Текущия глубина (высота) дерева относительно корня</param>
        public void AddNode(Node newNode, Node nodeInTree = null, int depth = 2)
        {
            if (nodeInTree == null) { nodeInTree = Root; depth = 2; CountNodes++; }
            if (newNode.Data > nodeInTree.Data)
            {
                if (nodeInTree.Right != null) { AddNode(newNode, nodeInTree.Right, depth + 1); }
                else
                {
                    nodeInTree.Right = newNode;
                    newNode.Parent = nodeInTree;
                    if (depth > Height) { Height = depth; }
                }
            }
            if (newNode.Data <= nodeInTree.Data)
            {
                if (nodeInTree.Left != null) { AddNode(newNode, nodeInTree.Left, depth + 1); }
                else
                {
                    nodeInTree.Left = newNode;
                    newNode.Parent = nodeInTree;
                    if (depth > Height) { Height = depth; }
                }
            }
        }

        /// <summary>
        /// Выводим дерево в виде иерархической структуры - каждый новый уровень высоты на новой строчке консоли
        /// </summary>
        /// <param name="node">Узел, который нужно вывести в консоль</param>
        /// <param name="depth">Текущая глубина (высота) на которой находится узел относительно корня</param>
        /// <param name="count">Индекс узла по формуле: переход к левому сыну = count*2, переход к правому сыну = count*2 + 1</param>
        /// <param name="xCursor">Позиция курсора по оси X перед началом вывода в консоль</param>
        /// <param name="yCursor">Позиция курсора по оси Y перед началом вывода в консоль</param>
        public void Print(Node node = null, int depth = 1, int count = 1, int xCursor = 0, int yCursor = 0)
        {
            if (node == null)
            {
                node = Root;
                depth = 1;
                count = 1;
                xCursor = Console.CursorLeft;
                yCursor = Console.CursorTop;
            }
            Console.CursorTop = yCursor + depth - 1;
            // Для вывода значения каждого узла выделяем длину в 4 позиций.
            if (Height == depth)
            {
                Console.CursorLeft = xCursor + (count - (1 << (depth - 1))) * 4;
            }
            else
            {
                Console.CursorLeft = xCursor + (int)(((double)(1<<(Height - depth - 1)) - 0.5) * 4)
                    + (1 << (Height - depth)) * (count - (1 << (depth - 1))) * 4;
            }
            Console.Write($"[{node.Data, 2}]");
            
            if (node.Left != null) { Print(node.Left, depth + 1, count * 2 , xCursor, yCursor); }
            if (node.Right != null) { Print(node.Right, depth + 1, count * 2 + 1, xCursor, yCursor); }
            if (node == Root) { Console.CursorLeft = xCursor; Console.CursorTop = yCursor + Height + 1; }
        }

        /// <summary>
        /// Рассчитывает максимальную высоту узла по правой и левой ветке
        /// </summary>
        /// <param name="node">Узел, для которого нужно рассчитать максимальную высоту</param>
        /// <returns>Возвращает максимальную высоту узла по правой и левой ветке</returns>
        public int MaxHeightOfNode(Node node)
        {
            if (node.Left != null && node.Right != null)
            {
                int a = MaxHeightOfNode(node.Left);
                int b = MaxHeightOfNode(node.Right);
                return a > b ? a + 1 : b + 1;
            }
            if (node.Left != null && node.Right == null) { return 1 + MaxHeightOfNode(node.Left); }
            if (node.Right != null && node.Left == null) { return 1 + MaxHeightOfNode(node.Right); }
            return 1;
        }

        public int CountOfNode(Node node)
        {
            if (node.Left != null && node.Right == null) { return 1 + MaxHeightOfNode(node.Left); }
            if (node.Right != null && node.Left == null) { return 1 + MaxHeightOfNode(node.Right); }
            return 1;
        }

        /// <summary>
        /// Делает одну ротацию узла вправо: левый сын становится родителем узла, правая ветка от левого сына переходит к левую ветку узла. 
        /// </summary>
        /// <param name="node">Узел, для которого нужно сделать ротацию со своим левым сыном</param>
        public void RoteteRight(Node node)
        {
            Node left = node.Left;
            if (node.Parent != null)
            {
                if (node.Parent.Left == node) { node.Parent.Left = left; }
                else if (node.Parent.Right == node) { node.Parent.Right = left; }
            }
            else { Root = left; }
            left.Parent = node.Parent;
            node.Parent = left;
            node.Left = left.Right;
            left.Right = node;
        }

        /// <summary>
        /// Делает одну ротацию узла влево: правый сын становится родителем узла, левая ветка от правого сына переходит к правую ветку узла. 
        /// </summary>
        /// <param name="node">Узел, для которого нужно сделать ротацию со своим левым сыном</param>
        public void RoteteLeft(Node node)
        {
            Node right = node.Right;
            if (node.Parent != null)
            {
                if (node.Parent.Left == node) { node.Parent.Left = right; }
                else if (node.Parent.Right == node) { node.Parent.Right = right; }
            }
            else { Root = right; }
            right.Parent = node.Parent;
            node.Parent = right;
            node.Right = right.Left;
            right.Left = node;
        }

        /// <summary>
        /// Проверяем для указанного узла разность высоты деревьев левого и правого сыновей, если она больше 1, то вызываем соответствующую ротацию узлов.
        /// </summary>
        /// <param name="node">Узел, ветви которого нужно сбалансировать</param>
        public void BalanceTree(Node node = null, int count = 0)
        {
            bool flag = false;
            if (node == null) { node = Root; flag = true; }
            while (true)
            {
                int heightLeft = node.Left == null ? 0 : MaxHeightOfNode(node.Left);
                int heightRight = node.Right == null ? 0 : MaxHeightOfNode(node.Right);
                int countLeft = node.Left == null ? 0 : CountOfNode(node.Left);
                int countRight = node.Right == null ? 0 : CountOfNode(node.Right);

                if (heightLeft > heightRight || (countLeft - countRight) > 1)
                {  RoteteRight(node);  }
                else if (heightLeft < heightRight || (countRight - countLeft) > 1)
                { RoteteLeft(node); }
                else { break; }
            }
            if (node.Left != null) { BalanceTree(node.Left); }
            if (node.Right != null) { BalanceTree(node.Right); }
            
            if (flag == true)
            {
                int differenceHeight = Math.Abs((Root.Left == null ? 0 : MaxHeightOfNode(Root.Left)) - (Root.Right == null ? 0 : MaxHeightOfNode(Root.Right)));
                int differenceCount = Math.Abs((node.Left == null ? 0 : CountOfNode(node.Left)) - (node.Right == null ? 0 : CountOfNode(node.Right)));
                if (differenceHeight > 1 || differenceCount > 1) { BalanceTree(null); }
                if (differenceHeight <= 1 && differenceCount <= 1 && count < 2) { BalanceTree(null, count + 1); }
                if (differenceHeight <= 1 && differenceCount <= 1 && count >= 2)
                { Height = MaxHeightOfNode(Root); }
            }
            return;
        }

        /// <summary>
        /// Производит бинарный поиск по дереву и возвращает индекс элемента, который рассчитан по формуле: переход к левому сыну = index*2, переход к правому сыну = index*2 + 1
        /// </summary>
        /// <param name="data">Ключ, по которому нужно найти соответствующий узел</param>
        /// <param name="node">Текущий узел для проверки совпадения ключа</param>
        /// <param name="index">Индекс элемента, который рассчитан по формуле: переход к левому сыну = index*2, переход к правому сыну = index*2 + 1</param>
        /// <returns>Возвращает индекс элемента, который рассчитан по формуле: переход к левому сыну = index*2, переход к правому сыну = index*2 + 1</returns>
        private int BinarySearch(int data, Node node = null, int index = 1)
        {
            if (node ==null) { node = Root; index = 1; }
            if (data == node.Data) { return index; }
            if (data > node.Data)
            {
                if (node.Right != null) { return BinarySearch(data, node.Right, index * 2 + 1); }
                else { return 0; }
            }
            if (data < node.Data)
            {
                if (node.Left != null) { return BinarySearch(data, node.Left, index * 2); }
                else { return 0; }
            }
            return 0;
        }

        /// <summary>
        /// Интерфейс для организации работы с поиском по дереву через консоль: ввод значения от пользователя и вывод результата
        /// </summary>
        public void SearchInterface()
        {
            int data;
            while (true)
            {
                Console.WriteLine("Укажите значение, которое нужно найти:");
                if (int.TryParse(Console.ReadLine(), out data)) { break; }
                else { Console.WriteLine("Указано некорректное значение, попробуйте ещё раз..."); }
            }
            int index = BinarySearch(data);
            int str = (int)Math.Log(index, 2) + 1;
            int pos = index - (1 << (str - 1)) + 1;

            if (index != 0)
            {
                Console.WriteLine($"Элемент находится в {str} строке, на {pos} позиции слева, которые есть в этой строке.");
            }
            else { Console.WriteLine("Такой элемент отсутствует в нашем дереве."); }
        }
    }
}
