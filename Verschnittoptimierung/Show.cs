using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verschnittoptimierung
{
    class Show
    {
        Base global;

        public Show(Base global)
        {
            this.global = global;
        }

        public void ShowBenchmark(Benchmark benchmark)
        {
            ShowBoards(benchmark.boardList, true);
            ShowRects(benchmark.boardList);
            // set benchmark as contentToShow so it is shown everytime the display changes
            global.contentToShow = "benchmark";
            global.Verschnittoptimierung.buttonSelectView.Text = "Benchmark";
            global.Verschnittoptimierung.buttonSelectView.Enabled = true;
            global.Verschnittoptimierung.buttonSelectView.BackColor = Color.CornflowerBlue;
        }

        public void ShowSolution(Solution solution)
        {
            ShowBoards(solution.BoardList, false);
            ShowRects(solution.BoardList);

            // set solution as contentToShow so it is shown everytime the display changes
            global.contentToShow = "solution";
            global.Verschnittoptimierung.buttonSelectView.Text = "Solution";
            global.Verschnittoptimierung.buttonSelectView.Enabled = true;
            global.Verschnittoptimierung.buttonSelectView.BackColor = Color.LawnGreen;
        }

        public void ShowBoards(List<Board> BoardList, Boolean isFromBenchmark)
        {
            // calculate new point (because drawing goes from leftUp to rightDown
            MyPoint edgeLeftUp = new MyPoint (0, 0);
            MyPoint edgeRightDown = new MyPoint(0, 0);

            for (int i = 0; i < BoardList.Count; i++)
            {
                if(BoardList[i].isCollectionBoard == false && i % 2 == 0)
                {
                    // board gap + (width+gap) * (i/2)
                    edgeLeftUp = new MyPoint(global.boardGap + (i/2) * (BoardList[i].width + global.boardGap), global.boardGap);
                    edgeRightDown = new MyPoint(edgeLeftUp.x + BoardList[i].width, edgeLeftUp.y + BoardList[i].height);
                }
                else if (BoardList[i].isCollectionBoard == false && i % 2 != 0)
                {
                    // 532 = application display height (above scrollbar)
                    edgeLeftUp = new MyPoint(global.boardGap + ((i-1)/2) * (BoardList[i].width + global.boardGap), 532 - (global.boardGap + BoardList[i].height));
                    edgeRightDown = new MyPoint(edgeLeftUp.x + BoardList[i].width, edgeLeftUp.y + BoardList[i].height);
                }
                else if (BoardList[i].isCollectionBoard == true)
                {
                    edgeLeftUp = new MyPoint(BoardList[i-1].edgeRightDown.x + global.boardGap, global.boardGap);
                    edgeRightDown = new MyPoint(edgeLeftUp.x + BoardList[i].width, edgeLeftUp.y + BoardList[i].height);
                }
                else
                {
                    // should not happen
                }

                // IMPORTANT: set edgeLeftUp and edgeRightUp at the benchmark OR in the solution in global,
                // depending on if the boards are from the solution or a benchmark
                if(isFromBenchmark)
                {
                    global.benchmark.boardList[i].edgeLeftUp = edgeLeftUp;
                    global.benchmark.boardList[i].edgeRightDown = edgeRightDown;
                }
                else
                {
                    global.solution.BoardList[i].edgeLeftUp = edgeLeftUp;
                    global.solution.BoardList[i].edgeRightDown = edgeRightDown;
                }
                

                // drawing
                using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
                {
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        //global.Verschnittoptimierung.Output.Text = Convert.ToString(global.Verschnittoptimierung.display.Height);

                        Brush brush = new SolidBrush(Color.AliceBlue);
                        g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);

                        g.DrawRectangle(pen, edgeLeftUp.x, edgeLeftUp.y,
                            edgeRightDown.x - edgeLeftUp.x,
                            edgeRightDown.y - edgeLeftUp.y);
                        
                        g.FillRectangle(brush, edgeLeftUp.x, edgeLeftUp.y,
                            edgeRightDown.x - edgeLeftUp.x,
                            edgeRightDown.y - edgeLeftUp.y);
                    }
                }
            }
            // reposition button in display to activate horizontal autoscroll
            if (BoardList[BoardList.Count() - 1].edgeRightDown.x > global.displayWidth)
            {
                int newRange = Convert.ToInt32(BoardList[BoardList.Count() - 1].edgeRightDown.x) + 30;
                global.Verschnittoptimierung.buttonInDisplay.Left = newRange;
                global.Verschnittoptimierung.buttonInDisplay.Visible = true;

                global.displayWidth = newRange;
            }
        }

        public void ShowRects(List<Board> BoardList)
        {
            MyPoint edgeLeftUp = new MyPoint(0 , 0);
            MyPoint edgeRightDown = new MyPoint(0, 0);
            // show rects for each board and add board range
            // do not show rects on collection board
            for(int i = 0; i < BoardList.Count; i++)
            {
                if(BoardList[i].isCollectionBoard == false)
                {
                    // for color
                    int colorPosition = 0;

                    // draw each rect in the board
                    for(int j = 0; j < BoardList[i].RectList.Count; j++)
                    {
                        // 1. calculate rect coords in combination with the board coords
                        edgeLeftUp = new MyPoint(BoardList[i].edgeLeftUp.x + BoardList[i].RectList[j].edgeLeftUp.x,
                            BoardList[i].edgeLeftUp.y + BoardList[i].height - BoardList[i].RectList[j].edgeLeftUp.y);

                        edgeRightDown = new MyPoint(BoardList[i].edgeLeftUp.x + BoardList[i].RectList[j].edgeRightDown.x,
                            BoardList[i].edgeLeftUp.y + BoardList[i].height - BoardList[i].RectList[j].edgeRightDown.y);

                        // for testing:
                        if(edgeLeftUp.y <20)
                        {
                            int s = 1;
                        }

                        // 2. draw rect
                        // 2.1 chosing color
                        List<Color> colorList = new List<Color>();
                        colorList.Add(Color.Red);
                        colorList.Add(Color.Orange);
                        colorList.Add(Color.Yellow);
                        colorList.Add(Color.Blue);
                        colorList.Add(Color.Violet);
                        colorList.Add(Color.Pink);
                        colorList.Add(Color.Purple);
                        colorList.Add(Color.Black);
                        colorList.Add(Color.White);

                        Color chosenColor = colorList[colorPosition % 8];
                        

                        // 2.2 drawing
                        using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
                        {
                            using (Pen pen = new Pen(Color.Black, 2))
                            {
                                //global.Verschnittoptimierung.Output.Text = Convert.ToString(global.Verschnittoptimierung.display.Height);

                                Brush brush = new SolidBrush(chosenColor);
                                colorPosition++;
                                g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);

                                g.DrawRectangle(pen, edgeLeftUp.x, edgeLeftUp.y,
                                    edgeRightDown.x - edgeLeftUp.x,
                                    edgeRightDown.y - edgeLeftUp.y);

                                g.FillRectangle(brush, edgeLeftUp.x, edgeLeftUp.y,
                                    edgeRightDown.x - edgeLeftUp.x,
                                    edgeRightDown.y - edgeLeftUp.y);
                            }
                        }


                    }
                }
            }
        }

        public void ShowRectsOnCollectionBoard(Board collectionBoard)
        {
            
        }
    }
}
