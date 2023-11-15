using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue_t4
{
    internal static class Solution
    {
        public static int solution(int bridge_length, int weight, int[] truck_weights)
        {
            Queue<int> trucks = new Queue<int>();
            Queue<int> bridge = new Queue<int>();
            int[] truckTime = new int[truck_weights.Length];

            int time = 0;
            int bridgeWeight = 0;
            for (int i = 0; i < truck_weights.Length; i++)
            {
                trucks.Enqueue(i);
                truckTime[i] = bridge_length;
            }
            time++;
            bridge.Enqueue(trucks.Peek());
            bridgeWeight += truck_weights[trucks.Dequeue()];
            while (truckTime[truck_weights.Length - 1] > 0)
            {
                time++;
                if (bridge.Count > 0)
                {
                    for (int i = 0; i < bridge.Count(); i++)
                    {
                        truckTime[bridge.Peek()+i] -= 1;
                    }
                    if (truckTime[bridge.Peek()] == 0)
                    {
                        bridgeWeight -= truck_weights[bridge.Dequeue()];
                    }
                }
                if (trucks.Count > 0)
                {
                    if (weight >= bridgeWeight + truck_weights[trucks.Peek()])
                    {
                        bridge.Enqueue(trucks.Peek());
                        bridgeWeight += truck_weights[trucks.Dequeue()];
                    }
                }
            }
            return time;
        }
    }

    public static class Solution2
    {
        public static int solution(int bridge_length, int weight, int[] truck_weights)
        {
            Queue<int> que = new Queue<int>();
            int time = 0, count = 0, bridge = 0;

            while (count < truck_weights.Length)
            {
                if (que.Count == bridge_length)
                {
                    bridge -= que.Dequeue();
                }

                if (bridge + truck_weights[count] <= weight)
                {
                    bridge += truck_weights[count];
                    que.Enqueue(truck_weights[count]);
                    count++;
                }
                else
                {
                    que.Enqueue(0);
                }

                time++;
            }
            time += bridge_length;

            return time;
        }
    }
}
