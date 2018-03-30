using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverPattern
{
    public partial class Form2 : Form, IObserver
    {
        private Student student;
        public Form2(Student student)
        {
            InitializeComponent();
            this.student = student;
            student.Subscribe(this);
        }

        public void Update(object sender)
        {
            Student student = (Student)sender;
            txtFirstName.Text = student.FirstName;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            student.FirstName = txtFirstName.Text;
        }
    }
}
