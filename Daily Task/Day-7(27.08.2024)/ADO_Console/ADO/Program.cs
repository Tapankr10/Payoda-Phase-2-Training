using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOapp
{
    class Program
    {
        static void Main(string[] args)
        {
       
         //  Insert();

            string choice;

            do{

                 Console.WriteLine("Choices ");
            Console.WriteLine("1.Create ");
            Console.WriteLine(" 2.Fetch ");
            Console.WriteLine(" 3. Insert ");
            Console.WriteLine(" 4. Update ");
            Console.WriteLine(" 5. Delete ");

            Console.WriteLine("Enter your Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());


                switch(ch)
                {
                    case 1: create();
                             break;
                    case 2: Fetch();
                             break;
                    case 3: Insert();
                             break;
                    case 4: update();
                             break;
                    case 5:  delete();
                             break;

                   default: Console.WriteLine("Enter the correct choice");
                             break;



                }
                Console.WriteLine("Do you  want to continue(yes/no)");
             choice = Console.ReadLine();

            }while(choice.Equals("yes"));


          



           Console.ReadKey();


         }

        static void create()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();


            SqlCommand cmd = new SqlCommand("create table Product1(ProId int primary key,ProName varchar(20),Price int)", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully");


            Console.ReadKey();
            con.Close();
            Insert();


        }
        static void Insert()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

           
            Console.WriteLine("Enter the number of records wanted to be inserted:");
            int no = Convert.ToInt32(Console.ReadLine());

            int[] id = new int[no];
            string[] name = new string[no];
            int[] price = new int[no];


            for (int i = 0; i < no; i++)
            {
                Console.WriteLine("Enter the product id "+ (i+1) +" :");
                id[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the product Name " + (i + 1) + " :");
                name[i] = Console.ReadLine();

                Console.WriteLine("Enter the product price" + (i + 1) + " :");
                 price[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < no; i++)
            {
                con.Open();
                string s = "insert into Product1 values(@ProId,@ProName,@Price)";
                SqlCommand ins = new SqlCommand(s, con);
                ins.Parameters.AddWithValue("@ProId", id[i]);
                ins.Parameters.AddWithValue("@ProName", name[i]);
                ins.Parameters.AddWithValue("@Price", price[i]);

                ins.ExecuteNonQuery();
                Console.WriteLine("Inserted  successfully");
                con.Close();
            }
            Console.ReadKey();
        }
        static void Fetch()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();
            string s1 = "select * from Product1";
            SqlCommand sel = new SqlCommand(s1, con);
            SqlDataReader sdr = sel.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine(sdr[0].ToString() + "  " + sdr[1].ToString() + "  " + sdr[2].ToString());
            }
            con.Close();
            Console.ReadKey();
        }
        static void update()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            Console.WriteLine("Enter the product id  needed to be update :");
           int  id = Convert.ToInt32(Console.ReadLine());

         

            Console.WriteLine("Enter the product price needed to be update :" );
           int  price = Convert.ToInt32(Console.ReadLine());
           con.Open();
           string s = "update  Product1 set  Price =@price where ProId=@id";
           SqlCommand ins = new SqlCommand(s, con);
           ins.Parameters.AddWithValue("@id", id);
         
           ins.Parameters.AddWithValue("@Price", price);

           ins.ExecuteNonQuery();
           Console.WriteLine("Inserted  successfully");

           con.Close();


        }
        static void delete()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            Console.WriteLine("Enter the product id  needed to be deleted :");
            int id = Convert.ToInt32(Console.ReadLine());


      
            con.Open();
            string s = "delete from  Product1 where ProId=@id  ";
            SqlCommand ins = new SqlCommand(s, con);
            ins.Parameters.AddWithValue("@id", id);

          

            ins.ExecuteNonQuery();
            Console.WriteLine("Inserted  successfully");

           
            con.Close();

        }

    }
}
