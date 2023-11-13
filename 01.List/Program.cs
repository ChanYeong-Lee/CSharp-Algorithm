namespace _01.List
{
	internal class Program
	{
		/*****************************************************************
		 * 배열 (Array)
		 * 
		 * 연속적인 메모리 상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨
		 * 배열의 요소는 인덱스를 사용하여 직접적으로 액세스 가능
		 *****************************************************************/

		// <배열의 사용>
		static void Array()
		{
			int[] intArray = new int[100];

			// 인덱스를 통한 접근
			intArray[0] = 10;
			int value = intArray[0];
		}
		// <배열의 시간복잡도>
		// 접근		탐색
		// O(1)		O(N)

		// 배열의 아쉬운 점... 
		// 크기가 고정되버려서 불편함이 있다.
		// 하지만 장비창이나 스킬창 등 크기가 고정되서 관리하기 편한 경우도 있다.

		/*****************************************************
		 * 선형 리스트 (Linear list)
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열 기반의 자료구조
		 * 배열 요소의 개수를 특정할 수 없는 경우 사용
		 *****************************************************/

		// <List 사용>
		static void List()
		{
			List<string> list = new List<string>();

			// 배열 요소 삽입				:: Add는 void 반환
			list.Add("0번 데이터");
			list.Add("1번 데이터");
			list.Add("2번 데이터");

            // 배열 요소 삭제				:: Remove는 bool 반환, 지우면 true, 못지우면 false
            list.Remove("1번 데이터");		

			// 배열 요소 접근
			list[0] = "데이터0";
			string value = list[0];

			// 배열 요소 탐색				:: Contains도 bool 반환, 있으면 true, 없으면 false
			string? findValue = list.Find(x => x.Contains('2'));	
			int findIndex = list.FindIndex(x => x.Contains('0'));

			list.Insert(1, "데이터0.5");

			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
			}
		}
		// List의 시간복잡도>
		// 접근		탐색		 삽입	  삭제
		// O(1)		O(N)	 O(N)	  O(N)

		static void ListSize()
		{
			List<int> list = new List<int>();
			
			for (int i = 0; i < 100; i++)
			{
				list.Add(i);
				Console.WriteLine("{0}번 데이터 추가", i);
				Console.WriteLine("Count: {0}", list.Count);
				Console.WriteLine("Capacity : {0}", list.Capacity);
			}
		}

		static void MyList()
		{
			MyList<int> list = new MyList<int>();

			for (int i = 0; i < 10; i++)
			{
				list.Add(i);
				Console.WriteLine("{0}번 데이터 추가,{1}", i, list[i]);
				Console.WriteLine("Count: {0}", list.Count);
				Console.WriteLine("Capacity : {0}", list.Capacity);
			}
			list.Remove(4);
		}

            static void Main(string[] args)
        {
            MyList();
        }
    }
}