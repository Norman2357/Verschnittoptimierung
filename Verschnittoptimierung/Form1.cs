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

namespace Verschnittoptimierung
{
    public partial class Verschnittoptimierung : Form
    {

        public Verschnittoptimierung()
        {
            InitializeComponent();
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
                groupBox3.Hide();
                groupBox4.Hide();
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
                groupBox3.Hide();
                groupBox4.Hide();
                groupBox2.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == true)
            {
                groupBox3.Hide();
            }
            else
            {
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox4.Hide();
                groupBox3.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (groupBox4.Visible == true)
            {
                groupBox4.Hide();
            }
            else
            {
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                groupBox4.Show();
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
