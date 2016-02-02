using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Tools
    {
        // call: QuickSortBySize(rectList, 0, rectList.count)
        public void QuickSortBySize(List<Rect> rectList, int left, int right)
        {
            int pivotIndex = 0;

            if(left < right)
            {
                pivotIndex = Partition(rectList, left, right);
                QuickSortBySize(rectList, left, pivotIndex - 1);
                QuickSortBySize(rectList, pivotIndex + 1, right);
            }
        }
        public int Partition(List<Rect> rectList, int left, int right)
        {
            int start = left;
            Rect pivot = rectList[start];
            left++;
            right--;

            while(true)
            {
                while(left <= right && rectList[left].size >= pivot.size)
                {
                    left++;
                }
                while(left <= right && rectList[right].size < pivot.size)
                {
                    right--;
                }

                if(left > right)
                {
                    rectList[start] = rectList[left - 1];
                    rectList[left - 1] = pivot;

                    return left;
                }

                Rect temp = rectList[left];
                rectList[left] = rectList[right];
                rectList[right] = temp;
            }
        }
    }
}
