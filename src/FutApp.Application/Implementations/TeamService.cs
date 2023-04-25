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
using Volo.Abp.Users;
using Volo.Abp.Identity;
using Microsoft.AspNetCore.Authorization;
using FutApp.Requests;

namespace FutApp.Implementations
{
    [Authorize]
    public class TeamService : ApplicationService, ITeamService
    {
        private readonly IRepository<Team, Guid> _teamRepository;
        private readonly IRepository<Player, Guid> _playerRepository;
        private readonly ICurrentUser _currentUser;

        public TeamService(IRepository<Team, Guid> teamRepository, IRepository<Player, Guid> playerRepository, ICurrentUser currentUser)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
            _currentUser = currentUser;
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
            team.President = (IdentityUser) _currentUser;

            await _teamRepository.InsertAsync(team);

            return input;
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (!IsPresident(team))
            {
                throw new Exception("User not authorized");
            }

            if (team != null) 
            {
                team.IsActive = false;
                await _teamRepository.UpdateAsync(team);
            }
        }

        public async Task<TeamDto> AddPlayers(List<Guid> players, Guid id)
        {
            Team team = await _teamRepository.GetAsync(id);

            if (!IsPresident(team))
            {
                throw new Exception("User not authorized");
            }

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

            if (!IsPresident(team))
            {
                throw new Exception("User not authorized");
            }

            if (team == null) { throw new Exception("Team not found"); }

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

        public async Task AcceptRequest(Guid id, Guid requestId)
        {
            Team team = await _teamRepository.FindAsync(id);
            
            if (team == null) { throw new Exception("Team not found"); }

            Request? request = team.Requests.Find(x => x.Id == requestId);

            if(request == null) { throw new Exception("Request not found"); }

            request.Status = Status.Success;
            await _teamRepository.UpdateAsync(team);
        }

        public async Task RejectRequest(Guid id, Guid requestId)
        {
            Team team = await _teamRepository.FindAsync(id);

            if (team == null) { throw new Exception("Team not found"); }

            Request? request = team.Requests.Find(x => x.Id == requestId);

            if (request == null) { throw new Exception("Request not found"); }

            request.Status = Status.Rejected;
            await _teamRepository.UpdateAsync(team);
        }

        private bool IsPresident(Team team)
        {
            string emailUser = _currentUser.Email;

            if(team != null && emailUser == team.President.Email)
            {
                return true;
            }

            return false;
        }
    }
}
