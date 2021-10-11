using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmokyPet.Applicaiton.Features.Owners.Commands;
using SmokyPet.Applicaiton.Features.Owners.Queries;
using SmokyPet.Workspace.Models;
using System.Threading.Tasks;

namespace SmokyPet.Workspace.Controllers
{
    [Route("api/owners")]
    public class OwnersController : ApiControllerBase
    {
        private readonly ISender _sender;

        public OwnersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ApiResult> GetOwners()
        {
            return await _sender.Send(new GetOwners.Query());
        }

        [HttpGet("{id}")]
        public async Task<ApiResult> GetOwner(int id)
        {
            return await _sender.Send(new GetOwner.Query(id));
        }

        [HttpPost]
        public async Task<ApiResult> CreateOwner(OwnerCreateRequest request)
        {
            return await _sender.Send(new CreateOwner.Command(request.FirstName, request.LastName));
        }

        [HttpPut("{id}")]
        public async Task<ApiResult> UpdateOwner(int id, OwnerUpdateRequest request)
        {
            return await _sender.Send(new UpdateOwner.Command(id, request.FirstName, request.LastName));
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteOwner(int id)
        {
            return await _sender.Send(new DeleteOwner.Command(id));
        }
    }
}
