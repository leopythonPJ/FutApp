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
                .Select(item => new TeamDto
                {
                    Name = item.Name,
                    ShortName = item.ShortName,
                    Img = item.Img,
                    Goals = item.Goals,
                    YellowCards = item.YellowCards,
                    RedCards = item.RedCards

                }).ToList();
        }

        public async Task<TeamDto> GetAsync(Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            TeamDto teamDto = new TeamDto
            {
                Name = team.Name,
                ShortName = team.ShortName,
                Img = team.Img,
                Goals = team.Goals,
                YellowCards = team.YellowCards,
                RedCards = team.RedCards
            };

            return teamDto;
        }

        public async Task<TeamDto> CreateAsync(TeamDto input)
        {
            Team team = new Team
            {
                Name = input.Name,
                ShortName = input.ShortName,
                Img = input.Img
            };

            await _teamRepository.InsertAsync(team);

            return input;
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (team != null) { await _teamRepository.DeleteAsync(team); }
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

        public async Task<TeamDto> RemovePlayers(List<Guid> players, Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if(team == null) { throw new Exception("Team not found"); }

            foreach (Guid playerId in players)
            {
                Player player = await _playerRepository.GetAsync(playerId);

                if (player != null)
                {
                    team.Players.Remove(player);
                }
            }

            Team teamUpdate = await _teamRepository.UpdateAsync(team);

            return ObjectMapper.Map<Team, TeamDto>(teamUpdate);
        }
    }
}
