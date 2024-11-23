using MySql.Data.MySqlClient;

namespace RM
{
    public class MainClass
    {
        public static readonly string connectString = "SERVER=localhost;DATABASE=rm;UID=root;PASSWORD=123123;";
        public static MySqlConnection conn = new MySqlConnection(connectString);

        // Method to check user validation
        public static bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            string query = "SELECT * FROM users WHERE username = @username AND upass = @password";

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            isValid = true;
                        }
                        else
                        {
                            // Sai thông tin đăng nhập
                        }
                    }
                }
            }
            return isValid;
        }

    }
}
