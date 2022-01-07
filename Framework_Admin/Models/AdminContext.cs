using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class AdminContext
    {
        public string ConnectionString { get; set; }//biết thành viên
        public AdminContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection() //lấy connection
        {
            return new MySqlConnection(ConnectionString);
        }
        public int XoaSach(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from booklist where masach=@masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masach", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
    }
}
