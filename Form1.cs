using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;


namespace TimeTableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // As soon as the user presses login the earlier inputs are deleted.
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
            conn.Close();


            string text = textBox1.Text;
            bool hastext = false;
            foreach (char letter in text)
            {
                if (text != null)
                {
                    hastext = true;
                    break;
                }
            }
            if (!hastext)
            {
                MessageBox.Show("you must enter your username to proceed");
            }
          
            else
            {
                string text1 = textBox2.Text;
                bool hastext1 = false;
                foreach (char letter in text1)
                {
                    if (text1 != null)
                    {
                        hastext1 = true;
                        break;
                    }
                }

                if (!hastext1)
                {
                    MessageBox.Show("you must enter your password to proceed");
                }



                else
                {
                    string tempuser = textBox1.Text.ToString();

                    string temppass = textBox2.Text.ToString();

                    string s = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                    SqlConnection connection = new SqlConnection(s);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select username,password,firstname from Login", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    string[] user = new string[15];
                    string[] pass = new string[15];
                    string[] name = new string[15];
                    int i = 0;
                    while (dr.Read())
                    {
                        user[i] = dr[0].ToString();
                        pass[i] = dr[1].ToString();
                        name[i] = dr[2].ToString();
                        i++;
                    }
                    connection.Close();
                    int length = i;
                    if (i == 0)
                    {
                        MessageBox.Show("No users exist..Sign up first");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {

                        int flag = -1;

                        //MessageBox.Show((user[0].Length.ToString()) + (pass[0].Length.ToString())+tempuser.Length.ToString()+temppass.Length.ToString());
                        for (i = 0; i < length; i++)
                        {
                            //MessageBox.Show(user[i] + " " +name[i]+" " + tempuser + " " + pass[i] + " " + temppass);
                            if (((String.Compare(user[i], tempuser) == 0) && ((String.Compare(pass[i], temppass)) == 0)))
                            {
                                // MessageBox.Show(user[i] + " " + tempuser + " " + pass[i] + " " + temppass);


                                flag = 1;
                                Form11 frm = new Form11();
                                frm.Show();
                                break;
                                //MessageBox.Show("okay");

                            }



                            else
                            {
                                flag = 0;
                            }

                        }
                            if (flag == 0)
                            {
                                MessageBox.Show("Invalid User");
                            }
                            connection.Close();
                        }
                    }
                

            }
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form3 f = new Form3();
            f.Show();
            //this.Close();
            //MessageBox.Show("opened");
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

       
       
    }
}