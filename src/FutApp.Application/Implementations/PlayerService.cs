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
                .Select(item => ObjectMapper.Map<Player,PlayerDto>(item)).ToList();

        }

        public async Task<PlayerDto> GetAsync(Guid id)
        {
            Player player = await _playerRepository.GetAsync(id);

            return ObjectMapper.Map<Player, PlayerDto>(player);
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto input)
        {
            Player player = ObjectMapper.Map<PlayerDto, Player>(input);
            player.CreationTime = DateTime.Now;
            player.CreatorId = CurrentUser.Id;

            await _playerRepository.InsertAsync(player);

            return input;
        }

        public async Task<PlayerDto> UpdateAsync(PlayerUpdateDto input, Guid id) 
        {
            Player player = await _playerRepository.GetAsync(id);

            if(player != null)
            {
                Player updatedPlayer = await _playerRepository.UpdateAsync(player);
                return ObjectMapper.Map<Player, PlayerDto>(updatedPlayer);
            }

            throw new Exception("Player to update not found");            
        }

        public async Task DeleteAsync(Guid id)
        {
            Player player = await _playerRepository.GetAsync(id);

            if (player != null) { await _playerRepository.DeleteAsync(player); }
        }
    }
}
