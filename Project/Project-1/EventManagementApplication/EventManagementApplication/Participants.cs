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
    public partial class Participants : Form
    {
        public Participants()
        {
            InitializeComponent();
        }
          private void LoadParticipants()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();
            string query = "SELECT * FROM Participants";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private int GetEventId(string Eventname)
        {
            SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select EventID from Events where EventName=@Eventname", conn);
            int eid =(int) cmd.ExecuteScalar();
            conn.Close();
            return eid;

        }

        private void Add_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
                
                    conn.Open();

                   if (Eventid.SelectedValue == null)
                    {
                        MessageBox.Show("Please select a valid event from the list.");
                        return;
                   }
                   // string eventname = Eventid.Text;

                   // int id = GetEventId(eventname); // Correctly fetch the selected value
                  //  if (Eventid.SelectedIndex == -1)
                  //  {
                   //     MessageBox.Show("Please select an event.");
                   //     return;
                   // }

                    int id = Convert.ToInt32(Eventid.SelectedValue);

                    SqlCommand cmd = new SqlCommand("INSERT INTO Participants (EventID, ParticipantName, Email, ContactNumber) VALUES (@eventID, @name, @Email, @ContactNumber)", conn);
                    cmd.Parameters.AddWithValue("@eventID", id);
                    cmd.Parameters.AddWithValue("@name", parname.Text);
                    cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", textcn.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Inserted Successfully");
                    conn.Close();
                

                LoadParticipants();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
      

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Participants SET ParticipantName = @name, Email = @Email, ContactNumber = @ContactNumber WHERE ParticipantID = @id", conn);
            cmd.Parameters.AddWithValue("@id", textId.Text); // Assuming you have a TextBox for Participant ID
            cmd.Parameters.AddWithValue("@name", parname.Text);
            cmd.Parameters.AddWithValue("@Email", textEmail.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", textcn.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Updated Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed. Please check the Participant ID.");
            }

            conn.Close();
            LoadParticipants();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Participants WHERE ParticipantID = @id", conn);
            cmd.Parameters.AddWithValue("@id", textId.Text); // Assuming you have a TextBox for Participant ID

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Delete Failed. Please check the Participant ID.");
            }

            conn.Close();
            LoadParticipants();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT ParticipantName, Email, ContactNumber FROM Participants WHERE ParticipantID = @id", conn);
            cmd.Parameters.AddWithValue("@id", textId.Text); // Assuming you have a TextBox for Participant ID

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                parname.Text = reader["ParticipantName"].ToString();
                textEmail.Text = reader["Email"].ToString();
                textcn.Text = reader["ContactNumber"].ToString();

                MessageBox.Show("Record Found");
            }
            else
            {
                MessageBox.Show("No record found with the given Participant ID.");
            }

            reader.Close();
            conn.Close();
        }

        private void Participants_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            con.Open();
            string query = "SELECT * FROM Participants";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
            LoadEventsIntoComboBox();

            Eventid.DisplayMember = "EventName";
            Eventid.ValueMember = "EventID";


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void Eventid_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            SqlCommand cmd = new SqlCommand("SELECT EventID, EventName FROM Events", con);
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Eventid.DataSource = dt;
                Eventid.DisplayMember = "EventName";
                Eventid.ValueMember = "EventID";

                reader.Close();
                con.Close();
            }
        }
        public  void LoadEventsIntoComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
                
                    string query = "SELECT EventID, EventName FROM Events";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    Application.DoEvents();
                    dt.Load(reader);

                    Eventid.DataSource = dt;
                    Eventid.DisplayMember = "EventName";
                    Eventid.ValueMember = "EventID";

                   
                    reader.Close();
                    Eventid.SelectedIndex = 1; 

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
        }
    }
}
