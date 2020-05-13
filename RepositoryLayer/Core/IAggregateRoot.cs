using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Core
{
    /// <summary>
    /// Specifies your entities
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }

    /// <summary>
    /// Specifies chosen entities to being a root for a repository
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        DateTime LastModifiedDate { get; set; }

        int Status { get; set; }

        Guid RowGuid { get; set; }
    }

    /// <summary>
    /// Non-generic base
    /// </summary>
    public interface IRepository : IDisposable
    { }

    /// <summary>
    /// Non-generic base
    /// </summary>
    public abstract class RepositoryBase
    { }
}
