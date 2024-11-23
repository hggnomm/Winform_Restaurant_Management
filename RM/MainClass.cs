using MySql.Data.MySqlClient;
using System.Data;

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
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@password", password);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);  // Lấy kết quả truy vấn vào DataTable

                    if (dt.Rows.Count > 0)
                    {
                        isValid = true;
                        USER = dt.Rows[0]["uName"].ToString();
                    }
                    else
                    {
                        // Sai thông tin đăng nhập
                    }
                }
            }

            return isValid;
        }

        // Create property for username

        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
    }
}
