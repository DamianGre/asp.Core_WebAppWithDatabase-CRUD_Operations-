using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebAppWithDatabase_CRUD_Operations_.Pages.Clients
{   
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet(){
            String id = Request.Query["iD"];

            try
            {
                String connectionString = "Data Source=DESKTOP-JPCJ5T7;Initial Catalog=WebAppWithDatabase;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                String query = "SELECT * FROM clients clients WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                    
                    clientInfo.id = "" + reader.GetInt32(0);
                    clientInfo.name = reader.GetString(1);
                    clientInfo.email = reader.GetString(2);
                    clientInfo.phone = reader.GetString(3);
                    clientInfo.address = reader.GetString(4);                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost() {
            clientInfo.id = Request.Form["id"];
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.id.Length == 0 ||
                   clientInfo.name.Length == 0 ||
                   clientInfo.email.Length == 0 ||
                   clientInfo.phone.Length == 0 ||
                   clientInfo.address.Length == 0)
            {
                errorMessage = "All fields are required!";
                return;
            }
            
            try
            {
                String connectionString = "Data Source=DESKTOP-JPCJ5T7;Initial Catalog=WebAppWithDatabase;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                String query = "UPDATE clients SET name=@name, email=@email, phone=@phone, address=@address WHERE id=@id;";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@name", clientInfo.name);
                cmd.Parameters.AddWithValue("@email", clientInfo.email);
                cmd.Parameters.AddWithValue("@phone", clientInfo.phone);
                cmd.Parameters.AddWithValue("@address", clientInfo.address);
                cmd.Parameters.AddWithValue("@id", clientInfo.id);

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Clients/Index");
        }
    }
}
