using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue_t
{
    public static class Solution
    {
        public static bool solution(string s)
        {
            Stack<char> stack = new Stack<char>(s.Length/2+1);
            foreach (char i in s)
            {
                if (i == '(')
                {
                    stack.Push('(');
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            if (stack.Count == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
