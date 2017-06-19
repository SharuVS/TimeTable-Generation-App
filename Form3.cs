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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("enter your first name");
            }
            else if (textBox3.Text.Length == 0)
                {
                       MessageBox.Show("enter your last name");
                }

            else if (textBox4.Text.Length != 5)
            {
                MessageBox.Show("enter your username(must contain 5 characters) ");
                //errorProvider4.SetError(textBox4, "enter your username(must contain 5 characters) ");
            }
            else if (textBox5.Text.Length != 5)
            {
                MessageBox.Show("enter your password(must contain 5 characters) ");
                // errorProvider5.SetError(textBox5, "enter your password(must contain 5 characters) ");

            }
            else if (string.Compare(textBox6.Text.ToString(), textBox5.Text.ToString()) != 0)
            {
                MessageBox.Show("The passwords do not match ");
                
            }

            


            else
            {
                //MessageBox.Show("gfjfdfhgfhng");

                string s1 = textBox1.Text.ToString();
                string s2 = textBox2.Text.ToString();
                string s3 = textBox3.Text.ToString();
                string s4 = textBox4.Text.ToString();
                string s5 = textBox5.Text.ToString();



                string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                //MessageBox.Show("gfjfdfhgfhng");
                
                string query = "insert into Login values(' " + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "')";

                SqlCommand command1 = new SqlCommand(query, conn);
                //MessageBox.Show("gfjfdfhgfhng");

                int ct = command1.ExecuteNonQuery();

               

                MessageBox.Show("User Created");

                
                Form1 form1 = new Form1();
                form1.Show();
                conn.Close();
                this.Close();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
