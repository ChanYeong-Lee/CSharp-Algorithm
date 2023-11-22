using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Sorting_t
{
    public class Sort
    {
        // <선택 정렬>
        // 전체를 탐색하여 최소값들을 찾고 배열의 앞에서부터 채움
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)            // index 0부터 끝까지
            {
                int minIndex = i;                           // 현재 index를 minIndex로
                for (int j = i + 1; j < list.Count; j++)    // 다음 index부터 끝까지
                {
                    if (list[j] < list[minIndex])           // 만약 현재 값이 최소값보다 작으면
                        minIndex = j;                       // 최소값을 현재값으로 업데이트
                }
                Swap(list, i, minIndex);                    // 최소값과 현재 값을 swap
            }
        }

        // <삽입 정렬>
        // index 1부터 끝까지 순서대로 key로 정하고                 
        // 앞의 값들과 비교해서 정렬                              
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)                // index 1부터 끝까지
            {
                int key = list[i];                              // 현재 값을 key로
                int j;                                      
                for (j = i - 1; j >= 0 && key < list[j]; j--)   // j는 (현재 인덱스-1) 부터 0까지 (만약 key보다 크면 반복)
                {
                    list[j + 1] = list[j];                      // key보다 list[j]가 크면 한자리씩 민다.
                }
                list[j + 1] = key;                              // j가 -1이 되거나 list[j]가 key보다 작을 때 반복문을 나와서, 그 자리 바로 뒤에 key값을 넣는다.
            }
        }

        // <버블 정렬>
        // 계속 서로 비교하면서 자리 바꾸기
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)        // 배열의 크기만큼 반복
            {
                for (int j = 1; j < list.Count-i; j++)    // index 1부터 끝까지
                {
                    if (list[j - 1] > list[j])          // 붙어있는 값끼리 비교
                        Swap(list, j - 1, j);           // 더 작은 것을 왼쪽으로
                }
            }
        }

        // <병합 정렬>
        // 예를 들어 총 개수가 20개이면,
        // mid = 9
        // mid = 4
        // mid = 2
        // mid = 1
        // 되서 0부터 1까지 정렬(왼쪽리스트), 2정렬(아무것도 안함,오른쪽 리스트)
        // 0 부터 2까지 정렬(왼쪽 리스트)
        // 3부터 4까지 정렬(오른쪽 리스트)
        // 0부터 4까지 정렬(왼쪽 리스트)
        // 5부터 9까지 정렬(오른쪽 리스트)
        // 0부터 9까지 정렬(왼쪽 리스트)
        // 10부터 19까지 정렬(오른쪽 리스트)
        // 0부터 19까지 정렬(병합)
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);             // left와 mid 같으면 return, 다르면 새로운 mid=(left+mid)/2로 반복
            MergeSort(list, mid + 1, right);        // mid+1과 right가 같으면 return, 다르면 새로운 mid=(mid+1+right)/2로 반복
            Merge(list, left, mid, right);          // left 부터 mid까지, mid+1부터 right까지 정렬 시작
        }

        private static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;                       // 왼쪽 인덱스는 left부터
            int rightIndex = mid + 1;                   // 오른쪽 인덱스는 mid+1부터

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right) // 왼쪽 인덱스는 mid까지 오른쪽 인덱스는 오른쪽끝까지
            {
                if (list[leftIndex] < list[rightIndex])     // 왼쪽 값이 오른쪽 값보다 작으면
                    sortedList.Add(list[leftIndex++]);      // 왼쪽 값을 집어넣고, 왼쪽 인덱스 증가
                else                                        // 오른쪽 값이 왼쪽 값 보다 작으면            
                    sortedList.Add(list[rightIndex++]);     // 오른쪽 값을 집어넣고, 오른쪽 인덱스 증가
            }

            if (leftIndex > mid)                            // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)   // right 인덱스의 남은 개수만큼 
                    sortedList.Add(list[i]);                // 배열에 추가
            }
            else                                            // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)      // left 인덱스의 남은 개수만큼
                    sortedList.Add(list[i]);                // 배열에 추가   
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        // <퀵 정렬>
        // pivot을 정하고
        // 전체 배열을 왼쪽엔 pivot보다 작은 값들을, 오른쪽엔 pivot보다 큰 값들을 정렬
        // i와 j가 엇갈리면(pivot기준으로 정렬이 되면) pivot을 더 작은 값으로 교체
        // pivot을 기준으로 왼쪽 오른쪽을 다시 정렬 이를 반복
        // 오른쪽 배열도 다시 정렬 이를 반복
        // 최종적으로는 전부 정렬이 됨
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;   

            int pivot = start;          // pivot = start
            int i = pivot + 1;          // i = pivot + 1
            int j = end;                // j = end

            while (i <= j)              // i > j가 될때까지 반복 
            {
                while (list[i] <= list[pivot] && i < end)       // i가 end보다 작고, list[i]가 list[pivot]보다 커질 때까지
                    i++;                                        // i를 증가
                while (list[j] >= list[pivot] && j > start)     // j가 start보다 크고, list[j]가 list[pivot]보다 작아질 떄까지
                    j--;

                if (i < j)                                      // list[pivot]보다 큰 list[i]와 list[pivot]보다 작은 list[j]의 index를 비교했을 때,
                    Swap(list, i, j);                           // i가 j보다 작으면 두 값을 swap
                else                                            // i가 j보다 크거나 같으면
                    Swap(list, pivot, j);                       // list[pivot]과 list[j]를 swap
            }

            QuickSort(list, start, j - 1);                      // j-1이 start가 될떄까지 반복
            QuickSort(list, j + 1, end);                        // end가 
        }

        // <힙 정렬>
        // 힙을 만든 뒤, (최대값이 첫번쨰 짜리로, list.Count/2-1을 기준으로 오른쪽에 더 작은 값들을 저장)
        // 0과 i를 교체
        // 0에 최대값을 저장
        // 반복
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        // MakeHeap
        // 0에는 최대값을,
        // 0부터 list.Count/2 - 1 까지는 오른쪽보다 큰 값을 저장
        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        // index의 값이 index*2+1이나 index*2+2보다 크면 그대로
        // 작으면 인덱스의 값과 max의 값을 교체한 후 
        // max의 값으로 다시 진행
        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
