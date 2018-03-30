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
    public partial class Form1 : Form, IObserver
    {
        private Student student;

        public Form1(Student student) 
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(student);
            frm.Show();
        }
    }
}
