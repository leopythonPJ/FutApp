using FutApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FutApp.Service
{
    public interface ITeamService : IApplicationService
    {
        Task<List<TeamDto>> GetListAsync();
        Task<TeamDto> GetAsync(Guid id);
        Task<TeamDto> CreateAsync(TeamDto input);
        Task DeleteAsync(Guid id);
        Task<TeamDto> AddPlayers(List<Guid> players, Guid id);
        Task<TeamDto> RemovePlayers(List<Guid> players, Guid id);
        Task AcceptRequest(Guid id, Guid requestId);
        Task RejectRequest(Guid id, Guid requestId);
    }
}
