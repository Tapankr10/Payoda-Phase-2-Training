using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Detailform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlReader xmlread = XmlReader.Create(@"file:///C:/Users/tapan.k/Source/Repos/DetailXml/DetailXml/bin/Debug/net8.0/Students.xml");
            while (xmlread.Read())
            {
                switch (xmlread.NodeType)
                {
                    case XmlNodeType.Element:
                        listBox1.Items.Add(" < " + xmlread.Name + ">");
                        break;
                    case XmlNodeType.Text:
                        listBox1.Items.Add(xmlread.Value);
                        break;
                    case XmlNodeType.EndElement:
                        listBox1.Items.Add("</Course>");
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"file:///C:/Users/tapan.k/Source/Repos/DetailXml/DetailXml/bin/Debug/net8.0/Students.xml");
            //linq query
            var students = from student in doc.Descendants("Student")
                           where student.Element("StudentDepartment").Value == "Computer Science"
                           select student;

            // Displaying the student details in the listBox2
            foreach (var student in students)
            {
                listBox2.Items.Add("StudentID: " + student.Element("StudentID").Value);
                listBox2.Items.Add("StudentName: " + student.Element("StudentName").Value);
            }
        }
    }
}
