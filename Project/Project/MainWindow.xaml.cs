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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fieldes;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
         public List<Field> student = new List<Field>();

         public List<ResultField> ResultEntry = new List<ResultField>();
         public MainWindow()
         {
             InitializeComponent();
         }
        
        void clear()
        {
            id.Text = "";
            name.Text = "";
            email.Text = "";
            phoneNo.Text = "";
        }

        #region MainWindow Buttons
        private void Insert(object sender, RoutedEventArgs e)
        {
            Field fields = student.Find(s => s.ID == id.Text);
            if (fields.ID == id.Text)
            {
                showStatus.Text = "This ID Has Beeen Saved. You Can not Save This";
                clear();
            }
            else
            {
                student.Add(new Field { ID = id.Text, Name = name.Text, Email = email.Text, PhoneNo = phoneNo.Text });
                clear();
                showStatus.Text = "Data Has been saved";
            }
            id.Focus();
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            Field fields = student.Find(s => s.ID == id.Text);
            id.Text = fields.ID;
            name.Text = fields.Name;
            email.Text = fields.Email;
            phoneNo.Text = fields.PhoneNo;
            showStatus.Text = "ID  Found";
            //MessageBox.Show("ID :" + fields.ID + "Name : " + fields.Name + "Email :" + fields.Email + "Phone No :" + fields.PhoneNo);

            
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            int found = student.FindIndex(c => c.ID == id.Text);
            student.RemoveAt(found);
            student.Add(new Field { ID = id.Text, Name = name.Text, Email = email.Text, PhoneNo = phoneNo.Text });
            clear();
            showStatus.Text = "Data Has been updated";
            id.Focus();

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var found = student.FindIndex(s => s.ID == id.Text);
            student.RemoveAt(found);
            clear();
            showStatus.Text = "Data Has been deleted successfully";
        }

        private void TotalEntry_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( "Total Entry :  " + student.Count());
        }

        private void MarkEntry(object sender, RoutedEventArgs e)
        {
            Result r = new Result(ref student, ref ResultEntry);
            r.Show();
            

        }
        private void studentClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void ___No_Name__Loaded(object sender, RoutedEventArgs e)
        {
            id.Focus();
        }

        private void searchID_Click(object sender, RoutedEventArgs e)
        {
            viewResult vr = new viewResult(ref ResultEntry);
            vr.Show();
        }

        private void showStudent_Click(object sender, RoutedEventArgs e)
        {
            ShowStudent ss = new ShowStudent(ref student);
            ss.Show();
        }

        #endregion 

    }
}
