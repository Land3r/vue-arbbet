using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;
using Arbbet.Domain.Bases;
using Arbbet.Connectors.Domain.Performances;
using AutoMapper;
using Arbbet.Domain.ViewModels;

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

        public virtual async Task<TEntity> GetAsync(Guid platformId, string platform_Id, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
            {
                if (include != null)
                {
                    return await include(_entities).FirstOrDefaultAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
                }
                else
                {
                    return await _entities.FirstOrDefaultAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
                }
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

    public abstract class AUnifiedEntityService<TEntity, TViewModel> : ACrudEntityService<TEntity, TViewModel>
        where TEntity : AUnifiedEntity<TEntity>
        where TViewModel : AUnifiedViewModel
    {
        public AUnifiedEntityService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }

        public virtual async Task<bool> ExistsAsync(Guid platformId, string platform_Id)
        {
            using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
            {
                return await _entities.AnyAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
            }
        }

        public virtual async Task<TViewModel> GetAsync(Guid platformId, string platform_Id, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
            {
                TEntity entity = null;
                if (include != null)
                {
                    entity = await include(_entities).FirstOrDefaultAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
                }
                else
                {
                    entity = await _entities.FirstOrDefaultAsync(elm => elm.PlatformId == platformId && elm.Platform_Id == platform_Id);
                }

                return _mapper.Map<TViewModel>(entity);
            }
        }

        public TViewModel Create(Guid platformId, TEntity entity)
        {
            if (entity.PlatformId == null || entity.PlatformId != platformId)
            {
                entity.PlatformId = platformId;
            }
            return base.Create(entity);
        }

        public TViewModel Create(Guid platformId, TViewModel entity)
        {
            if (entity.PlatformId == null || entity.PlatformId != platformId)
            {
                entity.PlatformId = platformId;
            }
            return base.Create(entity);
        }

        public TViewModel Update(Guid platformId, TEntity entity)
        {
            if (entity.PlatformId == null || entity.PlatformId != platformId)
            {
                entity.PlatformId = platformId;
            }
            return base.Update(entity);
        }

        public TViewModel Update(Guid platformId, TViewModel entity)
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

        public void Delete(Guid platformId, TViewModel entity)
        {
            if (entity.PlatformId == null || entity.PlatformId != platformId)
            {
                entity.PlatformId = platformId;
            }
            base.Delete(entity);
        }
    }
}