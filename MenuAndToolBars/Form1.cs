using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndToolBars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on File or New");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("News click");
        }
    }
}
