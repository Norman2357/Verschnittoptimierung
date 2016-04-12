﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Tools
    {
        // old version dec
        /*
        // sorts rects in a rectlist
        // call: QuickSortBySize(rectList, 0, rectList.count)
        public void QuickSortRectBySizeDec(List<Rect> rectList, int left, int right)
        {
            int pivotIndex = 0;

            if(left < right)
            {
                pivotIndex = PartitionRectDec(rectList, left, right);
                QuickSortRectBySizeDec(rectList, left, pivotIndex - 1);
                QuickSortRectBySizeDec(rectList, pivotIndex + 1, right);
            }
        }

        // helper for QuickSortRectBySizeDec
        public int PartitionRectDec(List<Rect> rectList, int left, int right)
        {
            int start = left;
            Rect pivot = rectList[start];
            left++;
            right--;

            while (true)
            {
                while (left <= right && rectList[left].size >= pivot.size)
                {
                    left++;
                }
                while (left <= right && rectList[right].size < pivot.size)
                {
                    right--;
                }

                if (left > right)
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
        */

        public void QuickSortRectBySizeInc(int left, int right, List<Rect> rectList)
        {
            if (left < right)
            {
                int partition = PartitionRectInc(left, right, rectList);
                QuickSortRectBySizeInc(left, partition - 1, rectList);
                QuickSortRectBySizeInc(partition + 1, right, rectList);
            }
        }

        // helper for QuickSortRectBySizeInc
        public int PartitionRectInc(int left, int right, List<Rect> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = rectList[right].size;

            do
            {
                while (rectList[i].size <= pivot && i < right)
                {
                    i += 1;
                }
                while (rectList[j].size >= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    Rect z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if (rectList[i].size > pivot)
            {
                Rect z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
        }


        // sorts rects in a rectlist
        // call: QuickSortBySize(0, rectList.count, rectList)
        public void QuickSortRectBySizeDec(int left, int right, List<Rect> rectList)
        {
            if (left < right)
            {
                int partition = PartitionRectDec(left, right, rectList);
                QuickSortRectBySizeDec(left, partition - 1, rectList);
                QuickSortRectBySizeDec(partition + 1, right, rectList);
            }
        }

        // helper for QuickSortRectBySizeDec
        public int PartitionRectDec(int left, int right, List<Rect> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = rectList[right].size;

            do
            {
                while (rectList[i].size >= pivot && i < right)
                {
                    i += 1;
                }
                while (rectList[j].size <= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    Rect z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if (rectList[i].size < pivot)
            {
                Rect z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
        }



        // sorts rects in a rectlist
        // call: QuickSortBySize(0, rectList.count, rectList)
        public void QuickSortRectByLargestSideDec(int left, int right, List<Rect> rectList)
        {
            if (left < right)
            {
                int partition = PartitionRectLargestSideDec(left, right, rectList);
                QuickSortRectByLargestSideDec(left, partition - 1, rectList);
                QuickSortRectByLargestSideDec(partition + 1, right, rectList);
            }
        }

        // helper for QuickSortRectBySizeDec
        public int PartitionRectLargestSideDec(int left, int right, List<Rect> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = (rectList[right].height > rectList[right].width) ? rectList[right].height : rectList[right].width;

            do
            {
                while (((rectList[i].height > rectList[i].width) ? rectList[i].height : rectList[i].width) >= pivot && i < right)
                {
                    i += 1;
                }
                while (((rectList[j].height > rectList[j].width) ? rectList[j].height : rectList[j].width) <= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    Rect z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if (((rectList[i].height > rectList[i].width) ? rectList[i].height : rectList[i].width) < pivot)
            {
                Rect z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
        }


        public void QuickSortRectByLargestSizeInc(int left, int right, List<Rect> rectList)
        {
            if (left < right)
            {
                int partition = PartitionRectLargestSideInc(left, right, rectList);
                QuickSortRectByLargestSizeInc(left, partition - 1, rectList);
                QuickSortRectByLargestSizeInc(partition + 1, right, rectList);
            }
        }

        // helper for QuickSortRectBySizeInc
        public int PartitionRectLargestSideInc(int left, int right, List<Rect> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = (rectList[right].height > rectList[right].width) ? rectList[right].height : rectList[right].width;

            do
            {
                while (((rectList[i].height > rectList[i].width) ? rectList[i].height : rectList[i].width) <= pivot && i < right)
                {
                    i += 1;
                }
                while (((rectList[j].height > rectList[j].width) ? rectList[j].height : rectList[j].width) >= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    Rect z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if (((rectList[i].height > rectList[i].width) ? rectList[i].height : rectList[i].width) > pivot)
            {
                Rect z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
        }








        public void QuickSortTest(int left, int right, List<int> rectList)
        {
            if(left < right)
            {
                int partition = PartitionTest(left, right, rectList);
                QuickSortTest(left, partition - 1, rectList);
                QuickSortTest(partition + 1, right, rectList);
            }
        }
        public void QuickSortTestDec(int left, int right, List<int> rectList)
        {
            if (left < right)
            {
                int partition = PartitionTestDec(left, right, rectList);
                QuickSortTestDec(left, partition - 1, rectList);
                QuickSortTestDec(partition + 1, right, rectList);
            }
        }


        public int PartitionTest(int left, int right, List<int> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = rectList[right];

            do
            {
                while (rectList[i] <= pivot && i < right)
                {
                    i += 1;
                }
                while (rectList[j] >= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    int z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if(rectList[i] > pivot)
            {
                int z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
        }

        public int PartitionTestDec(int left, int right, List<int> rectList)
        {
            int i = left;
            int j = right - 1;
            int pivot = rectList[right];

            do
            {
                while (rectList[i] >= pivot && i < right)
                {
                    i += 1;
                }
                while (rectList[j] <= pivot && j > left)
                {
                    j -= 1;
                }
                if (i < j)
                {
                    int z = rectList[i];
                    rectList[i] = rectList[j];
                    rectList[j] = z;
                }
            }
            while (i < j);

            if (rectList[i] < pivot)
            {
                int z = rectList[i];
                rectList[i] = rectList[right];
                rectList[right] = z;
            }
            return i;
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
            // boardsNrSorted.Remove(collectionBoardNr);
            remainingBoards.Remove(collectionBoardNr);
            // > 1 because of collection board which remains in the list all the time
            while(remainingBoards.Count > 0)
            {
                // find largest of the remaining
                largest = 0;
                for(int i = 0; i < remainingBoards.Count; i++)
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
                boardsNrSorted.Add(remainingBoards[largest]);
                remainingBoards.Remove(remainingBoards[largest]);
            }
            boardsNrSorted.Add(collectionBoardNr);
            return (boardsNrSorted);
        }

        public void Reset()
        {
            Base global = Base.GetInstance();

            // reset all rects
            for(int i=0; i<global.solution.BoardList.Count -1; i++)
            {
                while(global.solution.BoardList[i].RectList.Count != 0)
                {
                    global.solution.BoardList[global.solution.BoardList.Count - 1].RectList.Add(global.solution.BoardList[i].RectList[0]);
                    global.solution.BoardList[i].RectList.RemoveAt(0);
                }
            }
            // reset running process/fill values
            global.runningProcess.existing = false;
            global.positionsManaged = new List<Position>();
            global.positionsValid = new List<Position>();
            global.bestPositionSet = false;

            Show show = new Show(global);
            show.ShowSolution(global.solution);
            ClassificationNumbers classificationNumbers = new ClassificationNumbers(global);
            classificationNumbers.GetAndShowAllClassificationNumbers();
            UnlockFillButtons();
        }

        public void LockFillButtons()
        {
            Base global = Base.GetInstance();
            global.Verschnittoptimierung.radioButton_BestFit.Enabled = false;
            global.Verschnittoptimierung.radioButton_BottomLeftFilling.Enabled = false;
            global.Verschnittoptimierung.radioButton_FirstFit.Enabled = false;
            global.Verschnittoptimierung.radioButton_FirstFitFilling.Enabled = false;
            global.Verschnittoptimierung.radioButton_largestSideDec.Enabled = false;
            global.Verschnittoptimierung.radioButton_largestSideInc.Enabled = false;
            global.Verschnittoptimierung.radioButton_sizeDec.Enabled = false;
            global.Verschnittoptimierung.radioButton_sizeInc.Enabled = false;

            global.Verschnittoptimierung.groupBox_BoardStrategy.Enabled = false;
            global.Verschnittoptimierung.groupBox_PlacingStrategy.Enabled = false;
            global.Verschnittoptimierung.groupBox_sortedBy.Enabled = false;
            global.Verschnittoptimierung.groupBox_Priority.Enabled = false;
        }

        public void UnlockFillButtons()
        {
            Base global = Base.GetInstance();
            global.Verschnittoptimierung.radioButton_BestFit.Enabled = true;
            global.Verschnittoptimierung.radioButton_BottomLeftFilling.Enabled = true;
            global.Verschnittoptimierung.radioButton_FirstFit.Enabled = true;
            global.Verschnittoptimierung.radioButton_FirstFitFilling.Enabled = true;
            global.Verschnittoptimierung.radioButton_largestSideDec.Enabled = true;
            global.Verschnittoptimierung.radioButton_largestSideInc.Enabled = true;
            global.Verschnittoptimierung.radioButton_sizeDec.Enabled = true;
            global.Verschnittoptimierung.radioButton_sizeInc.Enabled = true;

            global.Verschnittoptimierung.groupBox_BoardStrategy.Enabled = true;
            global.Verschnittoptimierung.groupBox_PlacingStrategy.Enabled = true;
            global.Verschnittoptimierung.groupBox_sortedBy.Enabled = true;
            global.Verschnittoptimierung.groupBox_Priority.Enabled = true;
        }


    }
}
