using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fieldes;

namespace Project
{
    public partial class ShowStudent : Form
    {
        List<Fieldes.Field> refStudent;
        public ShowStudent()
        {
            InitializeComponent();
        }
        public ShowStudent(ref List<Field> Stud)
        {
            InitializeComponent();
            refStudent = Stud;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = refStudent.Where(x => x.ID == txtID.Text.Trim()).Select((x, data) => new 
            { Serial = data + 1, ID = x.ID, Name = x.Name, Email = x.Email, Phone = x.PhoneNo }).ToList();

            

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = refStudent.Select((x, data) => new 
            { Serial = data + 1, ID = x.ID, Name = x.Name, Email = x.Email, Phone = x.PhoneNo }).ToList();
        }
    }
}
