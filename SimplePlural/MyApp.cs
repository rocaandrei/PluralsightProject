using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePlural
{
    public partial class MyApp : Form
    {
        public MyApp()
        {
            InitializeComponent();//metoda asta iti initializeaza elementele in componenta ta WF
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)//event handler cand inchidem aplicatia 
        {
            //prima varianta personalizata
            CustomDialogBox(e);
            //A 2 a varianta de inchidere jos
            string msg = "Are you sure you want to close?";
            DialogResult result = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;// anulam evenimentul, daca nu vrem sa inchidem aplicatia, in else-ul asta
                                // va intra si va anula evenimentul din FormCloasingEventArgs si nu se va mai inchide aplicatia
                                // si nu mai avem nevoie de else! pentru ca ne va dubla intrebarea
            }
        }
        private static void CustomDialogBox(FormClosingEventArgs e)
        {
            //instantiem casuta noastra de inchidere personalizata, formul ala de l-am facut eu
            ConfirmDialog personalConfirm = new ConfirmDialog();
            //acum facem interograrea ca ce-a de jos
            if (personalConfirm.ShowDialog() == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void ShowMessageButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)//verifica daca a fost selectat vreun obiect din listBox1
            {
                string msg = "Please select an item from the list box";
                MessageBox.Show(msg, "Atention!");//asa iti arata un MessageBox = O cutie cu avertizare(primul parametru un string cu mesajul ce va veni, al doila un string cu numele chenarului
            }
            else
            {
                MessageLabel.Text = listBox1.Text;
            }
        }

        private void MyApp_Load(object sender, EventArgs e)//evenimentul asta e folosit cand vrem sa adaugam date in controlarul nostru, pentru data binding, se pot adauga si manual 
        {
            listBox1.Items.Add("Oranges");
            listBox1.Items.Add("Apples");
            listBox1.Items.Add("Banana");
            listBox1.Items.Add("Stroberry");
            listBox1.Items.Add("Chery");
        }
        //event handler-ul asta se apeleaza cand vrem sa inchidem aplicatia 

    }
}
