using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlLearning;

namespace UserControlLearning
{
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {
            InitializeComponent();
        }
        Person _person = new Person();
        public Person Person// aici setam valorile in functie de specificaile din UserControl[Design] si ne setam valorile 
        {
            get
            {
                _person.FirstName = FirstNameTextBox.Text;
                _person.LastName = SecondNameTextBox.Text;
                _person.Age = int.Parse(AgeTextBox.Text);
                return _person;
            }
            set
            {
                FirstNameTextBox.Text = _person.FirstName;
                SecondNameTextBox.Text = _person.LastName;
                AgeTextBox.Text = _person.Age.ToString();
                _person = value;
            }
        }
    }
}
