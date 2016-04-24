using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.ComponentModel;

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
            Show show = new Show(global);
            Tools tools = new Tools();

            global.Verschnittoptimierung.Output.Text = "";

            // for testing only
            if (global.Verschnittoptimierung.comboBox1.Text.Equals("Create Board(s) + Objects"))
            {

            }

            // reset displayed values
            if(global.runningProcess.existing == false)
            {
                global.Verschnittoptimierung.cl_evolutionMue.Text = "";
                global.Verschnittoptimierung.cl_evolutionLambda.Text = "";
            }
            

            switch (global.Verschnittoptimierung.comboBox1.Text)
            {
                 
                // old, not existing anymore. Objects+board created when creating benchmark, including an empty solution
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
                    if(global.Verschnittoptimierung.boardHeight.Value <= global.Verschnittoptimierung.boardWidth.Value &&
                        global.Verschnittoptimierung.objectsMinNumber.Value <= global.Verschnittoptimierung.objectsMaxNumber.Value)
                    {
                        // before creating benchmark clear the screen
                        // clear screen
                        global.Verschnittoptimierung.display.Invalidate();
                        

                        // create benchmark
                        Benchmark benchmark = new Benchmark();
                        //benchmark.BoardList = new List<Board>();
                        BenchmarkManagement benchmarkManagement = new BenchmarkManagement();
                        benchmarkManagement.CreateBenchmark(global, benchmark);
                        benchmarkManagement.CreateRects(Convert.ToInt32(global.Verschnittoptimierung.objectsMinNumber.Value)
                            , Convert.ToInt32(global.Verschnittoptimierung.objectsMaxNumber.Value), benchmark);
                        global.benchmark = benchmark;
                        // info: benchmark (boards with rects that fit exactly) created

                        // also create a basic solution
                        SolutionManagement solutionManagement = new SolutionManagement();
                        solutionManagement.CreateBasicSolution(global, global.benchmark);

                        show.ShowBenchmark(global.benchmark);
                    }
                    else
                    {
                        // not enough information entered or too much information entered
                        System.Windows.Forms.MessageBox.Show("Not enough information specified or wrong information. Check the min, max fields.");
                        /*
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult result = fbd.ShowDialog();

                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    */
                    }
                    break;
                case "Fill":
                    // lock fill radio buttons
                    tools.LockFillButtons();

                    // get type from what was entered
                    int type = 0;

                    // check if no process exists, create one
                    if(global.runningProcess.existing == false)
                    {
                        global.runningProcess.type = 0;

                        global.runningProcess.existing = true;
                        global.runningProcess.state = 0;
                        // 0 = single step, 1 = all remaining steps
                        global.runningProcess.stepType = stepType;
                        global.runningProcess.firstStep = true;

                        /*
                        // background worker
                        global.Verschnittoptimierung.backgroundWorker1.RunWorkerAsync();
                        */
                    }
                    // if a process exists, but of another process type
                    else if(global.runningProcess.existing == true && global.runningProcess.type != type)
                    {
                        global.Verschnittoptimierung.Output.Text = "Another process is already running. Please complete this process first.";
                        break;
                    }

                    // if a process exists of the same type
                    else if(global.runningProcess.existing == true && global.runningProcess.type == type)
                    {
                        // check if the process is running or waiting
                        // if waiting, do another step or all steps
                        if(global.runningProcess.state == 0)
                        {
                            // set params and reactivate process
                                // single step or all steps
                            global.runningProcess.stepType = stepType;
                            /*
                                // process makes the next step or all remaining steps, depending on stepType
                            global.runningProcess.autoResetEvent.Set();
                            */
                        }
                        // if running
                        else if(global.runningProcess.state == 1)
                        {
                            global.Verschnittoptimierung.Output.Text = "The process is already running. Please wait.";
                            break;
                        }
                    }




                    

                    // check if a valid solution + benchmark exist

                    if(global.solution != null && global.benchmark != null && global.solution.benchmark != null
                        && global.solution.BoardList != null && global.solution.BoardList.Count > 1)
                    {
                        show.ShowSolution(global.solution);


                        int selection = 1;
                        
                        // for testing: greedy 1
                        if(selection == 1)
                        {
                            Fill fill = new Fill();
                            if(global.Verschnittoptimierung.radioButton_BestFit.Checked)
                            {
                                fill.Greedy(false, new Solution());
                            }
                            if(global.Verschnittoptimierung.radioButton_FirstFit.Checked)
                            {
                                global.Verschnittoptimierung.Output.Text = "@info: \"First Fit\" not implemented";
                                global.runningProcess.existing = false;
                            }

                        }

                    }
                    else
                    {
                        global.Verschnittoptimierung.Output.Text = "At least one global element is null. Cannot fill.";
                        tools.UnlockFillButtons();
                    }

                    // unlock fill radio buttons
                    if(global.runningProcess.existing == false)
                    {
                        tools.UnlockFillButtons();
                    }

                    break;
                case "Evolutionary Algorithm":
                    // lock EvAlg entry
                    tools.LockEvAlgButtons();

                    // set entered evAlg values
                    global.mue = Convert.ToInt32(global.Verschnittoptimierung.evAlg_mue.Value);
                    global.multForLambda = Convert.ToInt32(global.Verschnittoptimierung.evAlg_mult.Value);
                    global.lambda = global.mue * global.multForLambda;
                    global.mutationRate = (float)global.Verschnittoptimierung.evAlg_mutationRate.Value;
                    tools.SaveSelectedGreedies();
                    global.tournamentPopulation = global.Verschnittoptimierung.checkBox_greedyTournamentPopulation.Checked;
                    global.tournamentGreediesOnly = global.Verschnittoptimierung.checkBox_greedyTournamentProceduresOnly.Checked;
                    

                    // 1. verification
                    // check if a valid solution + benchmark exist

                    if (global.solution != null && global.benchmark != null && global.solution.benchmark != null
                        && global.solution.BoardList != null && global.solution.BoardList.Count > 1)
                    {
                        // check if 'emptySolution' exists (the unchanged basic solution)
                        if (global.emptySolution == null)
                        {
                            global.Verschnittoptimierung.Output.Text = "global.emptySolution is null";
                            break;
                        }
                        // check parameters entered at evolutionary algorithm
                        int numberGreedies = tools.GetNumberSelectedGreedies();
                        if ((!(numberGreedies > 2) || (numberGreedies < global.mue) || numberGreedies < global.multForLambda) &&
                            !(global.tournamentPopulation && global.tournamentGreediesOnly))
                        {
                            global.Verschnittoptimierung.Output.Text = "You need to select more greedy procedures.";
                            tools.UnlockEvAlgButtons();
                            break;
                        }
                        if (global.mutationRate > (global.emptySolution.BoardList.Count - 1))
                        {
                            global.Verschnittoptimierung.Output.Text = "The mutation rate cannot be larger than the number of boards.";
                            tools.UnlockEvAlgButtons();
                            break;
                        }

                        // check if no process exists, create one
                        if (global.runningProcess.existing == false)
                        {
                            global.runningProcess.type = 1;

                            global.runningProcess.existing = true;
                            global.runningProcess.state = 0;
                            // 0 = single step, 1 = all remaining steps
                            global.runningProcess.stepType = stepType;
                            global.runningProcess.firstStep = true;

                            // set display values
                            global.Verschnittoptimierung.cl_evolutionMue.Text = global.mue.ToString();
                            global.Verschnittoptimierung.cl_evolutionLambda.Text = global.lambda.ToString();


                        }
                        // if a process exists, but of another process type
                        else if (global.runningProcess.existing == true && global.runningProcess.type != 1)
                        {
                            global.Verschnittoptimierung.Output.Text = "Another process is already running. Please complete this process first.";
                            break;
                        }

                        // if a process exists of the same type
                        else if (global.runningProcess.existing == true && global.runningProcess.type == 1)
                        {
                            // check if the process is running or waiting
                            // if waiting, do another step or all steps
                            if (global.runningProcess.state == 0)
                            {
                                // set params and reactivate process
                                // single step or all steps
                                global.runningProcess.stepType = stepType;
                            }
                            // if running
                            else if (global.runningProcess.state == 1)
                            {
                                global.Verschnittoptimierung.Output.Text = "The process is already running. Please wait.";
                                break;
                            }
                        }
                        
                        // 2. execute
                        EvolutionaryAlgorithm evolutionaryAlgorithm = new EvolutionaryAlgorithm();
                        evolutionaryAlgorithm.BombingAlgorithm();
                    }
                    else
                    {
                        global.Verschnittoptimierung.Output.Text = "At least one global element is null. Cannot use EvAlg.";
                        tools.UnlockEvAlgButtons();
                    }


                    // unlock EvAlg entry
                    if (global.runningProcess.existing == false)
                    {
                        tools.UnlockEvAlgButtons();
                    }

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

        public void SetContentToShow()
        {
            // clear screen
            global.Verschnittoptimierung.display.Invalidate();

            Show show = new Show(global);
            if(global.contentToShow.Equals("benchmark"))
            {
                show.ShowSolution(global.solution);
            }
            else if(global.contentToShow.Equals("solution"))
            {
                show.ShowBenchmark(global.benchmark);
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
