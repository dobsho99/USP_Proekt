using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kursov_proekt_tsp6sem
{
    public partial class Login_Platform : Form
    {
        public static string passingText;
        public Login_Platform()
        {
            InitializeComponent();
            //textBox1.Text = value;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            passingText = textBox1.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dobsh\Downloads\kursov_proekt-usp (1)\kursov proekt-tsp6sem\data.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select  * from [Table] Where username='" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);



            // if (dt.Rows.Count == 1)
            //{

            if (textBox1.Text == "dani" && textBox2.Text == "9904")
            {

                Main objFrmMain = new Main(textBox1.Text);
                this.Hide();
                objFrmMain.Show();
            }



            else if (textBox1.Text == "dobsho99" && textBox2.Text == "9982")
            {
                Main objFrmMain = new Main(textBox1.Text);
                this.Hide();
                objFrmMain.Show();
            }


            else

            {
                MessageBox.Show("Грешно име или парола");
            }
        }

              private void Login_Platform_Load(object sender, EventArgs e)
            {
                 //textBox1.Text = value;
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_Show_Hide.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {

                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void checkBox1_Show_Hide_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1_Show_Hide.Checked)
            {
                textBox2.UseSystemPasswordChar = true;

            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

