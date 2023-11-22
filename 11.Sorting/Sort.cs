using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Sorting
{
    internal class Sort
    {
        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간복잡도 - 평균 : O(N^2)  최악 : O(N^2)
        // 공간복잡도 - O(1)
        // 안정정렬   - O
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }

        // 삽입정렬
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 - 평균 : O(N^2)  최악 : O(N^2)
        // 공간복잡도 - O(1)
        // 안정정렬   - O
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = key;
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 - 평균 : O(N^2)  최악 : O(N^2)
        // 공간복잡도 - O(1)
        // 안정정렬   - O
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  평균 : O(NlogN)   최악 : O(NlogN)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

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

        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 - 평균 : O(NlogN)    최악 : O(NlogN)
        // 공간복잡도 - O(N)
        // 안정정렬   - O
        public static void MergeSort(IList<int> list, int left, int right)
        { 
            if (left == right) return;

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        private static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)   // 왼쪽 List가 먼저 소진 됬을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else    // 오른쪽 List가 먼저 소진 됬을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(N^2)
        // 시간복잡도 - 평균 : O(NlogN)    최악 : O(N^2)
        // 공간복잡도 - O(1)
        // 안정정렬   - X
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int i = pivot + 1;
            int j = end;

            while (i <= j)  // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날 때까지
                while (list[i] <= list[pivot] && i < end)
                    i++;
                while (list[j] >= list[pivot] && j > start)
                    j--;

                if (i < j)  // 엇갈리지 않는다면
                    Swap(list, i, j);
                else        // 엇갈렸다면
                    Swap(list, pivot, j);
            }

            QuickSort(list, start, j - 1);
            QuickSort(list, j + 1, end);
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}

// 하이브리드 정렬(C#) = 인트로 정렬
// 퀵정렬 -> 힙정렬 -> 삽입정렬