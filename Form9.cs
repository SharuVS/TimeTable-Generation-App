using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimeTableApp
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            
            if (textBox2.Text.Length != 0 )
            {
                if (flag == Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("No more subjects can be added");
                    return;

                }

                string sub = textBox1.Text.ToString();
                DateTime date = dateTimePicker1.Value.Date;
                DateTime selectedDate = Convert.ToDateTime(dateTimePicker1.Value);
                DateTime todayDate = Convert.ToDateTime(DateTime.Now);
                //MessageBox.Show("dsjgsdjgfjfgfghffgfgf");
                if (selectedDate < todayDate)
                {
                    MessageBox.Show("Selected date Must be greater then Today's date");
                    return;
                }
                string date1 = dateTimePicker1.Value.ToString();
                //DateTime dateinsert = Convert.ToDateTime(date1);
                String str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                //MessageBox.Show("dhgfkdghf");
                SqlConnection connection = new SqlConnection(str);
                connection.Open();
                //String query = "insert into subject values('" +sub + "' , ";
                SqlCommand command1 = new SqlCommand("insert into examTT values('"+dateTimePicker1.Value.Date+"','" +sub +"')",connection);
                flag++;
                int ct = command1.ExecuteNonQuery();
                if (flag == Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("All Subjects added... continue with Done...");
                }
                else
                {
                    MessageBox.Show("Done...Add Next sub and date...");

                    textBox1.Clear();
                }
                connection.Close();

            }
            else
            {
                MessageBox.Show("Enter values first");
            }
               
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == Convert.ToInt32(textBox2.Text))
            {
                Form10 f = new Form10();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter all the subjects to continue....");
            }

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            //MessageBox.Show("gfjfdfhgfhng");
            string query = "delete from Subject ";
            SqlCommand command = new SqlCommand(query, conn);
            SqlCommand command1 = new SqlCommand("delete from TT", conn);

            SqlCommand command2 = new SqlCommand("delete from TT1", conn);
            SqlCommand command3 = new SqlCommand("delete from examTT", conn);
            int ct3 = command2.ExecuteNonQuery();
            int ct4 = command3.ExecuteNonQuery();
            int ct1 = command.ExecuteNonQuery();
            int ct2 = command1.ExecuteNonQuery();
            //MessageBox.Show(ct2 + " Rows deleted");
            //MessageBox.Show(ct1 + " Rows deleted");
            conn.Close();
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
