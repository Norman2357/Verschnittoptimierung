﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class BenchmarkManagement
    {
        public void CreateBenchmark(Base global, Benchmark benchmark)
        {
            // set benchmark ID
            string path = Environment.CurrentDirectory;
            // without bin\Debug
            path = path.Substring(0, path.Length - 9) + "Resources\\BenchmarkNr.txt";
            // global.Verschnittoptimierung.Output.Text = path;
            benchmark.benchmarkID = Convert.ToInt32(System.IO.File.ReadAllText(path));

            // set creationTime
            benchmark.creationTime = DateTime.Now;
            // add boards to benchmark
            for (int i = 0; i < global.Verschnittoptimierung.numberBoards.Value; i++)
            {
                Board board = new Board();
                board.boardID = i + 1;
                board.height = Convert.ToInt32(global.Verschnittoptimierung.boardHeight.Value);
                board.width = Convert.ToInt32(global.Verschnittoptimierung.boardWidth.Value);
                board.isCollectionBoard = false;
                board.size = board.height * board.width;
                
                benchmark.boardList.Add(board);
            }
            // no collection board in benchmark. code can still be useful for creating a solution
            /*
            // add collection board to benchmark
            Board collectionBoard = new Board();
            collectionBoard.boardID = BoardList.Count() + 1;
            collectionBoard.height = Convert.ToInt32(global.Verschnittoptimierung.boardHeight.Value);
            collectionBoard.width = Convert.ToInt32(global.Verschnittoptimierung.boardWidth.Value);
            collectionBoard.isCollectionBoard = false;
            collectionBoard.size = collectionBoard.height * collectionBoard.width;
            BoardList.Add(collectionBoard);
            */
        }

        public void CreateRects(int minRects, int maxRects, Benchmark benchmark)
        {
            int rectID = 1;
            Random random = new Random();
            for (int i = 0; i < benchmark.boardList.Count; i++)
            {
                int numberOfRequiredRects = random.Next(minRects, maxRects + 1);

                // "convert" the board to a rect, meaning adding a rect to the board with the size of the board
                Rect rect = new Rect();
                rect.height = benchmark.boardList[i].height;
                rect.width = benchmark.boardList[i].width;
                rect.size = rect.height * rect.width;
                rect.edgeLeftUp = new MyPoint(0, rect.height);
                rect.edgeRightDown = new MyPoint(rect.width, 0);
                benchmark.boardList[i].RectList.Add(rect);

                // split the largest rect of the rectList until number of rects = required number of rects
                for (int j = 1; j < numberOfRequiredRects; j++)
                {
                    Rect largestRect = new Rect();
                    Rect rectOne = new Rect();
                    Rect rectTwo = new Rect();

                    Boolean nullCoordsOccured = true;
                    while(nullCoordsOccured == true)
                    {
                        // 1. find largest rect
                        largestRect = benchmark.boardList[i].RectList[0];
                        for (int k = 0; k < benchmark.boardList[i].RectList.Count; k++)
                        {
                            if (benchmark.boardList[i].RectList[k].size > largestRect.size)
                            {
                                largestRect = benchmark.boardList[i].RectList[k];
                            }
                        }
                        // 2. decide if to split horizontal or vertical
                        Boolean splitVertical;

                        if (random.Next(0, 2) == 0)
                        {
                            splitVertical = false;
                        }
                        else
                        {
                            splitVertical = true;
                        }
                        // 3. create two new rects out of the largest one and add them to the rect list
                        rectOne = new Rect();
                        rectTwo = new Rect();

                        if (splitVertical)
                        {
                            double largestRectWidthDouble = Convert.ToDouble(largestRect.width);
                            // new width between 10% and 90% of largestRect's width
                            // several conversions have to be done to use Ceiling and random for integer
                            int newWidth = Convert.ToInt32(Math.Ceiling(largestRectWidthDouble * (Convert.ToDouble(random.Next(1, 10)) / 10)));
                            if (newWidth == largestRect.width)
                            {
                                // this would not create 2 new rects. retry
                                nullCoordsOccured = true;
                            }
                            else
                            {
                                rectOne.height = largestRect.height;
                                rectTwo.height = largestRect.height;
                                rectOne.width = newWidth;
                                rectTwo.width = largestRect.width - newWidth;

                                rectOne.edgeLeftUp = largestRect.edgeLeftUp;
                                rectOne.edgeRightDown = new MyPoint(largestRect.edgeLeftUp.x + rectOne.width, largestRect.edgeRightDown.y);

                                rectTwo.edgeLeftUp = new MyPoint(rectOne.edgeRightDown.x, rectOne.edgeLeftUp.y);
                                rectTwo.edgeRightDown = largestRect.edgeRightDown;

                                nullCoordsOccured = false;
                                
                            }
                        }
                        // if split horizontal
                        else
                        {
                            double largestRectHeightDouble = Convert.ToDouble(largestRect.height);
                            // new height between 10% and 90% of largestRect's height
                            // several conversions have to be done to use Ceiling and random for integer
                            int newHeight = Convert.ToInt32(Math.Ceiling(largestRectHeightDouble * (Convert.ToDouble(random.Next(1, 10)) / 10)));
                            if (newHeight == largestRect.height)
                            {
                                // this would not create 2 new rects. retry
                                nullCoordsOccured = true;
                            }
                            else
                            {
                                rectOne.height = newHeight;
                                rectTwo.height = largestRect.height - newHeight;
                                rectOne.width = largestRect.width;
                                rectTwo.width = largestRect.width;

                                rectOne.edgeLeftUp = largestRect.edgeLeftUp;
                                rectOne.edgeRightDown = new MyPoint(largestRect.edgeRightDown.x, largestRect.edgeLeftUp.y - rectOne.height);

                                rectTwo.edgeLeftUp = new MyPoint(rectOne.edgeLeftUp.x, rectOne.edgeRightDown.y);
                                rectTwo.edgeRightDown = largestRect.edgeRightDown;

                                nullCoordsOccured = false;
                            }
                        }
                    }


                    

                    // add rect data
                    rectOne.size = rectOne.height * rectOne.width;
                    rectTwo.size = rectTwo.height * rectTwo.width;

                    // add rects to list
                    benchmark.boardList[i].RectList.Add(rectOne);
                    benchmark.boardList[i].RectList.Add(rectTwo);


                    // 4. remove the largest rect from the rect list
                    benchmark.boardList[i].RectList.Remove(largestRect);
                }

                // add rectIDs
                for (int j = 0; j < benchmark.boardList[i].RectList.Count; j++)
                {
                    benchmark.boardList[i].RectList[j].rectID = rectID;
                    rectID++;
                }

                // add number of rects and number of boards
                benchmark.numberOfRects = 0;
                for(int l = 0; l < benchmark.boardList.Count; l++)
                {
                    benchmark.numberOfRects += benchmark.boardList[i].RectList.Count;
                }
                benchmark.numberOfBoards = benchmark.boardList.Count;

            }
            // for testing:
            //1. size test
            String success = "success";
            for (int i = 0; i < benchmark.boardList.Count; i++)
            {
                int size = benchmark.boardList[i].size;
                for (int j = 0; j < benchmark.boardList[i].RectList.Count; j++)
                {
                    size -= benchmark.boardList[i].RectList[j].size;
                }
                if (size != 0)
                {
                    success = "fail";
                }
            }
            // 2. > 236 test
            for (int i = 0; i < benchmark.boardList.Count; i++)
            {
                for (int j = 0; j < benchmark.boardList[i].RectList.Count; j++)
                {
                    /*
                    if (benchmark.boardList[i].RectList[j].edgeLeftUp.y > 236)
                    {
                        int s = 1;
                    }
                    */
                }
            }

        }
    }
}
