using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TAO_Core.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TAO.Core.DataAccess.EntityFramework
{
  public class EfQueryableRepositoryBase<T> : IQueryableRepository<T> where T : class, IEntity, new()
  {
    private DbContext _context;
    private IDbSet<T> _entities;

    public EfQueryableRepositoryBase(DbContext context)
    {
      _context = context;
    }

    public IQueryable<T> Table => this.Entities;

    protected virtual IDbSet<T> Entities
    {
      get
      {
        if (_entities == null)
        {
          _entities = (IDbSet<T>)_context.Set<T>();
        }
        return _entities;
      }
    }
  }
}
