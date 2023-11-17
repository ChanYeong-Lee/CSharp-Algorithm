using System.Collections;
using System.Collections.Specialized;

namespace _08.Dictionary
{
    internal class Program
    {
        /*****************************************************************************
         * 해시테이블 (HashTable)
         * 
         * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 액세스하도록 만든 방식
         * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
         *****************************************************************************/

        // <해시테이블의 시간복잡도>
        // 접근   탐색    삽입    삭제
        //   X    O(1)   O(1)    O(1)
        // (그러나 목적은 탐색이지 삽입, 삭제가 아니다.)

        // <해시함수의 조건>
        // 키 값을 해시함수를 통해 처리한 결과가 항상 동일한 값이어야 함

        // <해시함수의 효율>
        // 1. 해시함수의 처리속도가 빠를수록 효율이 좋음
        // 2. 해시함수의 결과가 밀집도가 낮아야 함
        // 3. 해시테이블의 크기가 클수록 빠르지만 메모리가 부담됨

        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음

        // (비둘기집 원리)
        // n개 보다 많은 물건을 n개의 집합에 나누어 넣는다면
        // 적어도 어느 한 집합에는 2개 이상의 물건이 속하게 된다

        // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요

        // <충돌해결방안 - 개방주소법>
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱
        // (C#은 개방주소법/이중해시 쓴다. Capacity를 1.5배 정도로 만드는 게 유리)
        // (C#은 노드기반을 안 좋아한다.)
        // (int나 string은 C#에서 해시함수가 효율이 좋다.)

        // 추가!
        // 게임 업계에서는 해시를 보안에서 사용하기도 함

        public class Monster
        {
            public string name;
            public Monster(string name)
            {
                this.name = name;
            }
        }

        public static void Test()
        {
            // <HashTable>
            // key와 value의 제한이 없다(object). 그러나 잘 쓰지 않는다. 왜냐? 
            // 사용할 때마다 casting을 해줘야 하기 때문에...
            // + Boxing, Unboxing
            Hashtable ht = new Hashtable();
            ht.Add("파이리", new Monster("파이리"));
            ht.Add(123, true);
            ht.Add(3.2f, "실수");

            Monster charmander = (Monster)ht["파이리"];
            bool b = (bool)ht[123];
            string dataType = (string)ht[3.2f];

            // <Dictionary>
            // HashTable의 Key와 Value 자료형을 일반화 시킨다. 
            // 박싱, 언박싱할 필요가 없다.
            Dictionary<string, Monster> dic = new Dictionary<string, Monster>();
            dic.Add("파이리", new Monster("파이리"));
            dic.Add("꼬부기", new Monster("꼬부기"));
            dic.Add("이상해씨", new Monster("이상해씨"));
            // + 데이터 100,000 종

            Monster squirtle = dic["꼬부기"];

            dic.Remove("이상해씨");
            // Add와 Remove가 자주 일어나는 것이 그닥 좋지 않다.
        }

        static void Dictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("txt", "텍스트 파일");
            dictionary.Add("bmp", "이미지 파일");
            dictionary.Add("mp3", "오디오 파일");

            Console.WriteLine(dictionary["txt"]);       // 키 값은 인덱서를 통해 접근

            if (dictionary.ContainsKey("mp3"))
                Console.WriteLine("mp3 키 값의 데이터가 있음");
            else
                Console.WriteLine("mp3 키 값의 데이터가 없음");

            if (dictionary.Remove("mp3"))
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 지움");
            else
                Console.WriteLine("mp3 키 값에 해당하는 데이터를 못 지움");

            string output;
            if (dictionary.TryGetValue("bmp", out output))
                Console.WriteLine(output);
            else
                Console.WriteLine("bmp 키 값의 데이터가 없음");
        }

        static void Main(string[] args)
        {
            Dictionary();
        }
    }
}