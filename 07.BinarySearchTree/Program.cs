using System.Diagnostics;

namespace _07.BinarySearchTree
{
    internal class Program
    {
        public static void List()
        {
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(9);
            list.Add(6);
            list.Add(2);
            list.Add(3);
            list.Add(8);
            list.Add(5);
            list.Add(4);
            list.Add(7);

            // 리스트에 포함된 값을 찾고 싶을 때, 만약 리스트가 정렬되어 있다면
            // 가운데를 확인하고 절반을 버릴 수 있다. (1 2 3 4 5 6 7 8 9)
            // 결과적으로 탐색의 시간복잡도가 O(logN)이 된다.

            // 그렇지만 배열로 하면 정렬하는 과정에서 복사가 일어나 시간이 소요된다.
            // 그러면 어떻게 이진탐색의 이점을 살리면서 불필요한 작업을 줄일 수 있을까?

            // <이진탐색트리>
            // 1. 자식의 값이 부모보다 작으면 왼쪽으로, 크면 오른쪽으로 배치한다.
            // 2. 자식을 2개씩 가질 수 있다.
            // (빈 공간도 허용한다. 즉, 완전이진트리가 아니다.)

            // 탐색 : 값을 부모와 비교했을 때 작으면 왼쪽으로 크면 오른쪽으로 탐색
            // 추가 : 값을 부모와 비교했을 때 작으면 왼쪽으로 크면 오른쪽으로 추가
        }


        /**********************************************************************
         * 트리 (Tree)
         * 
         * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
         * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
         * 한 노드에서 출발하여 다시 자신의 노드로 돌아오는 순환구조를 가질 수 없음
         * (부장 -> 대리 -> 사원 -> 회장(?) -> 부장) 
         **********************************************************************/

        /**************************************************************
         * 이진탐색트리 (Binary Search Tree)
         * 
         * 이진속성과 탐색속성을 적용한 트리
         * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
         * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
         * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
         **************************************************************/

        // <이진탐색트리의 시간복잡도>
        //  접근      탐색      삽입      삭제
        // O(logN)  O(logN)   O(logN)   O(logN)

        public class Monster
        {
            string name;
            int hp;
            int mp;

            public Monster(string name, int hp, int mp)
            {
                this.name = name;  
                this.hp = hp;
                this.mp = mp;
            }
        }

        public static void BinarySearchTree()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();    // 정렬된 자료저장소

            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            int searchValue1;
            sortedSet.TryGetValue(3, out searchValue1);         // 탐색 시도

            // key, value 이진탐색트리
            SortedDictionary<string, Monster> sortedDictionary = new SortedDictionary<string, Monster>();
      
            sortedDictionary.Add("slime", new Monster("slime", 50, 10));
            sortedDictionary.Add("dragon", new Monster("dragon", 5000, 1000));
            sortedDictionary.Add("goblin", new Monster("goblin", 100, 20));
            sortedDictionary.Add("ogre", new Monster("ogre", 500, 50));
            sortedDictionary.Add("ghost", new Monster("ghost", 50, 200));
            // 굉장히 많은 몬스터 700 종


            Monster dragon;
            sortedDictionary.TryGetValue("dragon", out dragon);  // 탐색 시도

            Monster ogre;
            if (sortedDictionary.ContainsKey("ogre"))            // 예외처리   
            {
                ogre = sortedDictionary["ogre"];                 // 인덱서를 통한 탐색
            }
        }
        
        public static void Test()  // 소요시간 비교 : List vs SortedSet
        {
            int count = 10000000;
            List<int> list = new List<int>(count);
            SortedSet<int> set = new SortedSet<int>();

            Random random = new Random();
            int rand;
            for (int i = 0; i < count; i++)
            {
                rand = random.Next();
                list.Add(rand);
                set.Add(rand);
            }
            list[count / 2] = -1;
            set.Add(-1);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            list.Find((x) => x == -1);
            stopwatch.Stop();
            Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks); // Output : 110111

            stopwatch.Restart();
            int value;
            set.TryGetValue(-1, out value);
            stopwatch.Stop();
            Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks); // Output : 2971
        }

        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        
        // 최악의 경우
        // 접근    탐색    삽입     삭제
        // O(n)    O(n)    O(n)    O(n)

        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 대표적으로 Red-Black Tree, AVL Tree 등을 통해 불균형 상황을 파악
        // (Red-Black Tree는 색깔을 번갈아가며 확인, AVL Tree는 카운트로 확인)
        // 자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결
        // (C#은 Red-Black Tree)


        // <트리순회>
        // 트리는 비선형 자료구조로 반복자의 순서에 대해 정의하는데 규칙을 선정해야 함
        // 순회 방식은 크게 전위, 중위, 후위 순회가 있음
        // 전위순회 : 노드, 왼쪽, 오른쪽
        // 중위순회 : 왼쪽, 노드, 오른쪽   <- 이진탐색트리에서 중위순회시 오름차순으로 데이터 순회 가능
        // 후위순회 : 왼쪽, 오른쪽, 노드

        // <삭제>
        // 1. 자식이 없음 : 단순 삭제
        // 2. 자식이 1개 : 부모와 자식과 연결시켜준 뒤 삭제
        // 3. 자식이 2개 : 왼쪽 자식의 최대값, 오른쪽 자식의 최소값 중 하나와 바꾸고
        //                각 노드들의 절차를 진행한 뒤 삭제.


        static void Main(string[] args)
        {
            Test();   
        }
    }
}