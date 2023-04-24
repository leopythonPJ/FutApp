using FutApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FutApp.Service
{
    public interface IRequestService : IApplicationService
    {
        Task<List<RequestDto>> GetListAsync();
        Task<RequestDto> GetAsync(Guid id);
        Task<RequestDto> CreateAsync(RequestDto input, Guid teamId);
        Task DeleteAsync(Guid id);
    }
}
