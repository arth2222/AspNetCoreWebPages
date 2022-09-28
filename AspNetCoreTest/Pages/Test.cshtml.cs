using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AspNetCoreTest.Pages
{
    public class TestModel : PageModel
    {
        public void OnGet()
        {
            

        }

        public static void OnPost()
        {
            Console.WriteLine("Hello");

        }

        public static DataTable GetData()
        {
            DataTable dt = new DataTable();
            string connectionString = "Server=glemmen.bergersen.dk,4729;Database=Ask;User ID=skole;Password=skole2022";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from personer", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                //while (reader.Read())
                //{
                //    values[0] = (int)reader["PM10"];
                //    values[1] = (int)reader["PM25"];
                //}
                reader.Close();
                conn.Close();
            }
            return dt;
        }
    }
}
