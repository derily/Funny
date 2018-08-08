using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny.Data
{
    public interface IDbProxy
    {
        Task<int> ExecuteNonQuery(CommandType cmdType, string cmdText,
                          params DbParameter[] commandParameters);

        Task<IEnumerable<T>> ExecuteTReader<T>(string cmdText, params DbParameter[] commandParameters) where T : class, new();
    }
}
