using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Actions
{
    EXECUTE_NON_QUERY = 0,
    EXECUTE_READER,
    EXECUTE_SCALAR
}

namespace curs_work
{
    class DatabaseConnection
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CarAccountConnectionString"].ConnectionString;

        public static SqlConnection Connection { get { return new SqlConnection(connectionString); } }

        public static object CommandExecute(string query, SqlParameter[] parameters, Actions action, CommandType type = CommandType.Text)
        {
            object result = null;
            List<object[]> data = new List<object[]>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = type;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                       
                    switch (action) {
                        case Actions.EXECUTE_NON_QUERY: 
                            result = command.ExecuteNonQuery(); 
                            break;
                        case Actions.EXECUTE_READER:
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                List<object> row = new List<object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader[i]);
                                }
                                data.Add(row.ToArray());
                            }
                            result = data;
                            break;
                        case Actions.EXECUTE_SCALAR:
                            result = command.ExecuteScalar();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.ShowError($"Помилка при виконанні запиту! {ex.Message}");
            }
            return result;
        }


        public static int ExecuteNonQuery(string query, SqlParameter[] parameters=null)
        {
            return Convert.ToInt32(CommandExecute(query, parameters, Actions.EXECUTE_NON_QUERY));
        }

        public static List<object[]> ExecuteReader(string query, SqlParameter[] parameters=null)
        {
            return (List<object[]>)CommandExecute(query, parameters, Actions.EXECUTE_READER);
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters=null)
        {
            return CommandExecute(query, parameters, Actions.EXECUTE_SCALAR);
        }
    }
}
