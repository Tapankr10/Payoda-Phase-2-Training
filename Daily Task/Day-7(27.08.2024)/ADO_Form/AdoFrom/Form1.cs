using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace AdoFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

          
             con.Open();
             Console.WriteLine("Enter the product id  :");
             int  id = Convert.ToInt32(textid.Text);
             

                Console.WriteLine("Enter the product Name  :");
                string name = textname.Text;

                Console.WriteLine("Enter the product price :");
                int price = Convert.ToInt32(textproduct.Text);
                string s = "insert into Product1 values(@ProId,@ProName,@Price)";
                SqlCommand ins = new SqlCommand(s, con);
                ins.Parameters.AddWithValue("@ProId", id);
                ins.Parameters.AddWithValue("@ProName", name);
                ins.Parameters.AddWithValue("@Price", price);

                ins.ExecuteNonQuery();
                MessageBox.Show("Inserted Sucessfully");
                con.Close();



        }

        private void Display_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            
                 con.Open();
                 string s1 = "select * from Product1";
                 SqlCommand cmd = new SqlCommand(s1, con);
                 SqlDataReader sdr = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(sdr);
                 dataGridView1.DataSource = dt;
                 con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            
                 con.Open();
                 string s1 = "select * from Product1";
                 SqlCommand cmd = new SqlCommand(s1, con);
                 SqlDataReader sdr = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(sdr);
                 dataGridView1.DataSource = dt;
                 con.Close();

        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();
            int id = Convert.ToInt32(textid.Text);
            string s1 = "select * from Product1 where ProId=@id";
            SqlCommand cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
           // DataTable dt = new DataTable();
          //  dt.Load(sdr);
          //  dataGridView1.DataSource = dt;
            while (sdr.Read())
            {

                textid.Text = sdr[0].ToString();
                textname.Text = sdr[1].ToString();
                textproduct.Text = sdr[2].ToString();


            }

            con.Close();
        }

        private void TotalProducts_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();

            string s1 = "select  count(ProId) as TotalCount  from Product1 ";
            SqlCommand cmd = new SqlCommand(s1, con);
         
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(sdr);
             dataGridView1.DataSource = dt;
             con.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();
            int id = Convert.ToInt32(textid.Text);
             
            string s1 = "delete from Product1 where ProId= @id";
           

            SqlCommand cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted Sucessfully");


        }
    }
}
