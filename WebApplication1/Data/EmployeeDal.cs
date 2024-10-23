using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class EmployeeDal
    {
        SqlConnection _connection=null;
        SqlCommand command = null;
        public static IConfiguration Configuration { get; set; }
        // Way to read connection string
        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }
        public List<Employees> GetAllEmployeeName()
        {
            List<Employees> employees = new List<Employees>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
               
                command = _connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetEmployees]";
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employees employee = new Employees();
                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = reader["Name"].ToString();
                    employees.Add(employee);
                }
                _connection.Close();
            }
            return employees;
        }
    }
}
