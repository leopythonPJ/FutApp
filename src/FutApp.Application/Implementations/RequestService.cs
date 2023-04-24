using FutApp.Dtos;
using FutApp.Players;
using FutApp.Requests;
using FutApp.Service;
using FutApp.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace FutApp.Implementations
{
    public class RequestService : ApplicationService, IRequestService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        private readonly IRepository<Team, Guid> _teamRepository;

        public RequestService(IRepository<Request, Guid> requestRepository, IRepository<Team, Guid> teamRepository)
        {
            _requestRepository = requestRepository;
            _teamRepository = teamRepository;
        }

        public async Task<List<RequestDto>> GetListAsync()
        {
            List<Request> request = await _requestRepository.GetListAsync();

            return request
                .Select(item => ObjectMapper.Map<Request, RequestDto>(item)).ToList();

        }

        public async Task<RequestDto> GetAsync(Guid id)
        {
            Request request = await _requestRepository.GetAsync(id);

            return ObjectMapper.Map<Request, RequestDto>(request);
        }

        public async Task<RequestDto> CreateAsync(RequestDto input, Guid teamId)
        {

            Request request = ObjectMapper.Map<RequestDto, Request>(input);
            request.CreationTime = DateTime.Now;
            request.CreatorId = CurrentUser.Id;

            Request requestInserted = await _requestRepository.InsertAsync(request);
            Team team = await _teamRepository.FindAsync(teamId);

            if (team != null)
            {
                team.Requests.Add(requestInserted);
                await _teamRepository.UpdateAsync(team);
            }

            return  ObjectMapper.Map<Request, RequestDto>(requestInserted);
        }

        public async Task<RequestDto> UpdateAsync(RequestDto input, Guid id)
        {
            Request request = await _requestRepository.GetAsync(id);

            if (request != null)
            {
                Request updatedRequest = await _requestRepository.UpdateAsync(request);
                return ObjectMapper.Map<Request, RequestDto>(updatedRequest);
            }

            throw new Exception("Request to update not found");
        }

        public async Task DeleteAsync(Guid id)
        {
            Request request = await _requestRepository.GetAsync(id);

            if (request != null) { await _requestRepository.DeleteAsync(request); }
        }
    }
}
