using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using LoginRegisterMVC.Pages.Login;



namespace LoginRegisterMVC.Pages.Register
{
    public class RegModel : PageModel
    {
        public DataLR data = new DataLR();
        public string errmsg ="";
        public string sucmsg ="";
        public void OnGet()
        {
           
        }

        public void OnPost()
        {
            data.name = Request.Form["name"];
            data.email = Request.Form["email"];
            data.pass = Request.Form["pass"];
          
            if (data.name == null || data.email == null)
            {
                errmsg = "All fields are Required";
                return;
            }

            //if (!cpass.Equals(data.pass))
            //{
            //    errmsg = "Please enter the same Password";
            //    return;
            //}

            try
            {
                string connectionString =
                    "Data Source=PUNITHKUMAR\\SQLEXPRESS;Initial Catalog=loginregDB;Persist Security Info=True;User ID=sa;Password=pass@word!";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Sql = "Insert into loginDetails(name,email,pass) values(@name,@email,@pass)";
                    using (SqlCommand scom = new SqlCommand(Sql, conn))
                    {
                        scom.Parameters.AddWithValue("@name", data.name);
                        scom.Parameters.AddWithValue("@email", data.email);
                        scom.Parameters.AddWithValue("@pass", data.pass);
                        scom.ExecuteNonQuery();
                        Console.WriteLine("Connected");
                    }

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e.ToString());
            }

            data.name = "";
            data.email = "";
            data.pass = "";
            sucmsg = "New data added successfully";
        }


    }
}
