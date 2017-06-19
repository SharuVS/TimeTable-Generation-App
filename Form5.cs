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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();
                DataSet ds = new DataSet();
                string str1 = "select * from TT";
                SqlDataAdapter sqlad = new SqlDataAdapter(str1, connection);
                sqlad.Fill(ds);
                connection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDialog1.ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            int ct1 = command.ExecuteNonQuery();
            int ct2 = command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("delete from TT1", conn);
            SqlCommand command3 = new SqlCommand("delete from examTT", conn);
            int ct3 = command2.ExecuteNonQuery();
            int ct4 = command3.ExecuteNonQuery();
            //MessageBox.Show(ct2 + " Rows deleted");
            //MessageBox.Show(ct1 + " Rows deleted");
            conn.Close();
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            Form8 f = new Form8();
            f.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
       

        
    }
}
