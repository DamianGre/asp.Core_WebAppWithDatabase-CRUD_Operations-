using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebAppWithDatabase_CRUD_Operations_.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=;Initial Catalog=WebAppWithDatabase;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                String query = "SELECT * FROM clients";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClientInfo clientInfo = new ClientInfo();
                    clientInfo.id = "" + reader.GetInt32(0);
                    clientInfo.name = reader.GetString(1);
                    clientInfo.email = reader.GetString(2);
                    clientInfo.phone = reader.GetString(3);
                    clientInfo.address = reader.GetString(4);
                    clientInfo.creation_date = reader.GetDateTime(5).ToString();

                    listClients.Add(clientInfo);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Someting went wrong! " + ex.ToString());
            }
        }
    }

    public class ClientInfo {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String creation_date;
    }
}
