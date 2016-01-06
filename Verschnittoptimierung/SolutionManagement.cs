using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class SolutionManagement
    {
        // creates a basic solution without rects placed, according to the benchmark
        public void CreateBasicSolution(Base global, Benchmark benchmark)
        {
            Solution solution = new Solution();

            // set solution ID
            string path = Environment.CurrentDirectory;
            // without bin\Debug
            path = path.Substring(0, path.Length - 9) + "Resources\\SolutionNr.txt";
            solution.SolutionID = Convert.ToInt32(System.IO.File.ReadAllText(path));

            // set creationTime
            solution.creationTime = DateTime.Now;

            // set Benchmark to solution
            solution.benchmark = benchmark;
            solution.usedBenchmarkID = benchmark.benchmarkID;

            // add boards
            solution.BoardList = new List<Board>();

            for (int i = 0; i < benchmark.boardList.Count; i++)
            {
                Board board = new Board();
                board.boardID = i + 1;
                board.height = benchmark.boardList[0].height;
                board.width = benchmark.boardList[0].width;
                board.isCollectionBoard = false;
                board.size = board.height * board.width;

                solution.BoardList.Add(board);
            }
            // add collection board
            Board collectionBoard = new Board();
            collectionBoard.boardID = solution.BoardList.Count + 1;
            collectionBoard.height = benchmark.boardList[0].height;
            collectionBoard.width = benchmark.boardList[0].width * 2;
            collectionBoard.isCollectionBoard = true;
            collectionBoard.size = collectionBoard.height * collectionBoard.width;

            solution.BoardList.Add(collectionBoard);

            // add rects to collection board, sorted from largest to smallest and height > width (change these parameters if necessary)
            // also remove the coordinates from the rects
            for(int i = 0; i < benchmark.boardList.Count; i++)
            {
                for(int j = 0; j < benchmark.boardList[i].RectList.Count; j++)
                {
                    Rect rect = new Rect();
                    rect.rectID = benchmark.boardList[i].RectList[j].rectID;
                    rect.size = benchmark.boardList[i].RectList[j].size;
                    if(benchmark.boardList[i].RectList[j].height < benchmark.boardList[i].RectList[j].width)
                    {
                        rect.height = benchmark.boardList[i].RectList[j].width;
                        rect.width = benchmark.boardList[i].RectList[j].height;
                    }
                    else
                    {
                        rect.height = benchmark.boardList[i].RectList[j].height;
                        rect.width = benchmark.boardList[i].RectList[j].width;
                    }
                    rect.edgeLeftUp = new MyPoint(0,0);
                    rect.edgeRightDown = new MyPoint(0,0);

                    collectionBoard.RectList.Add(rect);
                }
            }
            // sort the rect list
            List<Rect> rectList = new List<Rect>();
            // as long as rects exist
            while (collectionBoard.RectList.Count > 0)
            {
                // search the largest rect (by size), then add to rectList and remove from collectionBoard List
                Rect largestRect = collectionBoard.RectList[0];
                for (int i = 1; i < collectionBoard.RectList.Count; i++)
                {
                    if(collectionBoard.RectList[i].size > largestRect.size)
                    {
                        largestRect = collectionBoard.RectList[i];
                    }
                }
                rectList.Add(largestRect);
                collectionBoard.RectList.Remove(largestRect);
            }
            collectionBoard.RectList = rectList;


            // add the remaining parameters to solution
            solution.numberOfRects = collectionBoard.RectList.Count;
            solution.percentageFilledArea = 0;

            global.solution = solution;

            // cl values
            ClassificationNumbers clNumbers = new ClassificationNumbers(global);
            clNumbers.GetAndShowAllClassificationNumbers();
        }
    }
}
