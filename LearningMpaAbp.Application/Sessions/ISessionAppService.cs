﻿using System.Threading.Tasks;
using Abp.Application.Services;
using LearningMpaAbp.Sessions.Dto;

namespace LearningMpaAbp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
