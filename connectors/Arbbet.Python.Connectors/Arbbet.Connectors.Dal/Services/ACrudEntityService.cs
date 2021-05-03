using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Interfaces;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

namespace Arbbet.Connectors.Dal.Services
{
  public abstract class ACrudEntityService<TEntity> where TEntity : class, IIdentifiable
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

  public abstract class ACrudEntityService<TEntity, TViewModel>
    where TEntity : class, IIdentifiable
    where TViewModel : class
  {
    protected readonly ConnectorDbContext _context;
    protected readonly DbSet<TEntity> _entities;
    protected IMapper _mapper;
    protected readonly PerformanceStatService _performanceStatService;

    private bool UsesDto {
      get
      {
        return typeof(TEntity) != typeof(TViewModel);
      }
    }

    public ACrudEntityService(ConnectorDbContext connectorDbContext,
      PerformanceStatService performanceStatService,
      IMapper mapper)
    {
      _context = connectorDbContext;
      _mapper = mapper;
      _entities = _context.Set<TEntity>();
      _performanceStatService = performanceStatService;
    }

    public virtual async Task<TViewModel> Get(Guid id)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        TEntity entity = await _entities.FindAsync(id);
        return _mapper.Map<TViewModel>(entity);
      }
    }

    public virtual TViewModel Create(TViewModel model)
    {
      TEntity entity = _mapper.Map<TEntity>(model);
      return Create(entity);
    }

    public virtual TViewModel Create(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Add(entity);
        TViewModel result = _mapper.Map<TViewModel>(entity);
        return result;
      }
    }

    public virtual TViewModel Update(TViewModel model)
    {
      TEntity entity = _mapper.Map<TEntity>(model);
      return Update(entity);
    }

    public virtual TViewModel Update(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Update(entity);
        TViewModel result = _mapper.Map<TViewModel>(entity);
        return result;
      }
    }

    public virtual void Delete(TViewModel model)
    {
      TEntity entity = _mapper.Map<TEntity>(model);
      _entities.Remove(entity);
    }

    public virtual void Delete(TEntity entity)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        _entities.Remove(entity);
      }
    }

    public virtual IEnumerable<TViewModel> Where(Func<TEntity, bool> predicate)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return _entities.Where(predicate).AsQueryable()?.ProjectTo<TViewModel>(_mapper.ConfigurationProvider);
      }
    }

    public virtual TViewModel FirstOrDefault(Func<TEntity, bool> predicate)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        TEntity entity = _entities.FirstOrDefault(predicate);
        return _mapper.Map<TViewModel>(entity);
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
