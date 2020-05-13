using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RepositoryLayer.DAL.Dapper
{

    public static class DapperExtensions
    {
        private static void OpenConnection(this IDbConnection Connection)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }

        private static void CloseConnection(this IDbConnection Connection)
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        private static TRes ConnectionAction<TRes>(this IDbConnection Connection, Func<TRes> action)
        {
            OpenConnection(Connection);
            var res = action();
            CloseConnection(Connection);
            return res;
        }

        public static IEnumerable<TRes> ExecStoredProcedure<TRes>(this IDbConnection Connection, string procedureName, dynamic parameters)
        {
            return ConnectionAction(Connection, () =>
            {
                return Connection.Query<TRes>(procedureName, (object[])parameters, null, false, null, CommandType.StoredProcedure);
            });
        }
    }
}
