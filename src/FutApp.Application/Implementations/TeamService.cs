using FutApp.Dtos;
using FutApp.Service;
using FutApp.Teams;
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

        public TeamService(IRepository<Team, Guid> teamRepository)
        {
            _teamRepository = teamRepository;
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
    }
}
