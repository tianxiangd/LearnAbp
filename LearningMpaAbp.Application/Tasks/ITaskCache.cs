
using Abp.Domain.Entities.Caching;
using LearningMpaAbp.Tasks.Dtos;

namespace LearningMpaAbp.Tasks
{
    public interface ITaskCache : IEntityCache<TaskCacheItem>
    {
    }
}