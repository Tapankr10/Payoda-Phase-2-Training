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

namespace EventManagementApplication
{
    public partial class Event : Form
    {
        public Event()
        {
            InitializeComponent();
        }
        private void LoadEvents()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();
            string query = "SELECT * FROM Events";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void Event_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();
            string s1 = "select * from  Events";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
                 SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
          
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Events SET EventName = @name, EventDate = @date, Location = @location, Description = @description WHERE EventID = @id", con);
                cmd.Parameters.AddWithValue("@id", textID.Text);
                cmd.Parameters.AddWithValue("@name", textName.Text);
                cmd.Parameters.AddWithValue("@date", Eventdate.Value);
                cmd.Parameters.AddWithValue("@location", textLocation.Text);
                cmd.Parameters.AddWithValue("@description", textDescript.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed. Please check the Event ID.");
                }

                con.Close();
                LoadEvents();
            

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Events WHERE EventID = @id", con);
            cmd.Parameters.AddWithValue("@id", textID.Text); // Assuming you have a TextBox for the Event ID

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Delete Failed. Please check the Event ID.");
            }

            con.Close();
            LoadEvents();

        }

        private void Add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();


            SqlCommand cmd = new SqlCommand("INSERT INTO Events (EventName, EventDate, Location, Description) VALUES (@name, @date, @location, @description)", con);
            cmd.Parameters.AddWithValue("@name", textName.Text);
            cmd.Parameters.AddWithValue("@date", Eventdate.Value);
            cmd.Parameters.AddWithValue("@location", textLocation.Text);
            cmd.Parameters.AddWithValue("@description", textDescript.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted Sucessfully");
            con.Close();
            LoadEvents();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT EventName, EventDate, Location, Description FROM Events WHERE EventID = @id", con);
            cmd.Parameters.AddWithValue("@id", textID.Text); // Assuming you have a TextBox for the Event ID

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                textName.Text = reader["EventName"].ToString();
                Eventdate.Value = Convert.ToDateTime(reader["EventDate"]);
                textLocation.Text = reader["Location"].ToString();
                textDescript.Text = reader["Description"].ToString();

                MessageBox.Show("Record Found");
            }
            else
            {
                MessageBox.Show("No record found with the given Event ID.");
            }

            reader.Close();
            con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();
    
            string query = "SELECT COUNT(*) as EventCount FROM Events";
            SqlCommand cmd = new SqlCommand(query, con);

          

            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;

            con.Close();
         //   MessageBox.Show($"Total Number of Events: {eventCount}")
    
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadEvents();

        }
    }
}
