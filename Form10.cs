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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();
            DataSet ds = new DataSet();
            string str1 = "select * from examTT";
            SqlDataAdapter sqlad = new SqlDataAdapter(str1, connection);
            sqlad.Fill(ds);
            connection.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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
            //MessageBox.Show(ct2 + " Rows deleted");
            //MessageBox.Show(ct1 + " Rows deleted");
            conn.Close();
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
