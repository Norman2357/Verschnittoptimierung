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
                settings.numberOfBoards = Convert.ToInt32(global.Verschnittoptimierung.numberBoards.Value);
                settings.boardHeight = Convert.ToInt32(global.Verschnittoptimierung.boardHeight.Value);
                settings.boardWidth = Convert.ToInt32(global.Verschnittoptimierung.boardWidth.Value);
                settings.objectsBoardMin = Convert.ToInt32(global.Verschnittoptimierung.objectsMinNumber.Value);
                settings.objectsBoardMax = Convert.ToInt32(global.Verschnittoptimierung.objectsMaxNumber.Value);

                
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
                global.Verschnittoptimierung.numberBoards.Value = settings.numberOfBoards;
                global.Verschnittoptimierung.boardHeight.Value = settings.boardHeight;
                global.Verschnittoptimierung.boardWidth.Value = settings.boardWidth;
                global.Verschnittoptimierung.objectsMinNumber.Value = settings.objectsBoardMin;
                global.Verschnittoptimierung.objectsMaxNumber.Value = settings.objectsBoardMax;
                
                System.Windows.Forms.MessageBox.Show("Settings were loaded successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Settings could not be loaded. Please make sure to select the correct file path.");
            }
        }

    }
}
