using Elasticsearch.Net;
using Elasticsearch.Net.Connection;
using Elasticsearch.Net.ConnectionPool;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.Static
{
    public class RepositoryBase
    {

        public static SqlConnection DbWriteConnection { get; set; }
        public static SqlConnection DbReadConnection { get; set; }
        public static SqlConnection LogDbConnection { get; set; }
        public static ElasticsearchClient SearchDbConnection { get; set; }

        static RepositoryBase()
        {
            DbWriteConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["WriteConStr"].ConnectionString);
            DbReadConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ReadConStr"].ConnectionString);
            LogDbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LogDbConStr"].ConnectionString);

            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearchNode"]);
            var connectionPool = new SniffingConnectionPool(new[] { node });
            var config = new ConnectionConfiguration(connectionPool);
            SearchDbConnection = new ElasticsearchClient(config);
        }
    }
}
