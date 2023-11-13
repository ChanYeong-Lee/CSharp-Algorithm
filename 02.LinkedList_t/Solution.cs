using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList_t
{
    public static class Solution
    {
        public static string[] solution(string[] players, string[] callings)
        {
            LinkedList<string> result = new LinkedList<string>();
            foreach (string layer in players)
            {
                result.AddLast(layer);
            }
            foreach (string calling in callings)
            {
                LinkedListNode<string> findNode = result.Find(calling);
                result.AddBefore(findNode.Previous, calling);
                result.Remove(findNode);
            }
            return result.ToArray();
        }
    }
}
