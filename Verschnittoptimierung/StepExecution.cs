using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verschnittoptimierung
{
    class StepExecution
    {
        Base global;

        public StepExecution()
        {
            this.global = Base.GetInstance();
        }

        public void ExecuteStep(int stepType)
        {
            Base global = Base.GetInstance();

            // for testing only
            if(global.Verschnittoptimierung.comboBox1.Text.Equals("Create Board(s) + Objects"))
            {

            }

            switch(global.Verschnittoptimierung.comboBox1.Text)
            {
                case "Create Board(s) + Objects":
                    
                    // get board values from user interface
                    float generalBoardHeight = (float)(global.Verschnittoptimierung.boardHeight.Value);
                    float generalBoardWidth = (float)(global.Verschnittoptimierung.boardWidth.Value);
                    if(generalBoardHeight >= generalBoardWidth)
                    {
                        float h = generalBoardWidth;
                        generalBoardWidth = generalBoardHeight;
                        generalBoardHeight = h;
                    }

                    // set global board values in Base/global
                    global.generalBoardHeight = generalBoardHeight;
                    global.generalBoardWidth = generalBoardWidth;

                    CalculateMult();

                    // global.boardGap = Convert.ToInt32(0.1 * global.generalBoardHeight);

                    // create and draw board(s)
                    
                    Creation creation = new Creation();
                    creation.CreateBoards();
                    DrawBoards();
                    break;
                case "Create Benchmark":
                    // 1. step: verify benchmark information
                    if(global.Verschnittoptimierung.boardHeight.Value <= global.Verschnittoptimierung.boardWidth.Value)
                    {
                        // create benchmark
                        Benchmark benchmark = new Benchmark();
                        //benchmark.BoardList = new List<Board>();
                        BenchmarkManagement benchmarkManagement = new BenchmarkManagement();
                        benchmarkManagement.CreateBenchmark(global, benchmark);
                        benchmarkManagement.CreateRects(Convert.ToInt32(global.Verschnittoptimierung.objectsMinNumber.Value)
                            , Convert.ToInt32(global.Verschnittoptimierung.objectsMaxNumber.Value), benchmark);
                        global.benchmark = benchmark;
                        // info: benchmark (boards with rects that fit exactly) created
                        
                        Show show = new Show(global);
                        show.ShowBenchmark(global.benchmark);
                    }
                    else
                    {
                        // not enough information entered or too much information entered
                        System.Windows.Forms.MessageBox.Show("Not enough information specified.");
                        /*
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();

                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    */
                    }
                    break;
                case "Fill":
                    break;
                case "Local Optimization":
                    break;
                case "Evolutionary Algorithm":
                    break;
                default:
                    break;    
            }
            
            /*
            //global.Verschnittoptimierung.display.;
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    Brush brush = new SolidBrush(Color.DarkBlue);
                    g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);
                    g.DrawRectangle(pen, 100, 100, 100, 200);
                }   
            }
            */
        }

        public void DrawNewDisplay()
        {
            if(global.contentToShow.Equals("benchmark"))
            {
                Show show = new Show(global);
                show.ShowBenchmark(global.benchmark);
            }
            else if (global.contentToShow.Equals("solution"))
            {
                Show show = new Show(global);
                show.ShowSolution(global.solution);
            }
            
        }

        public void DrawBoards()
        {
            MyPoint edgeLeftUp;
            MyPoint edgeRightDown;


            for (int i = 0; i < global.BoardList.Count(); i++)
            {
                //global.Verschnittoptimierung.display.;
                using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    
                        edgeLeftUp = new MyPoint(global.BoardList[i].edgeLeftUp.x, global.BoardList[i].edgeLeftUp.y);
                        edgeRightDown = new MyPoint(global.BoardList[i].edgeRightDown.x, global.BoardList[i].edgeRightDown.y);

                        // resize not used
                        // edgeLeftUp = Resize(edgeLeftUp);
                        // edgeRightDown = Resize(edgeRightDown);
                        global.Verschnittoptimierung.Output.Text = Convert.ToString(global.BoardList[0].edgeRightDown.y);
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
        }
        public void DrawRects()
        {
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    MyPoint edgeLeftUp;
                    MyPoint edgeRightDown;

                    edgeLeftUp = new MyPoint(global.BoardList[0].edgeLeftUp.x, global.BoardList[0].edgeLeftUp.y);
                    edgeRightDown = new MyPoint(30, 30);
;

                    Brush brush = new SolidBrush(Color.AntiqueWhite);
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
        public MyPoint Resize(MyPoint point)
        {
            point.x *= global.mult;
            point.y *= global.mult;
            return point;            
        }
        public void CalculateMult()
        {
            float yBoardGeneral;
            // calculate y of board general (= height of one board on the screen)
            yBoardGeneral = (global.Verschnittoptimierung.display.Height - (3 * global.boardGap)) / 2;

            // calculate mult
            global.mult = yBoardGeneral / global.generalBoardHeight;

            // set yBoardGeneral (real board height on display)
            global.boardHeightInterface = yBoardGeneral;
        }


        public void Test()
        {
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    Brush brush = new SolidBrush(Color.DarkBlue);
                    g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);
                    g.DrawRectangle(pen, 100, 100, 100, 200);
                }
            }
        }


        public void SaveOrLoad(string action)
        {
            SaveAndLoad saveAndLoad = new SaveAndLoad(global);
            if(action.Equals("save benchmark"))
            {
                saveAndLoad.SaveBenchmark();
            }
            else if (action.Equals("load benchmark"))
            {
                saveAndLoad.LoadBenchmark();
            }
            else if (action.Equals("save solution"))
            {
                saveAndLoad.SaveSolution();
            }
            else if (action.Equals("load solution"))
            {
                saveAndLoad.LoadSolution();
            }
            else if (action.Equals("save settings"))
            {
                saveAndLoad.SaveSettings();
            }
            else if (action.Equals("load settings"))
            {
                saveAndLoad.LoadSettings();
            }
        }

    }
}
