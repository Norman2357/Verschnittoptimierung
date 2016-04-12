﻿namespace Verschnittoptimierung
{
    partial class Verschnittoptimierung1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verschnittoptimierung1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numberBoards = new System.Windows.Forms.NumericUpDown();
            this.objectsMaxNumber = new System.Windows.Forms.NumericUpDown();
            this.objectsMinNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.boardHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boardWidth = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox_sortedBy = new System.Windows.Forms.GroupBox();
            this.radioButton_sizeDec = new System.Windows.Forms.RadioButton();
            this.radioButton_largestSideDec = new System.Windows.Forms.RadioButton();
            this.radioButton_sizeInc = new System.Windows.Forms.RadioButton();
            this.radioButton_largestSideInc = new System.Windows.Forms.RadioButton();
            this.groupBox_PlacingStrategy = new System.Windows.Forms.GroupBox();
            this.radioButton_BottomLeftFilling = new System.Windows.Forms.RadioButton();
            this.radioButton_FirstFitFilling = new System.Windows.Forms.RadioButton();
            this.groupBox_BoardStrategy = new System.Windows.Forms.GroupBox();
            this.radioButton_BestFit = new System.Windows.Forms.RadioButton();
            this.radioButton_FirstFit = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.display = new System.Windows.Forms.Panel();
            this.buttonInDisplay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ButtonSingleStep = new System.Windows.Forms.Button();
            this.buttonQuickStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveBenchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadBenchmark = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.fitnessValue = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.cl_objectsPlaced = new System.Windows.Forms.TextBox();
            this.cl_objectsLeft = new System.Windows.Forms.TextBox();
            this.cl_objectsTotal = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cl_percentageAreaFilled = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.Label();
            this.buttonSelectView = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonReset = new System.Windows.Forms.Button();
            this.radioButton_min_xr_y = new System.Windows.Forms.RadioButton();
            this.radioButton_min_xl_y = new System.Windows.Forms.RadioButton();
            this.groupBox_Priority = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsMaxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsMinNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_sortedBy.SuspendLayout();
            this.groupBox_PlacingStrategy.SuspendLayout();
            this.groupBox_BoardStrategy.SuspendLayout();
            this.display.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Priority.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numberBoards);
            this.groupBox1.Controls.Add(this.objectsMaxNumber);
            this.groupBox1.Controls.Add(this.objectsMinNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.boardHeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.boardWidth);
            this.groupBox1.Location = new System.Drawing.Point(31, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "number of boards";
            // 
            // numberBoards
            // 
            this.numberBoards.Location = new System.Drawing.Point(102, 37);
            this.numberBoards.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberBoards.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBoards.Name = "numberBoards";
            this.numberBoards.Size = new System.Drawing.Size(53, 20);
            this.numberBoards.TabIndex = 14;
            this.numberBoards.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // objectsMaxNumber
            // 
            this.objectsMaxNumber.Location = new System.Drawing.Point(196, 112);
            this.objectsMaxNumber.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.objectsMaxNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.objectsMaxNumber.Name = "objectsMaxNumber";
            this.objectsMaxNumber.Size = new System.Drawing.Size(43, 20);
            this.objectsMaxNumber.TabIndex = 13;
            this.objectsMaxNumber.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // objectsMinNumber
            // 
            this.objectsMinNumber.Location = new System.Drawing.Point(102, 112);
            this.objectsMinNumber.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.objectsMinNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.objectsMinNumber.Name = "objectsMinNumber";
            this.objectsMinNumber.Size = new System.Drawing.Size(43, 20);
            this.objectsMinNumber.TabIndex = 1;
            this.objectsMinNumber.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.objectsMinNumber.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(106, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "cm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "cm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Board(s)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Objects";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "max";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "objects / board min";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // boardHeight
            // 
            this.boardHeight.Location = new System.Drawing.Point(51, 64);
            this.boardHeight.Maximum = new decimal(new int[] {
            236,
            0,
            0,
            0});
            this.boardHeight.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.boardHeight.Name = "boardHeight";
            this.boardHeight.Size = new System.Drawing.Size(53, 20);
            this.boardHeight.TabIndex = 3;
            this.boardHeight.Value = new decimal(new int[] {
            236,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "length";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // boardWidth
            // 
            this.boardWidth.Location = new System.Drawing.Point(169, 64);
            this.boardWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.boardWidth.Minimum = new decimal(new int[] {
            236,
            0,
            0,
            0});
            this.boardWidth.Name = "boardWidth";
            this.boardWidth.Size = new System.Drawing.Size(53, 20);
            this.boardWidth.TabIndex = 1;
            this.boardWidth.Value = new decimal(new int[] {
            236,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.button2.Location = new System.Drawing.Point(0, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 71);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.button3.Location = new System.Drawing.Point(0, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 118);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Thistle;
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox_Priority);
            this.groupBox2.Controls.Add(this.groupBox_sortedBy);
            this.groupBox2.Controls.Add(this.groupBox_PlacingStrategy);
            this.groupBox2.Controls.Add(this.groupBox_BoardStrategy);
            this.groupBox2.Location = new System.Drawing.Point(31, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 230);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fill";
            this.groupBox2.Visible = false;
            // 
            // groupBox_sortedBy
            // 
            this.groupBox_sortedBy.Controls.Add(this.radioButton_sizeDec);
            this.groupBox_sortedBy.Controls.Add(this.radioButton_largestSideDec);
            this.groupBox_sortedBy.Controls.Add(this.radioButton_sizeInc);
            this.groupBox_sortedBy.Controls.Add(this.radioButton_largestSideInc);
            this.groupBox_sortedBy.Location = new System.Drawing.Point(6, 103);
            this.groupBox_sortedBy.Name = "groupBox_sortedBy";
            this.groupBox_sortedBy.Size = new System.Drawing.Size(225, 63);
            this.groupBox_sortedBy.TabIndex = 3;
            this.groupBox_sortedBy.TabStop = false;
            this.groupBox_sortedBy.Text = "sorted by";
            // 
            // radioButton_sizeDec
            // 
            this.radioButton_sizeDec.AutoSize = true;
            this.radioButton_sizeDec.Location = new System.Drawing.Point(128, 42);
            this.radioButton_sizeDec.Name = "radioButton_sizeDec";
            this.radioButton_sizeDec.Size = new System.Drawing.Size(67, 17);
            this.radioButton_sizeDec.TabIndex = 3;
            this.radioButton_sizeDec.Text = "size dec.";
            this.radioButton_sizeDec.UseVisualStyleBackColor = true;
            // 
            // radioButton_largestSideDec
            // 
            this.radioButton_largestSideDec.AutoSize = true;
            this.radioButton_largestSideDec.Location = new System.Drawing.Point(7, 42);
            this.radioButton_largestSideDec.Name = "radioButton_largestSideDec";
            this.radioButton_largestSideDec.Size = new System.Drawing.Size(102, 17);
            this.radioButton_largestSideDec.TabIndex = 2;
            this.radioButton_largestSideDec.Text = "largest side dec.";
            this.radioButton_largestSideDec.UseVisualStyleBackColor = true;
            // 
            // radioButton_sizeInc
            // 
            this.radioButton_sizeInc.AutoSize = true;
            this.radioButton_sizeInc.Location = new System.Drawing.Point(128, 19);
            this.radioButton_sizeInc.Name = "radioButton_sizeInc";
            this.radioButton_sizeInc.Size = new System.Drawing.Size(63, 17);
            this.radioButton_sizeInc.TabIndex = 1;
            this.radioButton_sizeInc.Text = "size inc.";
            this.radioButton_sizeInc.UseVisualStyleBackColor = true;
            // 
            // radioButton_largestSideInc
            // 
            this.radioButton_largestSideInc.AutoSize = true;
            this.radioButton_largestSideInc.Checked = true;
            this.radioButton_largestSideInc.Location = new System.Drawing.Point(7, 19);
            this.radioButton_largestSideInc.Name = "radioButton_largestSideInc";
            this.radioButton_largestSideInc.Size = new System.Drawing.Size(98, 17);
            this.radioButton_largestSideInc.TabIndex = 0;
            this.radioButton_largestSideInc.TabStop = true;
            this.radioButton_largestSideInc.Text = "largest side inc.";
            this.radioButton_largestSideInc.UseVisualStyleBackColor = true;
            // 
            // groupBox_PlacingStrategy
            // 
            this.groupBox_PlacingStrategy.Controls.Add(this.radioButton_BottomLeftFilling);
            this.groupBox_PlacingStrategy.Controls.Add(this.radioButton_FirstFitFilling);
            this.groupBox_PlacingStrategy.Location = new System.Drawing.Point(6, 61);
            this.groupBox_PlacingStrategy.Name = "groupBox_PlacingStrategy";
            this.groupBox_PlacingStrategy.Size = new System.Drawing.Size(225, 43);
            this.groupBox_PlacingStrategy.TabIndex = 2;
            this.groupBox_PlacingStrategy.TabStop = false;
            this.groupBox_PlacingStrategy.Text = "Placing Strategy";
            // 
            // radioButton_BottomLeftFilling
            // 
            this.radioButton_BottomLeftFilling.AutoSize = true;
            this.radioButton_BottomLeftFilling.Location = new System.Drawing.Point(102, 19);
            this.radioButton_BottomLeftFilling.Name = "radioButton_BottomLeftFilling";
            this.radioButton_BottomLeftFilling.Size = new System.Drawing.Size(44, 17);
            this.radioButton_BottomLeftFilling.TabIndex = 1;
            this.radioButton_BottomLeftFilling.Text = "BLF";
            this.radioButton_BottomLeftFilling.UseVisualStyleBackColor = true;
            // 
            // radioButton_FirstFitFilling
            // 
            this.radioButton_FirstFitFilling.AutoSize = true;
            this.radioButton_FirstFitFilling.Checked = true;
            this.radioButton_FirstFitFilling.Location = new System.Drawing.Point(7, 19);
            this.radioButton_FirstFitFilling.Name = "radioButton_FirstFitFilling";
            this.radioButton_FirstFitFilling.Size = new System.Drawing.Size(43, 17);
            this.radioButton_FirstFitFilling.TabIndex = 0;
            this.radioButton_FirstFitFilling.TabStop = true;
            this.radioButton_FirstFitFilling.Text = "FFF";
            this.radioButton_FirstFitFilling.UseVisualStyleBackColor = true;
            // 
            // groupBox_BoardStrategy
            // 
            this.groupBox_BoardStrategy.Controls.Add(this.radioButton_BestFit);
            this.groupBox_BoardStrategy.Controls.Add(this.radioButton_FirstFit);
            this.groupBox_BoardStrategy.Location = new System.Drawing.Point(6, 19);
            this.groupBox_BoardStrategy.Name = "groupBox_BoardStrategy";
            this.groupBox_BoardStrategy.Size = new System.Drawing.Size(225, 43);
            this.groupBox_BoardStrategy.TabIndex = 1;
            this.groupBox_BoardStrategy.TabStop = false;
            this.groupBox_BoardStrategy.Text = "Board Strategy";
            // 
            // radioButton_BestFit
            // 
            this.radioButton_BestFit.AutoSize = true;
            this.radioButton_BestFit.Location = new System.Drawing.Point(102, 19);
            this.radioButton_BestFit.Name = "radioButton_BestFit";
            this.radioButton_BestFit.Size = new System.Drawing.Size(38, 17);
            this.radioButton_BestFit.TabIndex = 1;
            this.radioButton_BestFit.Text = "BF";
            this.radioButton_BestFit.UseVisualStyleBackColor = true;
            // 
            // radioButton_FirstFit
            // 
            this.radioButton_FirstFit.AutoSize = true;
            this.radioButton_FirstFit.Checked = true;
            this.radioButton_FirstFit.Location = new System.Drawing.Point(7, 19);
            this.radioButton_FirstFit.Name = "radioButton_FirstFit";
            this.radioButton_FirstFit.Size = new System.Drawing.Size(37, 17);
            this.radioButton_FirstFit.TabIndex = 0;
            this.radioButton_FirstFit.TabStop = true;
            this.radioButton_FirstFit.Text = "FF";
            this.radioButton_FirstFit.UseVisualStyleBackColor = true;
            this.radioButton_FirstFit.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Location = new System.Drawing.Point(0, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 118);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Optimization";
            this.groupBox3.Visible = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.button4.Location = new System.Drawing.Point(0, 445);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 146);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox4.Location = new System.Drawing.Point(31, 445);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 128);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Evolutionary Algorithm";
            this.groupBox4.Visible = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // display
            // 
            this.display.AutoScroll = true;
            this.display.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.display.Controls.Add(this.buttonInDisplay);
            this.display.Location = new System.Drawing.Point(44, 41);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(1100, 550);
            this.display.TabIndex = 6;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            // 
            // buttonInDisplay
            // 
            this.buttonInDisplay.Location = new System.Drawing.Point(821, 229);
            this.buttonInDisplay.Name = "buttonInDisplay";
            this.buttonInDisplay.Size = new System.Drawing.Size(23, 53);
            this.buttonInDisplay.TabIndex = 0;
            this.buttonInDisplay.Text = "<";
            this.buttonInDisplay.UseVisualStyleBackColor = true;
            this.buttonInDisplay.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.button1.Location = new System.Drawing.Point(0, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 127);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Create Benchmark",
            "Fill",
            "Local Optimization",
            "Evolutionary Algorithm"});
            this.comboBox1.Location = new System.Drawing.Point(44, 635);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "None";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ButtonSingleStep
            // 
            this.ButtonSingleStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonSingleStep.BackgroundImage")));
            this.ButtonSingleStep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonSingleStep.Location = new System.Drawing.Point(192, 635);
            this.ButtonSingleStep.Name = "ButtonSingleStep";
            this.ButtonSingleStep.Size = new System.Drawing.Size(32, 23);
            this.ButtonSingleStep.TabIndex = 7;
            this.ButtonSingleStep.UseVisualStyleBackColor = true;
            this.ButtonSingleStep.Click += new System.EventHandler(this.buttonSingleStep_Click);
            // 
            // buttonQuickStep
            // 
            this.buttonQuickStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonQuickStep.BackgroundImage")));
            this.buttonQuickStep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonQuickStep.Location = new System.Drawing.Point(230, 635);
            this.buttonQuickStep.Name = "buttonQuickStep";
            this.buttonQuickStep.Size = new System.Drawing.Size(32, 23);
            this.buttonQuickStep.TabIndex = 8;
            this.buttonQuickStep.UseVisualStyleBackColor = true;
            this.buttonQuickStep.Click += new System.EventHandler(this.buttonQuickStep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 610);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Perform Action";
            // 
            // Menu
            // 
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBenchmark,
            this.LoadBenchmark,
            this.SaveSolution,
            this.LoadSolution,
            this.SaveSettings,
            this.LoadSettings});
            this.Menu.Image = ((System.Drawing.Image)(resources.GetObject("Menu.Image")));
            this.Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(29, 22);
            this.Menu.Text = "Menu";
            this.Menu.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // SaveBenchmark
            // 
            this.SaveBenchmark.Name = "SaveBenchmark";
            this.SaveBenchmark.Size = new System.Drawing.Size(163, 22);
            this.SaveBenchmark.Text = "Save Benchmark";
            this.SaveBenchmark.Click += new System.EventHandler(this.SaveBenchmark_Click);
            // 
            // LoadBenchmark
            // 
            this.LoadBenchmark.Name = "LoadBenchmark";
            this.LoadBenchmark.Size = new System.Drawing.Size(163, 22);
            this.LoadBenchmark.Text = "Load Benchmark";
            this.LoadBenchmark.Click += new System.EventHandler(this.LoadBenchmark_Click);
            // 
            // SaveSolution
            // 
            this.SaveSolution.Name = "SaveSolution";
            this.SaveSolution.Size = new System.Drawing.Size(163, 22);
            this.SaveSolution.Text = "Save Solution";
            this.SaveSolution.Click += new System.EventHandler(this.SaveSolution_Click);
            // 
            // LoadSolution
            // 
            this.LoadSolution.Name = "LoadSolution";
            this.LoadSolution.Size = new System.Drawing.Size(163, 22);
            this.LoadSolution.Text = "Load Solution";
            this.LoadSolution.Click += new System.EventHandler(this.LoadSolution_Click);
            // 
            // SaveSettings
            // 
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(163, 22);
            this.SaveSettings.Text = "Save Settings";
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // LoadSettings
            // 
            this.LoadSettings.Name = "LoadSettings";
            this.LoadSettings.Size = new System.Drawing.Size(163, 22);
            this.LoadSettings.Text = "Load Settings";
            this.LoadSettings.Click += new System.EventHandler(this.LoadSettings_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1151, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(996, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fitness Value";
            // 
            // fitnessValue
            // 
            this.fitnessValue.AutoSize = true;
            this.fitnessValue.Location = new System.Drawing.Point(1070, 12);
            this.fitnessValue.Name = "fitnessValue";
            this.fitnessValue.Size = new System.Drawing.Size(13, 13);
            this.fitnessValue.TabIndex = 12;
            this.fitnessValue.Text = "0";
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(1115, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(29, 23);
            this.button7.TabIndex = 13;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.textBox11);
            this.groupBox5.Controls.Add(this.cl_objectsPlaced);
            this.groupBox5.Controls.Add(this.cl_objectsLeft);
            this.groupBox5.Controls.Add(this.cl_objectsTotal);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.cl_percentageAreaFilled);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(905, 41);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 550);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Results Details";
            this.groupBox5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(218, 225);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "%";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(191, 222);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(21, 20);
            this.textBox5.TabIndex = 29;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(91, 224);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "quantity";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(136, 222);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(36, 20);
            this.textBox11.TabIndex = 27;
            // 
            // cl_objectsPlaced
            // 
            this.cl_objectsPlaced.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cl_objectsPlaced.Enabled = false;
            this.cl_objectsPlaced.Location = new System.Drawing.Point(176, 18);
            this.cl_objectsPlaced.Name = "cl_objectsPlaced";
            this.cl_objectsPlaced.Size = new System.Drawing.Size(36, 20);
            this.cl_objectsPlaced.TabIndex = 26;
            // 
            // cl_objectsLeft
            // 
            this.cl_objectsLeft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cl_objectsLeft.Enabled = false;
            this.cl_objectsLeft.Location = new System.Drawing.Point(176, 41);
            this.cl_objectsLeft.Name = "cl_objectsLeft";
            this.cl_objectsLeft.Size = new System.Drawing.Size(36, 20);
            this.cl_objectsLeft.TabIndex = 25;
            // 
            // cl_objectsTotal
            // 
            this.cl_objectsTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cl_objectsTotal.Enabled = false;
            this.cl_objectsTotal.Location = new System.Drawing.Point(79, 18);
            this.cl_objectsTotal.Name = "cl_objectsTotal";
            this.cl_objectsTotal.Size = new System.Drawing.Size(36, 20);
            this.cl_objectsTotal.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(133, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(21, 13);
            this.label25.TabIndex = 23;
            this.label25.Text = "left";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(133, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "placed";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Objects total";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 225);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "waste material";
            // 
            // cl_percentageAreaFilled
            // 
            this.cl_percentageAreaFilled.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cl_percentageAreaFilled.Enabled = false;
            this.cl_percentageAreaFilled.Location = new System.Drawing.Point(74, 62);
            this.cl_percentageAreaFilled.Name = "cl_percentageAreaFilled";
            this.cl_percentageAreaFilled.Size = new System.Drawing.Size(41, 20);
            this.cl_percentageAreaFilled.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "area filled";
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Location = new System.Drawing.Point(324, 624);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(39, 13);
            this.Output.TabIndex = 14;
            this.Output.Text = "Output";
            this.Output.Click += new System.EventHandler(this.Output_Click);
            // 
            // buttonSelectView
            // 
            this.buttonSelectView.Enabled = false;
            this.buttonSelectView.Location = new System.Drawing.Point(476, 12);
            this.buttonSelectView.Name = "buttonSelectView";
            this.buttonSelectView.Size = new System.Drawing.Size(101, 21);
            this.buttonSelectView.TabIndex = 15;
            this.buttonSelectView.UseVisualStyleBackColor = true;
            this.buttonSelectView.Click += new System.EventHandler(this.buttonSelectView_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // buttonReset
            // 
            this.buttonReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReset.BackgroundImage")));
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReset.Location = new System.Drawing.Point(281, 635);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(32, 23);
            this.buttonReset.TabIndex = 16;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // radioButton_min_xr_y
            // 
            this.radioButton_min_xr_y.AutoSize = true;
            this.radioButton_min_xr_y.Location = new System.Drawing.Point(77, 19);
            this.radioButton_min_xr_y.Name = "radioButton_min_xr_y";
            this.radioButton_min_xr_y.Size = new System.Drawing.Size(63, 17);
            this.radioButton_min_xr_y.TabIndex = 1;
            this.radioButton_min_xr_y.Text = "min xr, y";
            this.radioButton_min_xr_y.UseVisualStyleBackColor = true;
            // 
            // radioButton_min_xl_y
            // 
            this.radioButton_min_xl_y.AutoSize = true;
            this.radioButton_min_xl_y.Checked = true;
            this.radioButton_min_xl_y.Location = new System.Drawing.Point(7, 19);
            this.radioButton_min_xl_y.Name = "radioButton_min_xl_y";
            this.radioButton_min_xl_y.Size = new System.Drawing.Size(62, 17);
            this.radioButton_min_xl_y.TabIndex = 0;
            this.radioButton_min_xl_y.TabStop = true;
            this.radioButton_min_xl_y.Text = "min xl, y";
            this.radioButton_min_xl_y.UseVisualStyleBackColor = true;
            // 
            // groupBox_Priority
            // 
            this.groupBox_Priority.Controls.Add(this.radioButton_min_xr_y);
            this.groupBox_Priority.Controls.Add(this.radioButton_min_xl_y);
            this.groupBox_Priority.Location = new System.Drawing.Point(6, 168);
            this.groupBox_Priority.Name = "groupBox_Priority";
            this.groupBox_Priority.Size = new System.Drawing.Size(225, 43);
            this.groupBox_Priority.TabIndex = 3;
            this.groupBox_Priority.TabStop = false;
            this.groupBox_Priority.Text = "Priority";
            // 
            // Verschnittoptimierung1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1151, 689);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSelectView);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.fitnessValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonQuickStep);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ButtonSingleStep);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.display);
            this.Name = "Verschnittoptimierung1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verschnittoptimierung - Norman Naujokat";
            this.Load += new System.EventHandler(this.Verschnittoptimierung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsMaxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsMinNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox_sortedBy.ResumeLayout(false);
            this.groupBox_sortedBy.PerformLayout();
            this.groupBox_PlacingStrategy.ResumeLayout(false);
            this.groupBox_PlacingStrategy.PerformLayout();
            this.groupBox_BoardStrategy.ResumeLayout(false);
            this.groupBox_BoardStrategy.PerformLayout();
            this.display.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Priority.ResumeLayout(false);
            this.groupBox_Priority.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Panel display;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button ButtonSingleStep;
        public System.Windows.Forms.Button buttonQuickStep;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripDropDownButton Menu;
        public System.Windows.Forms.ToolStripMenuItem SaveBenchmark;
        public System.Windows.Forms.ToolStripMenuItem LoadBenchmark;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripMenuItem SaveSettings;
        public System.Windows.Forms.ToolStripMenuItem LoadSettings;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label fitnessValue;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button buttonInDisplay;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown boardWidth;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown boardHeight;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown objectsMinNumber;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown numberBoards;
        public System.Windows.Forms.NumericUpDown objectsMaxNumber;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox cl_percentageAreaFilled;
        public System.Windows.Forms.Label Output;
        public System.Windows.Forms.ToolStripMenuItem SaveSolution;
        public System.Windows.Forms.ToolStripMenuItem LoadSolution;
        public System.Windows.Forms.Button buttonSelectView;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox textBox11;
        public System.Windows.Forms.TextBox cl_objectsPlaced;
        public System.Windows.Forms.TextBox cl_objectsLeft;
        public System.Windows.Forms.TextBox cl_objectsTotal;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label3;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Button buttonReset;
        public System.Windows.Forms.RadioButton radioButton_FirstFit;
        public System.Windows.Forms.RadioButton radioButton_BestFit;
        public System.Windows.Forms.GroupBox groupBox_sortedBy;
        public System.Windows.Forms.RadioButton radioButton_sizeDec;
        public System.Windows.Forms.RadioButton radioButton_largestSideDec;
        public System.Windows.Forms.RadioButton radioButton_sizeInc;
        public System.Windows.Forms.RadioButton radioButton_largestSideInc;
        public System.Windows.Forms.GroupBox groupBox_PlacingStrategy;
        public System.Windows.Forms.RadioButton radioButton_BottomLeftFilling;
        public System.Windows.Forms.RadioButton radioButton_FirstFitFilling;
        public System.Windows.Forms.GroupBox groupBox_BoardStrategy;
        public System.Windows.Forms.GroupBox groupBox_Priority;
        public System.Windows.Forms.RadioButton radioButton_min_xr_y;
        public System.Windows.Forms.RadioButton radioButton_min_xl_y;
    }
}

