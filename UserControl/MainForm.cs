using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlLearning
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Person p = new Person
            {
                FirstName = "Andrei",
                LastName = "Roca",
                Age = 27
            };
            personControl1.Person = p;
            //PersonControl persControl = new PersonControl();
            //persControl.Person = p;//iar valorile din instanta p vor trece in Person Control1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nume " + personControl1.Person.LastName + " Prenume " + personControl1.Person.FirstName + " Varsta " + personControl1.Person.Age);
        }
    }
}
