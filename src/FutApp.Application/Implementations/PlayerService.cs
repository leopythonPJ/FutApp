using FutApp.Dtos;
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
    public class PlayerService : ApplicationService, IPlayerService
    {
        private readonly IRepository<Player, Guid> _playerRepository;

        public PlayerService(IRepository<Player, Guid> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<PlayerDto>> GetListAsync()
        {
            List<Player> players = await _playerRepository.GetListAsync();
            
            return players
                .Select(item => new PlayerDto
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Number = item.Number,
                    BirthDate = item.BirthDate
                }).ToList();
        }
    }
}
