using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE
{
    public class Solution
    {
        public string solution(string my_string)
        {
            List<char> ansList = new List<char>();
            char[] removeList = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            {
                for (int i = 0; i < my_string.Length; i++)
                {
                    if (removeList.Contains(my_string[i]))
                        continue;
                    else
                        ansList.Add(my_string[i]);
                }
            }
            string answer = new string(ansList.ToArray());
            return answer;
        }
    }
}
