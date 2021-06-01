using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace kursov_proekt_tsp6sem
{
    public partial class Main : Form
    {
       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dobsh\Downloads\kursov_proekt-usp (1)\kursov proekt-tsp6sem\data7.mdf;Integrated Security=True;Connect Timeout=30");

        private object dt;
        private object cmd;

        public object db { get; private set; }
        public Form Login_Platfotm { get; private set; }


        //DataTable table = new DataTable("table");

        public Main()
        {
            
            InitializeComponent();
            

            label28.Text = Login_Platform.passingText;
            
        }
        String username;
        public Main(String s)
        {

            InitializeComponent();
            username = s;
          

        }



        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void Main_Load_1(object sender, EventArgs e)
        {
            display_data();
            if (username == "dobsho99")
            {
                button1.Hide();
                button2.Hide();
                button3.Hide();
            }
            label2.Text = DateTime.Now.ToString();
            
           



            label28.Text = Login_Platform.passingText;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //var image = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
            //cmd.Parameters.AddWithValue("image", image);
            //cmd.CommandText = "INSERT INTO TABLE (image) VALUES(@images)";
            // if (cmd.ExecuteNonQuery() > 0)

            //     MessageBox.Show("Image was added!");
            //  else
            //  MessageBox.Show("Image was not added");





            cmd.CommandText = "insert into [table] values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Данните са записани");
        }//Is correct


        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [table]";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            label19.Text = dt.Rows.Count.ToString();
            
            
            
        }//Is correct






        /*SqlCommand con = new SqlCommand("SELECT * FROM [TABLEK] WHERE id = @id", connection);
        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier);

        //cmd.ExecuteNonQuery();
        SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
        DataTable danni = new DataTable();
        DataSet ds = new DataSet();
        dataadp.Fill(ds);
        dataGridView1.DataSource = ds.Tables["Table"].DefaultView;

        connection.Close();*/


        private void button5_Click(object sender, EventArgs e)
        {
            display_data(); //Display на базата данни
        }





        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update [table] set Marka='" + textBox2.Text + "',Model='" + textBox3.Text + "',Kamera='" + textBox4.Text + "',Cena='" + textBox5.Text + "'  where Id ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();

            {
                MessageBox.Show("Данните са редактирани успешно");
            }//Is Correct
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from [table] where Id = '" + textBox1.Text + "'";

            cmd.ExecuteNonQuery();
            con.Close();
            display_data();

            MessageBox.Show("Данните са изтрити успешно");
        }//Is correct










        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }//Is Correct

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [table] where Marka ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да излезете от програмата", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                Login_Platform objFrmMain = new Login_Platform();
                this.Hide();
                objFrmMain.Show();
            }

            else if (dialogResult == DialogResult.No)

            {
                Main objFrmMain = new Main();
                this.Hide();
                objFrmMain.Show();
            }
        }

        private void Изчисти_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При въвеждане на данни в базата данни моля" +
                "щраквайте върху избраният от вас ред, в който програмата ще изобрази редовете" +
                "и след това с възможността, което дава приложението вие можете да изберете дали да вмъкнете" +
                "някаква информация по зададените полета, съответно с бутона Insert или пък да Подобрите някои данни " +
                "с бутона Update, а също така програмата предлага и да изтривате определени данни както директно се свързва с базата и премахва" +
                "реда, който изтрива цялостната информация. Бутона Search спомага за откриването по всяко едно текстово поле" +
                "вмъкнато вътре в базата данни след което позволява визуализирането отново ", "Внимание");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {//Kachvane na snimki v bazata
            OpenFileDialog open = new OpenFileDialog();
            PictureBox b = sender as PictureBox;
            if (b != null)
            {
                open.Filter = "(*.jpg;*.jpeg;,bmp)|*.jpg;*.jpeg;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    b.Image = Image.FromFile(open.FileName);
                }
            }
        }
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
        using (MemoryStream ms=new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported images|*jpg;*.jpeg;*.png";
            if(OD.ShowDialog()=DialogResult.OK)
            {

            }*/
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [table] where Model ='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [table] where Kamera ='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Marka  Like '%" + textBox2.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Model  Like '%" + textBox3.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Kamera  Like '%" + textBox4.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Cena  Like '%" + textBox5.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
             String phone = textBox2.Text.ToString();

            //String a = listBox1.Text.ToString();

            //a=textBox2.Text.ToString()

            //listBox1.Items.Add(textBox2.Text);
            //listBox1.Items.Add(textBox3.Text);
            int txt5 = Convert.ToInt32(textBox5.Text);
            int txt6 = Convert.ToInt32(textBox6.Text);
            //int res = Convert.ToInt32(textBox7.Text);



            if(txt6>txt5)
            {
                textBox7.Text = (txt6 - txt5).ToString();
                listBox1.Items.Add(textBox2.Text);
                MessageBox.Show("Izbraniat ot vas telefon shte bude pribaven v kolichkata", "Внимание", MessageBoxButtons.YesNo);
            }

            

            if(txt6 < txt5)
            {
                MessageBox.Show("Недостатъчна наличност в сметката","Внимавай");
            }
            //res = Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox5.Text);
           
           // textBox7.Text = res.ToString();

         
        }

        private void label19_Click(object sender, EventArgs e)
        {
           
        }

        private void label21_Click(object sender, EventArgs e)
        {
          
        }

        private void label24_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }




        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
        }
    }
}




