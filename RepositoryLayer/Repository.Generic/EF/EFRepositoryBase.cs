using RepositoryLayer.Core;
using RepositoryLayer.DAL.EF;
using RepositoryLayer.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Generic.EF
{
    public class EFRepositoryBase<T> : RepositoryBase<T, ModelContext>, IRepository<T> where T : class, IAggregateRoot
    {
        public EFRepositoryBase()
            : base(new ModelContext())
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return DalContext.Set<T>().ToList().AsEnumerable();
        }

        public T GetBy(int id)
        {
            return DalContext.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public void Add(T item)
        {
            DalContext.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            DalContext.Set<T>().Attach(item);
        }

        public void Delete(T item)
        {
            DalContext.Set<T>().Remove(item);
        }
    }

}
