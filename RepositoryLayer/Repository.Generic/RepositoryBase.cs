using RepositoryLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.Generic
{
    #region Might cause unnecessary complexity

    /// <summary>
    /// Read, get methods of repository
    /// </summary>
    /// <typeparam name="T">an aggregate root</typeparam>
    public interface IReadOnlyRepository<out T> where T : IAggregateRoot
    {
        IEnumerable<T> GetAll();

        T GetBy(int id);
    }

    /// <summary>
    /// insert, update methods of repository
    /// </summary>
    /// <typeparam name="T">an aggregate root</typeparam>
    public interface IWriteOnlyRepository<in T> where T : IAggregateRoot
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);
    }

    #endregion

    /// <summary>
    /// Generic Repository interface
    /// </summary>
    /// <typeparam name="T">an aggregate root</typeparam>
    public interface IRepository<T> : IRepository, IReadOnlyRepository<T>, IWriteOnlyRepository<T> where T : IAggregateRoot
    { }

    /// <summary>
    /// Creates a base class for different data access technologies.
    /// </summary>
    /// <typeparam name="T">an aggregate root</typeparam>
    /// <typeparam name="C">class that has connection operations</typeparam>
    public abstract class RepositoryBase<T, C> : RepositoryBase
        where T : class, IAggregateRoot
        where C : class
    {
        protected C DalContext { get; set; }

        public RepositoryBase(C dalContext)
        {
            DalContext = dalContext;
        }

    }
}
