using FutApp.Dtos;
using FutApp.Service;
using FutApp.Teams;
using FutApp.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FutApp.Implementations
{
    public class TeamService : ApplicationService, ITeamService
    {
        private readonly IRepository<Team, Guid> _teamRepository;
        private readonly IRepository<Player, Guid> _playerRepository;

        public TeamService(IRepository<Team, Guid> teamRepository, IRepository<Player, Guid> playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        public async Task<List<TeamDto>> GetListAsync()
        {
            List<Team> teams = await _teamRepository.GetListAsync();

            return teams
            .Where(x => x.IsActive)
            .Select(item => ObjectMapper.Map<Team, TeamDto>(item)).ToList();
        }

        public async Task<TeamDto> GetAsync(Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (team != null && team.IsActive)
            {
                return ObjectMapper.Map<Team, TeamDto>(team);
            }

            throw new Exception("Team not found");
        }

        public async Task<TeamDto> CreateAsync(TeamDto input)
        {
            Team team = ObjectMapper.Map<TeamDto, Team>(input);
            await _teamRepository.InsertAsync(team);

            return input;
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (team != null) 
            {
                team.IsActive = false;
                await _teamRepository.UpdateAsync(team);
            }
        }

        public async Task<TeamDto> AddPlayers(List<Guid> players, Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (team == null) { throw new Exception("Team not found"); }

            foreach (Guid playerId in players)
            {
                Player player = await _playerRepository.GetAsync(playerId);
                
                if (player != null ) 
                {
                    team.Players.Add(player);
                }
            }

            Team teamUpdate = await _teamRepository.UpdateAsync(team);

            return ObjectMapper.Map<Team, TeamDto>(teamUpdate);
        }
    }
}
