using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskDataAccess.DAOs
{
    public class SqlDao
    {
        private string _connectionString = "";

        //Singleton Pattern #1 create a private instane of the same class.
        private static SqlDao _instance;

        //Singleton Pattern #2 the constructor needs to be private, so nobody could instance it.
        private SqlDao()
        {
            _connectionString = "Data Source=personalprojects.database.windows.net;Initial Catalog=ProdcuctsTask;Persist Security Info=True;User ID=sysman;Password=tilaran.99";
        }

        //Singleton Pattern #3 method to expose the instance of the SqlDao class
        public static SqlDao GetInstance()
        {
            //Singleton Pattern #4 validate the state of the instance to make sure that there is only 1.
            if (_instance == null)
            {
                _instance = new SqlDao();
            }
            return _instance;
        }

        //Method to send data to the DB through SP
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        //Method to get data from the DB, also allows sending data
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();

                //From here we start working the extraction of the data
                var reader = command.ExecuteReader();
                //Verifies that the query has results or rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //We build a dictionary according to each of the lines returned by the query
                        var dictRow = new Dictionary<string, object>();

                        for (var index = 0; index < reader.FieldCount; index++)
                        {
                            //We add each file to the dicctionary like a key and value
                            var key = reader.GetName(index);
                            var value = reader.GetValue(index);

                            dictRow.Add(key, value);
                        }
                        //We save in the list the dictionary from a row of the result
                        lstResult.Add(dictRow);
                    }
                }
            }

            return lstResult;
        }
    }
}
