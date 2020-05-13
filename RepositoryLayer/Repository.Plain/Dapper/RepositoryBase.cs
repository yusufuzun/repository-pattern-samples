using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using RepositoryLayer.Core;
using RepositoryLayer.DAL.Dapper;
using Elasticsearch.Net;
using Elasticsearch.Net.ConnectionPool;
using Elasticsearch.Net.Connection;
using System.Configuration;

namespace RepositoryLayer.Repository.Plain.Dapper
{
    public class RepositoryBase
    {
        public SqlConnection DbWriteConnection { get; set; }
        public SqlConnection DbReadConnection { get; set; }
        public SqlConnection LogDbConnection { get; set; }
        public ElasticsearchClient SearchDbConnection { get; set; }

        public RepositoryBase()
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
