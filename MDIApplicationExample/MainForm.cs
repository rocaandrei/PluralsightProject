using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApplicationExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private int counter = 0;//asta o sa-l folosesc sa modific titlul documentului sa fie personalizat 
        //daca vrei sa te abonezi la un eveniment deja folosit in alta parte, poti sa chemi EventHandler-ul tau sa cheme al eventHandler care sa faca acelasi lucru 
        //sau sa selectezi din casuta de evenimente evenimentul asta in cauza
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChidForm childForm = new ChidForm();
            childForm.MdiParent = this; //sintagma asta vrea sa zica ca parintele lui childForm este acest MainForm(this)
            counter += 1;
            childForm.Text = "New Document " + counter;
            childForm.Show(); //asta o sa-mi activeze formul copil in MainForm
        }
        //evenimentele de mai jos sunt destinate sa-mi aranjeze ferestrele deschise 
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //verificam daca avem un document deschis ce sa poata fi modificat 
            if (this.ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;
                childForm.DocumentTextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;
                childForm.DocumentTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;
                childForm.DocumentTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;
                childForm.DocumentTextBox.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;
                childForm.DocumentTextBox.SelectAll();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {//sa inchidem documentul daca exsita vreunul activ
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //metoda asta inchide orice fereastra copil deschisa si cea principala 
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)//vedem daca e un form copil facut 
            {
                ChidForm childForm = (ChidForm)ActiveMdiChild;//aici ii facem cast in tipul ChidForm

                var dialog = new SaveFileDialog();
                dialog.Filter = "Rich text files|*.rtf"; //va salva defaul doar in format rtf
                dialog.AddExtension = true;//daca nu ne da o extensie utilizatorul, o dam default rtf
                var result = dialog.ShowDialog();

                if(result == DialogResult.OK )//daca apasa ok atunci salvam fisierul de sus 
                {
                    childForm.DocumentTextBox.SaveFile(dialog.FileName);//dialog.FileNime - adica salvam documentul in fisierul pe care il indica utilizatorul (cand cauti tu asa sa salvezi gen, iti trece calea acolo...)
                    childForm.Text =  dialog.FileName;//schimba titlul formului copil 
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich text files|*.rtf";
            var result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                var childForm = new ChidForm();
                childForm.DocumentTextBox.LoadFile(dialog.FileName);
                childForm.Text = dialog.FileName;
                childForm.MdiParent = this;
                childForm.Show();

            }
        }

       
    }
}
