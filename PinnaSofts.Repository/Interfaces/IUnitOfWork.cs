using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinnaSofts.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        //void Dispose();        
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        
    }
}
