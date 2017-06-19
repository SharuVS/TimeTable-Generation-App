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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

      
      
        int flag = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) > 8)
            {
                MessageBox.Show("Number of hours cannot be beyond 8. Please re-enter! ");
            }
            
            if (textBox4.Text.Length != 0 && textBox5.Text.Length != 0)
            {
                if (flag == Convert.ToInt32(textBox3.Text))
                {
                    MessageBox.Show("No more subject hours per week can be added");
                    return;

                }
                string sub_name = textBox4.Text.ToString();
                int howee = Convert.ToInt32(textBox5.Text);

                string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                SqlConnection connection = new SqlConnection(str);
                connection.Open();
                //"insert into subject" + "(hrs_week)" + " values('" + s + " ')"
                SqlCommand command1 = new SqlCommand("insert into Subject values('" + sub_name + "' , '" + howee + "')", connection);
                int ct = command1.ExecuteNonQuery();
                //MessageBox.Show(ct + "Subject Added");
                flag++;
                if (flag == Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Subjects added successfully...Continue with done!!");
                }
                else
                {
                    MessageBox.Show(ct + "Subject Added...Add next");
                }
               textBox4.Clear();
                textBox5.Clear(); 
                connection.Close();

            }
            else
            {
                MessageBox.Show("Enter values first");
            }
               
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);//no of wrkng days
            int s2 = Convert.ToInt32(textBox2.Text);//no of wrkng hrs per day
            int s3 = s1 * s2;
            string str = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string query = "select * from subject";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string [] hrs_week = new string[10];
            string[] subject = new string[25];
            int i = 0;
            int sum = 0;
            while (dr.Read())
            {
                subject[i] = dr[0].ToString();
                hrs_week[i] = dr[1].ToString();
                sum = sum + Convert.ToInt32(hrs_week[i]);
                i++;
            }
            
            MessageBox.Show(sum.ToString());
            if (s3.CompareTo(sum) != 0)
            {
                MessageBox.Show(" Time table cannot be generated.... try again...!!");
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
            else
            {
                int j, a = 0, b = 0;
                string[] sub = new string[i];
                int[] hw = new int[i];

                for (j = 0; j < i; j++)
                {
                    sub[j] = subject[j];
                    hw[j] = Convert.ToInt32(hrs_week[j]);
                   // MessageBox.Show("for okay");
                }


                string[,] tt = new string[6, 8];
                for (a = 0; a < 6; a++)
                {
                    for (b = 0; b < 8; b++)
                    {
                        tt[a, b] = null;

                    }
                } 
                int no_of_sub = Convert.ToInt32(textBox3.Text);
                int no_of_days = s1;
                int k;
                
                a = 0;
                b = 0;
                for (k = 0; k < no_of_sub; k++)
                {
                    while (hw[k] != 0)
                    {
                        //MessageBox.Show("inside while " + (k + 1));
                        if (a == no_of_days)
                        {
                            a = 0;
                            b++;

                        }
                        else
                        {

                            tt[a, b] = sub[k];
                            hw[k]--;
                            a++;
                        }
                    }
                   // MessageBox.Show("one subject complete...");
                }

               /* for (a = 0; a < no_of_days; a++)
                {
                    for (b = 0; b < no_of_sub; b++)
                    {
                        MessageBox.Show(tt[a, b]);
                    }
                }*/
                for(i=0;i<no_of_days;i++)
                {
                    
                    SqlConnection connection = new SqlConnection(str);
                    connection.Open();
                    string str1 = "insert into TT values('"+tt[i,0]+"','"+tt[i,1]+"','"+tt[i,2]+"','"+tt[i,3]+"','"+tt[i,4]+"','"+tt[i,5]+"','"+tt[i,6]+"','"+tt[i,7]+" ')";
                   
                    SqlCommand cmd1  = new SqlCommand(str1 , connection);
                    int ct = cmd1.ExecuteNonQuery();
                    //MessageBox.Show(ct + " rows inserted"); 
                    
                }

                // for alternate tt
                string s = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\hp\\Documents\\TimeTableApp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                SqlConnection connection1 = new SqlConnection(s);
                connection1.Open();
                string query1 = "select * from subject";
                SqlCommand c = new SqlCommand(query1, connection1);
                SqlDataReader dr1 = c.ExecuteReader();
                string[] hrs_week1 = new string[10];
                string[] subject1 = new string[25];
                int i1 = 0;
                int sum1 = 0;
                while (dr1.Read())
                {
                    subject1[i1] = dr1[0].ToString();
                    hrs_week1[i1] = dr1[1].ToString();
                    sum1 = sum1 + Convert.ToInt32(hrs_week1[i1]);
                    i1++;
                }

                a = 0; b = 0;
                int x;
                string[] sub1 = new string[i1];
                int[] hw1 = new int[i1];

                for (x=0,j = i1 - 1; j >= 0; j--,x++)
                {
                    sub1[x] = subject1[j];
                    hw1[x] = Convert.ToInt32(hrs_week1[j]);
                    // MessageBox.Show("for okay");
                }



                for (a = 0; a < 6; a++)
                {
                    for (b = 0; b < 8; b++)
                    {
                        tt[a, b] = null;

                    }
                } //MessageBox.Show("tt declared with null");

                //MessageBox.Show("assigning subjects");
                a = 0;
                b = 0;
                for (k = 0; k < no_of_sub; k++)
                {
                    while (hw1[k] != 0)
                    {
                        // MessageBox.Show("inside while " + (k + 1));
                        if (a == no_of_days)
                        {
                            a = 0;
                            b++;

                        }
                        else
                        {

                            tt[a, b] = sub1[k];
                            hw1[k]--;
                            a++;
                        }
                    }
                    // MessageBox.Show("one subject complete...");
                }
                for (i = 0; i < no_of_days; i++)
                {

                    SqlConnection connection = new SqlConnection(str);
                    connection.Open();

                    string str2 = "insert into TT1 values('" + tt[i, 0] + "','" + tt[i, 1] + "','" + tt[i, 2] + "','" + tt[i, 3] + "','" + tt[i, 4] + "','" + tt[i, 5] + "','" + tt[i, 6] + "','" + tt[i, 7] + " ')";
                    SqlCommand cmd1 = new SqlCommand(str2, connection);
                    int ct = cmd1.ExecuteNonQuery();
                    //MessageBox.Show(ct + " rows inserted");
                   
                }

                Form5 frm = new Form5();
                frm.Show();
                this.Close();

                
                

            }//end of else;
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

        private void Form4_Load(object sender, EventArgs e)
        {
            
            MessageBox.Show("Make sure that individual subject hours sum to product of working hrs per day and no of working days. ","Important",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}