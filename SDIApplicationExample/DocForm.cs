using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIApplicationExample
{
    public partial class DocForm : Form
    {
        public DocForm()
        {
            InitializeComponent();
        }
        private static int _counter = 0;
        internal static DocForm CreateForm()
        {
            var form = new DocForm();
            form.Text = "New Document " + ++_counter;
            SDIApplication.SdiInstance.ApplicationContext.MainForm = form;//aici am setat ca instanta aia singleton sa fie main formul aplicatiei
            form.Show();

            return form;//returnam referinta la DocForm
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm();
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
            DocumentTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentTextBox.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentTextBox.SelectAll();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {//sa inchidem documentul daca exsita vreunul activ
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Rich text files|*.rtf"; //va salva defaul doar in format rtf
            dialog.AddExtension = true;//daca nu ne da o extensie utilizatorul, o dam default rtf
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)//daca apasa ok atunci salvam fisierul de sus 
            {
                DocumentTextBox.SaveFile(dialog.FileName);//dialog.FileNime - adica salvam documentul in fisierul pe care il indica utilizatorul (cand cauti tu asa sa salvezi gen, iti trece calea acolo...)
                Text = dialog.FileName;//schimba titlul formului copil 
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich text files|*.rtf";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                this.DocumentTextBox.LoadFile(dialog.FileName);
                this.Text = dialog.FileName;
                this.Show();

            }
        }

    }
}
