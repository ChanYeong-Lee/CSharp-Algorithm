using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AlgorithmTechnique_t
{
    internal class MaxSum
    {
        public void Func(int[] array)
        {
            int sum = 0;
            int init = 0;
            int fin = 0;
            array[1] = array[0] + array[1];
            sum = array[1];
            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] + array[i - 1] > array[i])
                {
                    fin = array[i];
                    array[i] = array[i] + array[i - 1];
                }
                else
                {
                    init = array[i];
                    continue;
                }
            }
            Console.WriteLine("init : {0}, fin : {1}, result : {2}",init ,fin,array[array.Length - 1]);
        }
    }
}