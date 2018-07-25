using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Fieldes;
namespace Project
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {


        private List<Field> refStudent;

        public List<ResultField> refResultEntry;

        void clear()
        {
            id.Text = "";
            name.Text = "";
            examDate.Text = "";
            quizeNumber.Text = "";
            totalMark.Text = "";
            id.IsEnabled = name.IsEnabled = examDate.IsEnabled = quizeNumber.IsEnabled = totalMark.IsEnabled = true;
        }

        public Result()
        {
            InitializeComponent();
        }

        public Result(ref List<Field> student, ref List<ResultField> result)
        {
            
            this.refStudent = student;
            this.refResultEntry = result;
            InitializeComponent();

        }

        #region Result Button
        private void cheack_Click(object sender, RoutedEventArgs e)
        {
            Field found = refStudent.Find(rs => rs.ID == id.Text);
            if (found.ID == id.Text)
            {
                name.Text = found.Name;
                name.IsEnabled = id.IsEnabled =  false;
                insert.IsEnabled = true;
                examDate.Focus();
            }
            else
            {
                MessageBox.Show("No ID Found");
                id.Focus();
            }
            
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var markEntry = refResultEntry.Find(rs => rs.ID == id.Text);
            if (markEntry.ID == id.Text)
            {
                name.Text = markEntry.Name;
                examDate.Text = markEntry.ExamDate;
                quizeNumber.Text = markEntry.QuizeNumber;
                totalMark.Text = markEntry.Mark.ToString();
                update.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("ID Not Found");
            }
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            
                refResultEntry.Add(new ResultField
                { ID = id.Text, Name = name.Text, ExamDate = examDate.Text.ToString(), QuizeNumber = quizeNumber.Text, Mark = int.Parse(totalMark.Text) });
                clear();
                id.Focus();
                insert.IsEnabled = false;
            
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            int found = refResultEntry.FindIndex(rs => rs.ID == id.Text);
            refResultEntry.RemoveAt(found);
            refResultEntry.Add(new ResultField { ID = id.Text, Name = name.Text, ExamDate = examDate.Text.ToString(), QuizeNumber = quizeNumber.Text, Mark = int.Parse(totalMark.Text) });
            clear();
            id.Focus();
            update.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int found = refResultEntry.FindIndex(rs => rs.ID == id.Text);
            refResultEntry.RemoveAt(found);
            clear();
            id.Focus();
        }

        private void count_Click(object sender, RoutedEventArgs e)
        {
            viewResult vr = new viewResult(ref refResultEntry);
            vr.Show();
            
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            clear();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            id.Focus();
        }
    }
        #endregion
}
