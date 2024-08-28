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
    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
        }
        public void LoadSchedules()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Schedules", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                reader.Close();
                con.Close();
            }
            //con.Open();
            //string query = "SELECT * FROM Schedules";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader sdr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(sdr);
            //dataGridView1.DataSource = dt;
            //con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            SqlCommand cmd = new SqlCommand("DELETE FROM Schedules WHERE ScheduleID = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ScheduleID.Text)); // Assuming `ScheduleID` is a TextBox for Schedule ID

            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Delete Failed. Please check the Schedule ID.");
            }
            LoadSchedules();

        }

        private void Add_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
             SqlCommand cmd = new SqlCommand("INSERT INTO Schedules (EventID, ScheduleDate, StartTime, EndTime, Activity) VALUES (@eventID, @scheduleDate, @startTime, @endTime, @activity)", con);

             cmd.Parameters.AddWithValue("@eventID", Eventid.Text);
             cmd.Parameters.AddWithValue("@scheduleDate", dtpScheduleDate.Value);
             cmd.Parameters.AddWithValue("@startTime", Starttime.Value.TimeOfDay);
             cmd.Parameters.AddWithValue("@endTime", Endtime.Value.TimeOfDay);
             cmd.Parameters.AddWithValue("@activity", textActivity.Text);

             con.Open();
             cmd.ExecuteNonQuery();
             con.Close();

             MessageBox.Show("Added Successfully");
             LoadSchedules();


        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            SqlCommand cmd = new SqlCommand("UPDATE Schedules SET EventID=@eventID, ScheduleDate=@scheduleDate, StartTime=@startTime, EndTime=@endTime, Activity=@activity WHERE ScheduleID=@id", con);

            cmd.Parameters.AddWithValue("@eventID", Eventid.Text);
            cmd.Parameters.AddWithValue("@scheduleDate", dtpScheduleDate.Value);
            cmd.Parameters.AddWithValue("@startTime", Starttime.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@endTime", Endtime.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("@activity", textActivity.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ScheduleID.Text)); // Assuming `ScheduleID` is a TextBox for Schedule ID

            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Updated Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed. Please check the Schedule ID.");
            }
            LoadSchedules();

        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            SqlCommand cmd = new SqlCommand("SELECT EventID, ScheduleDate, StartTime, EndTime, Activity FROM Schedules WHERE ScheduleID = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ScheduleID.Text)); // Assuming `ScheduleID` is a TextBox for Schedule ID

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Eventid.Text = reader["EventID"].ToString(); ;
                dtpScheduleDate.Value = Convert.ToDateTime(reader["ScheduleDate"]);
                Starttime.Value = DateTime.Today + (TimeSpan)reader["StartTime"];
                Endtime.Value = DateTime.Today + (TimeSpan)reader["EndTime"];
                textActivity.Text = reader["Activity"].ToString();

                MessageBox.Show("Record Found");
            }
            else
            {
                MessageBox.Show("No record found with the given Schedule ID.");
            }

            reader.Close();
            con.Close();
            LoadSchedules();

        }

        private void Schedules_Load(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void ScheduleID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
