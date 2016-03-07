using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Tools
    {
        // sorts rects in a rectlist
        // call: QuickSortBySize(rectList, 0, rectList.count)
        public void QuickSortBySizeRect(List<Rect> rectList, int left, int right)
        {
            int pivotIndex = 0;

            if(left < right)
            {
                pivotIndex = PartitionRect(rectList, left, right);
                QuickSortBySizeRect(rectList, left, pivotIndex - 1);
                QuickSortBySizeRect(rectList, pivotIndex + 1, right);
            }
        }

        // helper for QuickSortBySizeRect
        public int PartitionRect(List<Rect> rectList, int left, int right)
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


        // sorts boards in a boardlist (except the last board which should stay the collection board)
        // call: QuickSortBySizeBoard(boardList, 0, boardList.count)
        public void QuickSortBySizeBoard(List<Board> boardList, int left, int right)
        {
            // remove collection board (should not be sorted and add it again in the end)
            Board collectionBoard = boardList[boardList.Count - 1];
            boardList.Remove(boardList[boardList.Count - 1]);

            int pivotIndex = 0;

            if (left < right)
            {
                pivotIndex = PartitionBoard(boardList, left, right);
                QuickSortBySizeBoard(boardList, left, pivotIndex - 1);
                QuickSortBySizeBoard(boardList, pivotIndex + 1, right);
            }
            boardList.Add(collectionBoard);
        }

        // helper for QuickSortBySizeBoard
        public int PartitionBoard(List<Board> boardList, int left, int right)
        {
            int start = left;
            Board pivot = boardList[start];
            left++;
            right--;

            while (true)
            {
                while (left <= right && boardList[left].size >= pivot.size)
                {
                    left++;
                }
                while (left <= right && boardList[right].size < pivot.size)
                {
                    right--;
                }

                if (left > right)
                {
                    boardList[start] = boardList[left - 1];
                    boardList[left - 1] = pivot;

                    return left;
                }

                Board temp = boardList[left];
                boardList[left] = boardList[right];
                boardList[right] = temp;
            }
        }


        // sorts the boards by size from largest to smallest and returns a list of the sorted board numbers.
        // the original boardList is not changed here
        // the collectionBoard is added in the end though it is the largest one
        public List<int> SortBoardsBySize(List<Board> boardList)
        {
            List<int> remainingBoards = new List<int>();
            int largest;
            // select collectionBoardNr
            int collectionBoardNr = 0;
            for(int i = 0; i < boardList.Count; i++)
            {
                if(boardList[i].isCollectionBoard)
                {
                    collectionBoardNr = i;
                }
            }

            List<int> boardsNrSorted = new List<int>();
            // list with int 0 - (n-1)
            for(int i = 0; i < boardList.Count; i++)
            {
                remainingBoards.Add(i);
            }
            boardsNrSorted.Remove(collectionBoardNr);
            // > 1 because of collection board which remains in the list all the time
            while(remainingBoards.Count > 0)
            {
                // find largest of the remaining
                largest = 0;
                for(int i = 1; i < remainingBoards.Count; i++)
                {
                    int boardSizeLargest = boardList[largest].size;
                    for(int j = 0; j < boardList[largest].RectList.Count; j++)
                    {
                        boardSizeLargest -= boardList[largest].RectList[j].size;
                    }
                    int boardSize1 = boardList[i].size;
                    for (int j = 0; j < boardList[i].RectList.Count; j++)
                    {
                        boardSize1 -= boardList[i].RectList[j].size;
                    }
                    if (boardSize1 > boardSizeLargest)
                    {
                        largest = i;
                    }
                }
                // add largest to the sorted list
                boardsNrSorted.Add(largest);
                remainingBoards.Remove(largest);
            }
            boardsNrSorted.Add(collectionBoardNr);
            return (boardsNrSorted);
        }


    }
}
