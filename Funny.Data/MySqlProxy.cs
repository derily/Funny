using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny.Data
{
    public class MySqlProxy : IDbProxy
    {
        private static MySqlConnection _dbConnection;
        public MySqlProxy()
        {
            _dbConnection = new MySqlConnection("host=127.0.0.1;port=3306;user id=root;password=00000000;database=icsp_zhuanke;");
        }
        public async Task<int> ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
               await _dbConnection.OpenAsync();
            }
            MySqlCommand cmd = _dbConnection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(commandParameters);
            return await   cmd.ExecuteNonQueryAsync();
           // return await Task.FromResult(0);
        }

        public async Task<IEnumerable<T>> ExecuteTReader<T>(string cmdText, params DbParameter[] commandParameters) where T : class, new()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                await _dbConnection.OpenAsync();
            }
            MySqlCommand cmd = _dbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(commandParameters);
            var reader =await cmd.ExecuteReaderAsync();
            return reader.ToList<T>();
        }

       
    }
}
