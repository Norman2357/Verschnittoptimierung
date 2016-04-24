using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Verschnittoptimierung
{
    class SaveAndLoad
    {
        Base global;

        public SaveAndLoad(Base global)
        {
            this.global = global;
        }
        
        public void SaveBenchmark()
        {
            try
            {
                // I. get paths and prepare content
                // get folder path
                string path = Environment.CurrentDirectory;
                // without bin\Debug
                path = path.Substring(0, path.Length - 9);

                string pathBenchmarkNr = path + "Resources\\BenchmarkNr.txt";
                int benchmarkNr = Convert.ToInt32(File.ReadAllText(pathBenchmarkNr));

                string pathFolderPathGeneral = path + "Resources\\FolderPathGeneral.txt";
                string pathStored = File.ReadAllText(pathFolderPathGeneral);
                pathStored += "\\Verschnittoptimierung\\benchmarks\\" + "b";

                // "0 bonus"
                int pre = 6;
                for (int i = pre; i > 0; i--)
                {
                    if (benchmarkNr < Math.Pow(10, i - 1))
                    {
                        pathStored += "0";
                    }
                    else
                    {
                        pathStored += benchmarkNr;
                        break;
                    }
                }
                pathStored += "_";

                // "date bonus"
                global.benchmark.creationTime = DateTime.Now;

                if (global.benchmark.creationTime.Day < 10)
                {
                    pathStored += "0";
                }
                pathStored += global.benchmark.creationTime.Day + ".";
                if (global.benchmark.creationTime.Month < 10)
                {
                    pathStored += "0";
                }
                pathStored += global.benchmark.creationTime.Month + ".";
                pathStored += global.benchmark.creationTime.Year + "_";

                // "board bonus"
                pathStored += global.benchmark.boardList.Count + "_";

                // "rect bonus"
                pathStored += global.benchmark.numberOfRects + ".xml";

                // II. serialize benchmark to xml at the current location
                XmlSerializer serializer = new XmlSerializer(typeof(Benchmark));
                TextWriter writer = new StreamWriter(pathStored);
                serializer.Serialize(writer, global.benchmark);
                writer.Close();
                // III. increase benchmark nr
                using (StreamWriter writer1 = new StreamWriter(pathBenchmarkNr))
                {
                    writer1.Write(benchmarkNr + 1);
                }
                // show message that saving the benchmark worked
                System.Windows.Forms.MessageBox.Show("Benchmark was successfully saved at "
                    + pathStored);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Benchmark could not be saved");
            }
        }

        public void LoadBenchmark()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.ShowDialog();
            string pathToLoad = dialog.FileName;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Benchmark));
                FileStream filestream = new FileStream(pathToLoad, FileMode.Open, FileAccess.Read, FileShare.Read);

                Benchmark benchmark = (Benchmark)serializer.Deserialize(filestream);
                filestream.Close();

                // before setting benchmark, clear the screen
                // clear screen
                global.Verschnittoptimierung.display.Invalidate();

                global.benchmark = benchmark;

                // also create a basic solution
                SolutionManagement solutionManagement = new SolutionManagement();
                solutionManagement.CreateBasicSolution(global, global.benchmark);

                // show benchmark
                Show show = new Show(global);
                show.ShowBenchmark(global.benchmark);

                System.Windows.Forms.MessageBox.Show("Benchmark was loaded successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Benchmark could not be loaded. Please make sure to select the correct file path.");
            }
        }

        public void SaveSolution()
        {
            try
            {
                // I. get paths and prepare content
                // get folder path
                string path = Environment.CurrentDirectory;
                // without bin\Debug
                path = path.Substring(0, path.Length - 9);

                string pathSolutionNr = path + "Resources\\SolutionNr.txt";
                int solutionNr = Convert.ToInt32(File.ReadAllText(pathSolutionNr));

                string pathFolderPathGeneral = path + "Resources\\FolderPathGeneral.txt";
                string pathStored = File.ReadAllText(pathFolderPathGeneral);
                pathStored += "\\Verschnittoptimierung\\solutions\\" + "s";

                // "0 bonus"
                int pre = 6;
                for (int i = pre; i > 0; i--)
                {
                    if (solutionNr < Math.Pow(10, i - 1))
                    {
                        pathStored += "0";
                    }
                    else
                    {
                        pathStored += solutionNr;
                        break;
                    }
                }
                pathStored += "_";

                // "date bonus"

                global.solution.creationTime = DateTime.Now;

                if (global.solution.creationTime.Day < 10)
                {
                    pathStored += "0";
                }
                pathStored += global.solution.creationTime.Day + ".";
                if (global.solution.creationTime.Month < 10)
                {
                    pathStored += "0";
                }
                pathStored += global.solution.creationTime.Month + ".";
                pathStored += global.solution.creationTime.Year + "_";

                // "board bonus"
                pathStored += global.solution.BoardList.Count - 1 + "_";

                // "rect bonus"
                pathStored += global.solution.numberOfRects + "_";

                // "success rate bonus"
                pathStored += global.solution.percentageFilledArea + ".xml";

                // II. serialize benchmark to xml at the current location
                XmlSerializer serializer = new XmlSerializer(typeof(Solution));
                TextWriter writer = new StreamWriter(pathStored);
                serializer.Serialize(writer, global.solution);
                writer.Close();
                // III. increase solution nr
                using (StreamWriter writer1 = new StreamWriter(pathSolutionNr))
                {
                    writer1.Write(solutionNr + 1);
                }

                // show message that saving the solution worked
                System.Windows.Forms.MessageBox.Show("Solution was successfully saved at "
                    + pathStored);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Solution could not be saved");
            }
            
        }

        public void LoadSolution()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.ShowDialog();
            string pathToLoad = dialog.FileName;
            
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Solution));
                FileStream filestream = new FileStream(pathToLoad, FileMode.Open, FileAccess.Read, FileShare.Read);

                Solution solution = (Solution)serializer.Deserialize(filestream);
                filestream.Close();

                // before setting solution and benchmark, clear the screen
                // clear screen
                global.Verschnittoptimierung.display.Invalidate();

                global.solution = solution;

                // also set global benchmark to the benchmark of the solution
                global.benchmark = solution.benchmark;

                // cl values
                ClassificationNumbers clNumbers = new ClassificationNumbers(global);
                clNumbers.GetAndShowAllClassificationNumbers();

                // show solution
                Show show = new Show(global);
                show.ShowSolution(global.solution);

                System.Windows.Forms.MessageBox.Show("Solution was loaded successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Solution could not be loaded. Please make sure to select the correct file path.");
            }
        }

        public void SaveSettings()
        {
            try
            {
                // 0. create settings
                Settings settings = new Settings();
                // general settings
                settings.numberOfBoards = Convert.ToInt32(global.Verschnittoptimierung.numberBoards.Value);
                settings.boardHeight = Convert.ToInt32(global.Verschnittoptimierung.boardHeight.Value);
                settings.boardWidth = Convert.ToInt32(global.Verschnittoptimierung.boardWidth.Value);
                settings.objectsBoardMin = Convert.ToInt32(global.Verschnittoptimierung.objectsMinNumber.Value);
                settings.objectsBoardMax = Convert.ToInt32(global.Verschnittoptimierung.objectsMaxNumber.Value);

                // fill
                settings.bestFit = global.Verschnittoptimierung.radioButton_BestFit.Checked;
                settings.bottomLeftFilling = global.Verschnittoptimierung.radioButton_BottomLeftFilling.Checked;
                settings.largestSideInc = global.Verschnittoptimierung.radioButton_largestSideInc.Checked;
                settings.largestSideDec = global.Verschnittoptimierung.radioButton_largestSideDec.Checked;
                settings.sizeInc = global.Verschnittoptimierung.radioButton_sizeInc.Checked;
                settings.sizeDec = global.Verschnittoptimierung.radioButton_sizeDec.Checked;
                settings.min_xl_y = global.Verschnittoptimierung.radioButton_min_xl_y.Checked;

                // evolutionary
                settings.mue = Convert.ToInt32(global.Verschnittoptimierung.evAlg_mue.Value);
                settings.mult = Convert.ToInt32(global.Verschnittoptimierung.evAlg_mult.Value);
                settings.mutationRate = (float)global.Verschnittoptimierung.evAlg_mutationRate.Value;
                settings.tournamentPopulation = global.Verschnittoptimierung.checkBox_greedyTournamentPopulation.Checked;
                settings.tournamentGreedyProcOnly = global.Verschnittoptimierung.checkBox_greedyTournamentProceduresOnly.Checked;
                settings.greedy1 = global.Verschnittoptimierung.checkBox_greedy1.Checked;
                settings.greedy2 = global.Verschnittoptimierung.checkBox_greedy2.Checked;
                settings.greedy3 = global.Verschnittoptimierung.checkBox_greedy3.Checked;
                settings.greedy4 = global.Verschnittoptimierung.checkBox_greedy4.Checked;
                settings.greedy5 = global.Verschnittoptimierung.checkBox_greedy5.Checked;
                settings.greedy6 = global.Verschnittoptimierung.checkBox_greedy6.Checked;
                settings.greedy7 = global.Verschnittoptimierung.checkBox_greedy7.Checked;
                settings.greedy8 = global.Verschnittoptimierung.checkBox_greedy8.Checked;
                settings.greedy9 = global.Verschnittoptimierung.checkBox_greedy9.Checked;
                settings.greedy10 = global.Verschnittoptimierung.checkBox_greedy10.Checked;
                settings.greedy11 = global.Verschnittoptimierung.checkBox_greedy11.Checked;
                settings.greedy12 = global.Verschnittoptimierung.checkBox_greedy12.Checked;
                settings.greedy13 = global.Verschnittoptimierung.checkBox_greedy13.Checked;
                settings.greedy14 = global.Verschnittoptimierung.checkBox_greedy14.Checked;
                settings.greedy15 = global.Verschnittoptimierung.checkBox_greedy15.Checked;
                settings.greedy16 = global.Verschnittoptimierung.checkBox_greedy16.Checked;
                


                // I. get paths and prepare content
                // get folder path
                string path = Environment.CurrentDirectory;
                // without bin\Debug
                path = path.Substring(0, path.Length - 9);

                string pathSettingsNr = path + "Resources\\SettingsNr.txt";
                int settingsNr = Convert.ToInt32(File.ReadAllText(pathSettingsNr));

                string pathFolderPathGeneral = path + "Resources\\FolderPathGeneral.txt";
                string pathStored = File.ReadAllText(pathFolderPathGeneral);
                pathStored += "\\Verschnittoptimierung\\settings\\" + "cfg";

                // "0 bonus"
                int pre = 6;
                for (int i = pre; i > 0; i--)
                {
                    if (settingsNr < Math.Pow(10, i - 1))
                    {
                        pathStored += "0";
                    }
                    else
                    {
                        pathStored += settingsNr;
                        break;
                    }
                }
                pathStored += "_";

                // "date bonus"
                settings.creationTime = DateTime.Now;

                if (settings.creationTime.Day < 10)
                {
                    pathStored += "0";
                }
                pathStored += settings.creationTime.Day + ".";
                if (settings.creationTime.Month < 10)
                {
                    pathStored += "0";
                }
                pathStored += settings.creationTime.Month + ".";
                pathStored += settings.creationTime.Year;

                pathStored += ".xml";

                // II. serialize settings to xml at the current location
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                TextWriter writer = new StreamWriter(pathStored);
                serializer.Serialize(writer, settings);
                writer.Close();
                // III. increase settings nr
                using (StreamWriter writer1 = new StreamWriter(pathSettingsNr))
                {
                    writer1.Write(settingsNr + 1);
                }
                // show message that saving the settings worked
                System.Windows.Forms.MessageBox.Show("Settings were successfully saved at "
                    + pathStored);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Settings could not be saved");
            }
        }

        public void LoadSettings()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.ShowDialog();
            string pathToLoad = dialog.FileName;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                FileStream filestream = new FileStream(pathToLoad, FileMode.Open, FileAccess.Read, FileShare.Read);

                Settings settings = (Settings)serializer.Deserialize(filestream);
                filestream.Close();

                // set the settings
                    // general settings (benchmark)
                global.Verschnittoptimierung.numberBoards.Value = settings.numberOfBoards;
                global.Verschnittoptimierung.boardHeight.Value = settings.boardHeight;
                global.Verschnittoptimierung.boardWidth.Value = settings.boardWidth;
                global.Verschnittoptimierung.objectsMinNumber.Value = settings.objectsBoardMin;
                global.Verschnittoptimierung.objectsMaxNumber.Value = settings.objectsBoardMax;

                    // fill settings
                if(settings.bestFit)
                {
                    global.Verschnittoptimierung.radioButton_BestFit.Checked = true;
                }
                else
                {
                    global.Verschnittoptimierung.radioButton_FirstFit.Checked = true;
                }

                if(settings.bottomLeftFilling)
                {
                    global.Verschnittoptimierung.radioButton_BottomLeftFilling.Checked = true;
                }
                else
                {
                    global.Verschnittoptimierung.radioButton_FirstFitFilling.Checked = true;
                }

                if(settings.largestSideInc)
                {
                    global.Verschnittoptimierung.radioButton_largestSideInc.Checked = true;
                }
                else if(settings.largestSideDec)
                {
                    global.Verschnittoptimierung.radioButton_largestSideDec.Checked = true;
                }
                else if(settings.sizeInc)
                {
                    global.Verschnittoptimierung.radioButton_sizeInc.Checked = true;
                }
                else
                {
                    global.Verschnittoptimierung.radioButton_sizeDec.Checked = true;
                }

                if(settings.min_xl_y)
                {
                    global.Verschnittoptimierung.radioButton_min_xl_y.Checked = true;
                }
                else
                {
                    global.Verschnittoptimierung.radioButton_min_xr_y.Checked = true;
                }

                // evolutionary settings
                global.Verschnittoptimierung.evAlg_mue.Value = settings.mue;
                global.Verschnittoptimierung.evAlg_mult.Value = settings.mult;
                global.Verschnittoptimierung.evAlg_mutationRate.Value = Convert.ToDecimal(settings.mutationRate);
                global.Verschnittoptimierung.checkBox_greedyTournamentPopulation.Checked = settings.tournamentPopulation;
                global.Verschnittoptimierung.checkBox_greedyTournamentProceduresOnly.Checked = settings.tournamentGreedyProcOnly;

                global.Verschnittoptimierung.checkBox_greedy1.Checked = settings.greedy1;
                global.Verschnittoptimierung.checkBox_greedy2.Checked = settings.greedy2;
                global.Verschnittoptimierung.checkBox_greedy3.Checked = settings.greedy3;
                global.Verschnittoptimierung.checkBox_greedy4.Checked = settings.greedy4;
                global.Verschnittoptimierung.checkBox_greedy5.Checked = settings.greedy5;
                global.Verschnittoptimierung.checkBox_greedy6.Checked = settings.greedy6;
                global.Verschnittoptimierung.checkBox_greedy7.Checked = settings.greedy7;
                global.Verschnittoptimierung.checkBox_greedy8.Checked = settings.greedy8;
                global.Verschnittoptimierung.checkBox_greedy9.Checked = settings.greedy9;
                global.Verschnittoptimierung.checkBox_greedy10.Checked = settings.greedy10;
                global.Verschnittoptimierung.checkBox_greedy11.Checked = settings.greedy11;
                global.Verschnittoptimierung.checkBox_greedy12.Checked = settings.greedy12;
                global.Verschnittoptimierung.checkBox_greedy13.Checked = settings.greedy13;
                global.Verschnittoptimierung.checkBox_greedy14.Checked = settings.greedy14;
                global.Verschnittoptimierung.checkBox_greedy15.Checked = settings.greedy15;
                global.Verschnittoptimierung.checkBox_greedy16.Checked = settings.greedy16;
                
                
                System.Windows.Forms.MessageBox.Show("Settings were loaded successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Settings could not be loaded. Please make sure to select the correct file path.");
            }
        }

    }
}
