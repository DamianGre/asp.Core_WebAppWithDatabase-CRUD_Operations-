using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebAppWithDatabase_CRUD_Operations_.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.name.Length == 0 ||
                    clientInfo.email.Length == 0 ||
                    clientInfo.phone.Length == 0 ||
                    clientInfo.address.Length == 0)
            {
                        errorMessage = "All fields are required!";
                        return;
            }

            try {
                String connectionString = "Here enter YOUR DATABASE INFOMATION";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                String query = "INSERT INTO clients" +
                               "(name, email, phone, address) VALUES" +
                               "(@name, @email, @phone, @address);";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@name", clientInfo.name);
                cmd.Parameters.AddWithValue("@email", clientInfo.email);
                cmd.Parameters.AddWithValue("@phone", clientInfo.phone);
                cmd.Parameters.AddWithValue("@address", clientInfo.address);             

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex) { 
                errorMessage = ex.Message;
                return;
            }

            clientInfo.name = "";
            clientInfo.email = "";
            clientInfo.phone = "";
            clientInfo.address = "";
            successMessage = "New client has been added correctly";

            Response.Redirect("/Clients/Index");
        }
    }
}
