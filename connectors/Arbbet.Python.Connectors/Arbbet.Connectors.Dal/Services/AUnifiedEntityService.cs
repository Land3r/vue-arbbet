using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;
using Arbbet.Domain.Bases;
using Arbbet.Connectors.Domain.Performances;

namespace Arbbet.Connectors.Dal.Services
{
  public abstract class AUnifiedEntityService<TEntity> : ACrudEntityService<TEntity> where TEntity : AUnifiedEntity<TEntity>
  {
    public AUnifiedEntityService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService) : base(connectorDbContext, performanceStatService)
    {
    }

    public virtual async Task<bool> ExistsAsync(Guid platformId, string platform_Id)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return await _entities.AnyAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
      }
    }

    public virtual async Task<TEntity> GetAsync(Guid platformId, string platform_Id)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
      {
        return await _entities.FirstOrDefaultAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
      }
    }

    public TEntity Create(Guid platformId, TEntity entity)
    {
      if (entity.PlatformId == null || entity.PlatformId != platformId)
      {
        entity.PlatformId = platformId;
      }
      return base.Create(entity);
    }

    public TEntity Update(Guid platformId, TEntity entity)
    {
      if (entity.PlatformId == null || entity.PlatformId != platformId)
      {
        entity.PlatformId = platformId;
      }
      return base.Update(entity);
    }

    public void Delete(Guid platformId, TEntity entity)
    {
      if (entity.PlatformId == null || entity.PlatformId != platformId)
      {
        entity.PlatformId = platformId;
      }
      base.Delete(entity);
    }
  }
}