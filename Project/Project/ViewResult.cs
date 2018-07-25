using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Fieldes;

namespace Project
{
    public partial class viewResult : Form
    {
        private List<ResultField> refResult;
        public viewResult()
        {
            InitializeComponent();
        }

        public viewResult( ref List<ResultField> resul)
        {
            InitializeComponent();
            refResult = resul;
        }

        private void ViewResult_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = refResult.Select((x, data) => new
            {
                Serial = data + 1,
                ID = x.ID,
                Name = x.Name,
                ExamDate = x.ExamDate,
                QuizeNumber = x.QuizeNumber,
                Mark = x.Mark
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = refResult.Where(x => x.ID == txtID.Text.Trim()).Select((x, data) => new
            {
                Serial = data + 1,
                ID = x.ID,
                Name = x.Name,
                ExamDate = x.ExamDate,
                QuizeNumber = x.QuizeNumber,
                Mark = x.Mark
            }).ToList();
        }

    }
}
