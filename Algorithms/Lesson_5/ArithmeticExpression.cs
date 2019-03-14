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
        static char[] operators = { '+', '-', '*', '/' };
        static char[] brackets = { '(', ')', '[', ']', '{', '}' };  //Указываем по очереди открывающую, а потом для неё закрывающую скобку

        public ArithmeticExpression(string inficsString)
        {
            string str = string.Empty;
            foreach (var item in inficsString)
            {
                if (item == ' ') { continue; }
                str += item;
            }
            if (!(CheckSymbols(str) && CheckBrackets(str) && CheckOperators(str))) {
                throw new Exception("Некорректное арифметическое выражение!"); }
            this.inficsString = str;
            numberStack = new MyStack<int>(str.Length / 2 + 1);
            charStack = new MyStack<char>(str.Length);
        }

        public string ConvertInficsToPostfics()
        {
            postficsString = string.Empty;
            СalculateExpression(true);
            return postficsString;
        }

        public int СalculateExpression(bool onlyConvert = false)
        {
            numberStack.Clean();
            charStack.Clean();
            string number = string.Empty;
            int countNewNumber = 0;
            for (int index = 0; index < inficsString.Length; index++)
            {
                if (numberStack.GetCurrentIndex() == -1)
                {
                    ;
                }
                if (index == 5)
                {
                    ;
                }

                if (char.IsDigit(inficsString[index]))
                {
                    number += inficsString[index];
                    continue;
                }
                else if (number != string.Empty)
                {
                    numberStack.Push(int.Parse(number));
                    countNewNumber++;
                    number = string.Empty;
                }

                if (operators.Contains(inficsString[index]))
                {
                    charStack.Push(inficsString[index]);
                    continue;
                }

                for (int i = 0; i < brackets.Length; i += 2)
                {
                    if (inficsString[index] == brackets[i]) { continue; }
                }

                for (int i = 1; i < brackets.Length; i += 2)
                {
                    if (inficsString[index] == brackets[i])
                    {
                        if (onlyConvert)
                        {
                            int temp1, temp2;
                            temp1 = numberStack.Pop();
                            temp2 = numberStack.Pop();
                            if (temp2 != int.MinValue) { postficsString += $"{temp2} "; }
                            if (temp1 != int.MinValue) { postficsString += $"{temp1} "; }
                            postficsString += $"{charStack.Pop()} ";
                            numberStack.Push(int.MinValue);
                            continue;
                        }
                        else
                        {
                            numberStack.Push(PerformOperation(countNewNumber == 0));
                            countNewNumber = 0;
                            continue;
                        }
                    }
                }
            }
            if (onlyConvert) { return 0; }
            if (numberStack.GetCurrentIndex() != 0 || charStack.GetCurrentIndex() != -1)
            {
                throw new Exception("Ошибка при работе метода ConvertInficsToPostfics!");
            }
            else { return numberStack.Pop(); }
        }

        private int PerformOperation(bool isResult)
        {
            int temp;
            switch (charStack.Pop())
            {
                case '+':
                    return numberStack.Pop() + numberStack.Pop();
                case '-':
                    if (isResult) { return numberStack.Pop() - numberStack.Pop(); }
                    else
                    {
                        temp = numberStack.Pop();
                        return numberStack.Pop() - temp;
                    }
                case '*':
                    return numberStack.Pop() * numberStack.Pop();
                case '/':
                    if (isResult) { return numberStack.Pop() / numberStack.Pop(); }
                    else
                    {
                        temp = numberStack.Pop();
                        return numberStack.Pop() / temp;
                    }
                default:
                    throw new Exception("Неверное значение символа в операторе switch");
            }
        }

        public static bool CheckSymbols(string arithmExp)
        {
            foreach (var item in arithmExp)
            {
                if (item == ' ') { continue; }
                if (!(char.IsDigit(item) || operators.Contains(item) || brackets.Contains(item)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckBrackets(string arithmExp)
        {
            MyStack<char> charStack = new MyStack<char>(arithmExp.Length); 
            foreach (var item in arithmExp)
            {
                if (item == ' ') { continue; }
                for (int i = 0; i < brackets.Length; i += 2)
                {
                    if (item == brackets[i]) { charStack.Push(item); break; }
                    if (item == brackets[i + 1])
                    {
                        if (charStack.GetCurrentIndex() == -1 || charStack.Pop() != brackets[i]) { return false; }
                    }
                }
            }
            return true;
        }

        public static bool CheckOperators(string arithmExp)
        {
            if (arithmExp[0] == '-' && operators.Contains(arithmExp[1]) 
                || operators.Contains(arithmExp[arithmExp.Length - 1])) { return false; }
            string str = string.Empty;
            foreach (var item in arithmExp)
            {
                if (item == ' ') { continue; }
                str += item;
            }
            for (int i = 1; i < str.Length - 1; i++)
            {
                foreach (var item in operators)
                {
                    if (str[i] == item 
                        && !((char.IsDigit(str[i - 1]) || brackets.Contains(str[i - 1]))
                            && (char.IsDigit(str[i + 1]) || brackets.Contains(str[i + 1]))))
                    {
                        return false; 
                    }
                }
            }
            return true;
        }
    }
}
