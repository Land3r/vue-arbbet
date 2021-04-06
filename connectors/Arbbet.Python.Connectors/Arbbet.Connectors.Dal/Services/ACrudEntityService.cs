using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Arbbet.Connectors.Dal.Services
{
  public abstract class ACrudEntityService<TEntity> where TEntity : class
  {
    protected readonly ConnectorDbContext _context;
    protected readonly DbSet<TEntity> _entities;
    protected readonly PerformanceStatService _performanceStatService;

    public ACrudEntityService(ConnectorDbContext connectorDbContext,
      PerformanceStatService performanceStatService)
    {
      _context = connectorDbContext;
      _entities = _context.Set<TEntity>();
      _performanceStatService = performanceStatService;
    }

    public virtual async Task<TEntity> Get(Guid id)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return await _entities.FindAsync(id);
      }
    }

    public virtual TEntity Create(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Add(entity);
        return entity;
      }
    }

    public virtual TEntity Update(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Update(entity);
        return entity;
      }
    }

    public virtual void Delete(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Remove(entity);
      }
    }

    public virtual IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return _entities.Where(predicate);
      }
    }

    public virtual TEntity FirstOrDefault(Func<TEntity, bool> predicate)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return _entities.Where(predicate).FirstOrDefault();
      }
    }

    public virtual async Task CommitAsync()
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        await _context.SaveChangesAsync();
      }
    }
  }
}
