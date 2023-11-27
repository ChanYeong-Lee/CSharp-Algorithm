using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.PathFinding_t
{
    internal class AStar
    {
        const int StraightCost = 10;
        const int DiagonalCost = 14;

        public static Point[] Direction =
        {
            new Point( 0, -1),      // 상
            new Point(+1, -1),      // 우상
            new Point(+1,  0),      // 우
            new Point(+1, +1),      // 우하
            new Point( 0, +1),      // 하
            new Point(-1, +1),      // 좌하
            new Point(-1,  0),      // 좌
            new Point(-1, -1),      // 좌상
        };

        /// <summary>
        /// </summary>
        /// <param name="tileMap"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="cross">Allowance of crossing through wall.</param>
        /// <param name="path"></param>
        /// <param name="visited"></param>
        /// <param name="keyward">Choose heuristic = "Manhattan", "Euclid". (Default = "Euclid")</param>
        /// <returns></returns>
        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, bool cross, out List<Point> path, out bool[,] visited, string keyward)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> nextPQ = new PriorityQueue<ASNode, int>();

            //for (int i = 0; i < ySize; i++)
            //{
            //    for (int j = 0; j < xSize; j++)
            //    {
            //        visited[i, j] = false;
            //    }
            //}

            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end, keyward));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPQ.Enqueue(startNode, startNode.f);

            while (nextPQ.Count > 0)
            {
                ASNode nextNode = nextPQ.Dequeue();
                PriorityQueue<ASNode, int> list = new PriorityQueue<ASNode, int>();
                while (nextPQ.Count > 0 && nextNode.f == nextPQ.Peek().f)
                {
                    list.Enqueue(nextNode, nextNode.g);
                    nextNode = nextPQ.Dequeue();
                }
                list.Enqueue(nextNode, nextNode.g);
                nextNode = list.Dequeue();
                while (list.Count > 0)
                {
                    nextPQ.Enqueue(list.Peek(), list.Dequeue().f);
                }
                visited[nextNode.point.y, nextNode.point.x] = true;

                if (nextNode.point.y == end.y && nextNode.point.x == end.x)
                {
                    Point? pathPoint = end;
                    path = new List<Point>();

                    while (pathPoint != null)
                    {
                        Point point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }

                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    else if (!tileMap[y, x])
                        continue;
                    else if (visited[y, x])
                        continue;
                    else if (i % 2 == 1) 
                    {
                        if (keyward == "Manhattan")
                            continue;
                        if (!tileMap[y, nextNode.point.x] && !tileMap[nextNode.point.y, x])
                            continue;
                        if (!cross && tileMap[y, nextNode.point.x] ^ tileMap[nextNode.point.y, x])
                            continue;
                    }

                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? StraightCost : DiagonalCost);
                    int h = Heuristic(new Point(x, y), end, keyward);

                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    if (nodes[y, x] == null ||
                        nodes[y, x].f > newNode.f)
                    {
                        nodes[y, x] = newNode;
                        nextPQ.Enqueue(newNode, newNode.f);
                    }

                }
            }
            path = null;
            return false;
        }



        public struct Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static int Heuristic(Point start, Point end, string keyward)
        {
            int xLength = Math.Abs(end.x - start.x);
            int yLength = Math.Abs(end.y - start.y);

            int straightCount = Math.Abs(xLength - yLength);
            int diagonalCount = Math.Max(xLength, yLength) - straightCount;
            if (keyward == "Manhattan")
                return xLength + yLength;
            else if (keyward == "Euclid")
                return straightCount * StraightCost + diagonalCount * DiagonalCost;
            else
                return straightCount * StraightCost + diagonalCount * DiagonalCost;
        }

        public class ASNode
        {
            public Point point;
            public Point? parent;
            
            public int g;
            public int h;
            public int f;

            public ASNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }
}
