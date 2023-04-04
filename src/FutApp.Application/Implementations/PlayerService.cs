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

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            Player player = await _playerRepository.GetAsync(id);

            PlayerDto playerDto = new PlayerDto
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Number = player.Number,
                BirthDate = player.BirthDate
            };

            return playerDto;
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto input)
        {
            Player player = new Player
            {
                CreationTime = DateTime.Now,
                CreatorId = CurrentUser.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                BirthDate = input.BirthDate,
                Number = input.Number
            };

            await _playerRepository.InsertAsync(player);

            return input;
        }

        public async Task DeleteAsync(Guid id)
        {
            Player player = await _playerRepository.GetAsync(id);

            if (player != null) { await _playerRepository.DeleteAsync(player); }
        }
    }
}
