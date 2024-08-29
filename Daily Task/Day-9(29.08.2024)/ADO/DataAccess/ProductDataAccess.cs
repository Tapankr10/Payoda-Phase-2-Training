using ADO.Models;
using Humanizer;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Net;

namespace ADO.DataAccess
{
    public class ProductDataAccess
    {

        static void create()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");

            con.Open();


            SqlCommand cmd = new SqlCommand("create table Product1(ProId int primary key,ProName varchar(20),Price int)", con);
            cmd.ExecuteNonQuery();



            Console.ReadKey();
            con.Close();
          


        }

        public static Product Insert(Product prod)
        {

            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;TrustServerCertificate=true;");
            con.Open();
            SqlCommand  cmd = new SqlCommand("insert into Product1 values(@id,@name,@price)", con);
            cmd.Parameters.AddWithValue("@id", prod.ProID);
            cmd.Parameters.AddWithValue("@name", prod.ProName);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.ExecuteNonQuery();
            con.Close();
            return prod;
        }
        public List<Product> Fetch()
        {
            List<Product> listproduct = new List<Product>();

            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;TrustServerCertificate=true;");

            con.Open();
            string s1 = "select * from Product1";
            SqlCommand sel = new SqlCommand(s1, con);
            // sel.ExecuteNonQuery();
            SqlDataReader sdr = sel.ExecuteReader();
            while (sdr.Read())
            {
                // Console.WriteLine(sdr[0].ToString() + "  " + sdr[1].ToString() + "  " + sdr[2].ToString());
                listproduct.Add(new Product() { ProID = Convert.ToInt32(sdr[0]), ProName = sdr[1].ToString(), Price = Convert.ToInt32(sdr[2]) });
            }
            con.Close();
            // Console.ReadKey();

            return listproduct;
        }
        static void update()
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            Console.WriteLine("Enter the product id  needed to be update :");
            int id = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("Enter the product price needed to be update :");
            int price = Convert.ToInt32(Console.ReadLine());
            con.Open();
            string s = "update  Product1 set  Price =@price where ProId=@id";
            SqlCommand ins = new SqlCommand(s, con);
            ins.Parameters.AddWithValue("@id", id);

            ins.Parameters.AddWithValue("@Price", price);

            ins.ExecuteNonQuery();
            Console.WriteLine("Inserted  successfully");

            con.Close();


        }
        public Product Search(int id)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;TrustServerCertificate=true;");

            Product prod = new Product();


            con.Open();
            string s = "Select * from  Product1 where ProId=" + id;
            SqlCommand ins = new SqlCommand(s, con);


            SqlDataReader sdr = ins.ExecuteReader();
            while (sdr.Read())
            {
                prod.ProID = Convert.ToInt32(sdr[0]);
                prod.ProName = sdr[1].ToString();
                prod.Price = Convert.ToInt32(sdr[2]);


            }


            // ins.Parameters.AddWithValue("@id", id);
            con.Close();
            return prod;

        }
        public void delete(int id, Product p)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=SPORTS_Tapan;integrated security=true;");
            // Console.WriteLine("Enter the product id  needed to be deleted :");
            // int id = Convert.ToInt32(Console.ReadLine

            con.Open();
            string s = "delete from Product1 where ProId=@id";
            SqlCommand ins = new SqlCommand(s, con);
            ins.Parameters.AddWithValue("@id", id);



            int val = ins.ExecuteNonQuery();
            Console.WriteLine(val);
            //Console.WriteLine("Inserted  successfully");


            con.Close();
            //return id;

        }

    }
}

