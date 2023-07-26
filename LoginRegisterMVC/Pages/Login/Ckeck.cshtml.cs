using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace LoginRegisterMVC.Pages.Login
{
    public class CkeckModel : PageModel
    {
        public List<DataLR> listD = new List<DataLR>();

        public string cemail = "";
        public string cpass = "";
        public string errmsg = "";
        public string sucmsg = "";
        public void OnGet()
        {
            Console.WriteLine("Inside the main method");
            try
            {
                string connectionString =
                    "Data Source=PUNITHKUMAR\\SQLEXPRESS;Initial Catalog=loginregDB;Persist Security Info=True;User ID=sa;Password=pass@word!";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Inside the Chewck method");
                    string Sql = "Select name,email,pass from loginDetails";
                    using (SqlCommand scom = new SqlCommand(Sql, conn))
                    {
                        using (SqlDataReader reader = scom.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataLR d = new DataLR();
                                d.name = reader.GetString(0);
                                d.email = reader.GetString(1);
                                d.pass = reader.GetString(2);
                                Console.WriteLine($"ID: d.name, Name: {d.email}, Age: {d.pass}");
                                listD.Add(d);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void OnPost()
        {
            Console.WriteLine("Inside the main method");
            try
            {
                string connectionString =
                    "Data Source=PUNITHKUMAR\\SQLEXPRESS;Initial Catalog=loginregDB;Persist Security Info=True;User ID=sa;Password=pass@word!";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Inside the Chewck method");
                    string Sql = "Select name,email,pass from loginDetails";
                    using (SqlCommand scom = new SqlCommand(Sql, conn))
                    {
                        using (SqlDataReader reader = scom.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataLR d = new DataLR();
                                d.name = reader.GetString(0);
                                d.email = reader.GetString(1);
                                d.pass = reader.GetString(2);
                                Console.WriteLine($"ID: d.name, Name: {d.email}, Age: {d.pass}");
                                listD.Add(d);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            cemail = Request.Form["email"];
            cpass = Request.Form["pass"];

            if (cpass.Length == 0 ||cemail.Length == 0)
            {
                errmsg = "All fields are Required";
             
            }
            else
            {
                Console.WriteLine("inside");
                for (int i = 0; i < listD.Count; i++)
                {
                    if (cemail != listD[i].email || cpass != listD[i].pass)
                    {
                        errmsg = "please enter the Correct data";
                    }
                    else
                    {
                        sucmsg = "Logged in Successfully";
                      
                    }
                }
            }


        }
    }

  

    public class DataLR
    {
        public string name="";
        public string email="";
        public string pass="";
    }
}
