using Abp.AutoMapper;

namespace LearningMpaAbp.Tasks.Dtos
{
    [AutoMapFrom(typeof(Task))]
    public class TaskCacheItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskState State { get; set; }
    }
}