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
            for(int i = pre; i > 0; i--)
            {
                if(benchmarkNr < Math.Pow(10,i-1))
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
            if(global.benchmark.creationTime.Month <10)
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
                writer1.Write(benchmarkNr+1);
            }
        }

        public void LoadBenchmark()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            string pathToLoad = dialog.SelectedPath;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Benchmark));
                FileStream filestream = new FileStream(pathToLoad, FileMode.Open, FileAccess.Read, FileShare.Read);

                Benchmark benchmark = (Benchmark)serializer.Deserialize(filestream);
                filestream.Close();
                global.benchmark = benchmark;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Benchmark could not be loaded. Please make sure to select the correct file path.");
            }
        }

        public void SaveSolution()
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
                if (solutionNr < Math.Pow(10, i))
                {
                    pathStored += "0";
                }
                else
                {
                    pathStored += solutionNr;
                    break;
                }
            }

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
            pathStored += global.solution.successRate + ".xml";

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
        }

        public void LoadSolution()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            string pathToLoad = dialog.SelectedPath;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Solution));
                FileStream filestream = new FileStream(pathToLoad, FileMode.Open, FileAccess.Read, FileShare.Read);

                Solution solution = (Solution)serializer.Deserialize(filestream);
                filestream.Close();
                global.solution = solution;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Solution could not be loaded. Please make sure to select the correct file path.");
            }
        }

        public void SaveSettings()
        {
            // get folder path

            // serialize solution to xml at the current location

            // increase solution nr
        }

        public void LoadSettings()
        {

        }

    }
}
