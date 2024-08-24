using System.Xml;
namespace DetailXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            students[0] = new Student(101, "Alice Johnson", "Computer Science");
            students[1] = new Student(102, "Bob Smith", "Mechanical Engineering");
            students[2] = new Student(103, "Charlie Brown", "Electrical Engineering");
            students[3] = new Student(104, "Tapan", "Infromation Technology");
            students[4] = new Student(105, "Ravi", "Instrumentattion Engineering");

            using (XmlWriter writer = XmlWriter.Create("Students.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Students");

                foreach (Student student in students)
                {
                    writer.WriteStartElement("Student");

                    writer.WriteElementString("StudentID", student.Sid.ToString());
                    writer.WriteElementString("StudentName", student.Sname);
                    writer.WriteElementString("StudentDepartment", student.Sdepartment);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}