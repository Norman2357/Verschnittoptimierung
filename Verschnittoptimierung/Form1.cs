using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verschnittoptimierung.Properties;
using System.Threading;
using System.IO;

namespace Verschnittoptimierung
{
    public partial class Verschnittoptimierung1 : Form
    {
        private Object thislock = new Object();

        public Verschnittoptimierung1()
        {
            InitializeComponent();

            Base global = Base.GetInstance();

            /*
            Button displayButton = new Button();
            displayButton.Height = 40;
            displayButton.Width = 20;
            displayButton.Text = "<";
            displayButton.Location = new Point(3000, 240);
            display.Controls.Add(displayButton);
            */

            global.Verschnittoptimierung = this;
            // global.g = global.Verschnittoptimierung.display.CreateGraphics();

            // set display width in global initially
            global.displayWidth = global.Verschnittoptimierung.display.Width;

            // check if initial folder path is required
            string path = Environment.CurrentDirectory;
            // without bin\Debug
            path = path.Substring(0, path.Length - 9) + "Resources\\FolderPathGeneral.txt";
            string pathStored = System.IO.File.ReadAllText(path);
            if(pathStored.Equals(""))
            {
                // get initial folder path
                MessageBox.Show("Welcome to 'waste material optimization'. Please enter the folder path where the data for this program should be stored.");
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowDialog();
                string pathReceived = folderBrowserDialog.SelectedPath;
                // global.Verschnittoptimierung.Output.Text = pathReceived;

                // set the folder path in resources
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(pathReceived);
                }

                // create initial subfolders
                string pathVerschnittoptimierung = pathReceived + "\\Verschnittoptimierung";
                string pathBenchmarks = pathVerschnittoptimierung + "\\benchmarks";
                string pathSolutions = pathVerschnittoptimierung + "\\solutions";
                string pathSettings = pathVerschnittoptimierung + "\\settings";

                Directory.CreateDirectory(pathVerschnittoptimierung);
                Directory.CreateDirectory(pathBenchmarks);
                Directory.CreateDirectory(pathSolutions);
                Directory.CreateDirectory(pathSettings);
            }
        }
        
        private void Verschnittoptimierung_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(groupBox1.Visible==true)
            {
                groupBox1.Hide();
            }
            else
            {
                groupBox2.Hide();
                groupBox_EvolAlg_general.Hide();
                groupBox1.Show();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == true)
            {
                groupBox2.Hide();
            }
            else
            {
                groupBox1.Hide();
                groupBox_EvolAlg_general.Hide();
                groupBox2.Show();
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            if (groupBox_EvolAlg_general.Visible == true)
            {
                groupBox_EvolAlg_general.Hide();
            }
            else
            {
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox_EvolAlg_general.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(!groupBox5.Visible)
            {
                groupBox5.Show();
                button7.BackgroundImage = Resources.arrowUp;
            }
            else
            {
                groupBox5.Hide();
                button7.BackgroundImage = Resources.arrowDown;
            }
        }
        private void buttonSingleStep_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.ExecuteStep(0);
        }

        private void buttonQuickStep_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.ExecuteStep(1);
            // stepExecution.DrawRects();
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            // for testing only
            /*
            StepExecution stepExecution = new StepExecution();
            stepExecution.Test();
            */
            
            StepExecution stepExecution = new StepExecution();
            // stepExecution.DrawBoards();
            stepExecution.DrawNewDisplay();
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (objectsMinNumber.Value < 10)
            {
                objectsMinNumber.Value = 10;
            }
            if (objectsMinNumber.Value > 80)
            {
                objectsMinNumber.Value = 80;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
        // save and load
        private void SaveBenchmark_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("save benchmark");
        }

        private void LoadBenchmark_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("load benchmark");
        }
        
        private void SaveSolution_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("save solution");
        }

        private void LoadSolution_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("load solution");
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("save settings");
        }

        private void LoadSettings_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SaveOrLoad("load settings");
        }

        private void buttonSelectView_Click(object sender, EventArgs e)
        {
            StepExecution stepExecution = new StepExecution();
            stepExecution.SetContentToShow();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.Output.Text = "test1";
            //test123();
            Fill fill = new Fill();
            fill.Greedy(false, new Solution());
        }

        private void test123()
        {
            try
            {
                lock (this.thislock)
                {
                    this.Output.Text = "test2";
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void Output_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Base global = Base.GetInstance();

            Tools tools = new Tools();
            try
            {
                tools.Reset();
            }
            catch(Exception ex)
            {
                this.Output.Text = "Nothing to reset.";
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void button_greedySelectAll_Click(object sender, EventArgs e)
        {
            if(button_greedySelectAll.Text.Equals("select all"))
            {
                checkBox_greedy1.Checked = true;
                checkBox_greedy2.Checked = true;
                checkBox_greedy3.Checked = true;
                checkBox_greedy4.Checked = true;
                checkBox_greedy5.Checked = true;
                checkBox_greedy6.Checked = true;
                checkBox_greedy7.Checked = true;
                checkBox_greedy8.Checked = true;
                checkBox_greedy9.Checked = true;
                checkBox_greedy10.Checked = true;
                checkBox_greedy11.Checked = true;
                checkBox_greedy12.Checked = true;
                checkBox_greedy13.Checked = true;
                checkBox_greedy14.Checked = true;
                checkBox_greedy15.Checked = true;
                checkBox_greedy16.Checked = true;
                button_greedySelectAll.Text = "unselect all";
            }
            else
            {
                checkBox_greedy1.Checked = false;
                checkBox_greedy2.Checked = false;
                checkBox_greedy3.Checked = false;
                checkBox_greedy4.Checked = false;
                checkBox_greedy5.Checked = false;
                checkBox_greedy6.Checked = false;
                checkBox_greedy7.Checked = false;
                checkBox_greedy8.Checked = false;
                checkBox_greedy9.Checked = false;
                checkBox_greedy10.Checked = false;
                checkBox_greedy11.Checked = false;
                checkBox_greedy12.Checked = false;
                checkBox_greedy13.Checked = false;
                checkBox_greedy14.Checked = false;
                checkBox_greedy15.Checked = false;
                checkBox_greedy16.Checked = false;
                button_greedySelectAll.Text = "select all";
            }
        }
    }
}
