using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class ArithmeticExpression
    {
        MyStack<int> numberStack;
        MyStack<char> charStack;
        string inficsString;
        string postficsString;
        char[] operators = { '+', '-', '*', '/' };
        char[] brackets = { '(', ')', '[', ']', '{', '}' };

        public ArithmeticExpression(string inficsString)
        {
            this.inficsString = inficsString;
            numberStack = new MyStack<int>(inficsString.Length / 2 + 1);
            charStack = new MyStack<char>(inficsString.Length);
        }

        public bool CheckSymbols(string arithmExp)
        {
            foreach (var item in arithmExp)
            {
                 if (Char.IsDigit(item) || operators.Contains(item)) || brackets.Contains(item))
            }
        }

    }
}
