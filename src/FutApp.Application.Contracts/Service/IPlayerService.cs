using FutApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FutApp
{
    public interface IPlayerService : IApplicationService
    {   
        Task<List<PlayerDto>> GetListAsync();
        Task<PlayerDto> GetAsync(Guid id);
        Task<PlayerDto> CreateAsync(PlayerDto input);
        Task DeleteAsync(Guid id);

    }
}
