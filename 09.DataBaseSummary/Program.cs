using System.Collections;

namespace _09.DataBaseSummary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // <배열> 
            // 크기가 정해진 자료집합
            // ex) 장비창
            int[] array = new int[5];

            // <리스트>
            // 크기가 유동적인 자료집합 (접근도 좋고, 삽입 삭제도 좋은 편)
            // ex) 유동적인 자료집합
            List<int> list = new List<int>();

            // <해시테이블>
            // 탐색이 빠른 자료집합 
            // ex) 대규모 자료 저장소
            // (초대규모이면 데이터베이스)
            Hashtable ht = new Hashtable();
            HashSet<int> set = new HashSet<int>();
            Dictionary<int, string> dic = new Dictionary<int, string>();

            // <상황 용도에 따라>
            // 스택 : 선입후출이 필요한 자료집합
            // ex) 실행 취소, 명령 수집, UI
            Stack<int> stack = new Stack<int>();
            // 큐 : 선입선출이 필요한 자료집합
            // ex) 대기열, 진행 순서
            Queue<int> queue = new Queue<int>();
            // 우선순위 큐 : 기준에 따라 먼저 처리할 필요가 있는 자료집합
            // ex) 가중치에 따른 처리 순서
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

            // <C# 특징상 상대적으로 많이 쓰지 않지만 이론적으로 중요한 자료구조>
            // 연결리스트 
            // 이진탐색트리
            LinkedList<int> linkedList = new LinkedList<int>(); 
            SortedSet<int> sortedSet = new SortedSet<int>();            
        }
    }
}