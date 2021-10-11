using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmokyPet.Applicaiton.Features.Pets.Commands;
using SmokyPet.Applicaiton.Features.Pets.Queries;
using SmokyPet.Workspace.Models;
using System.Threading.Tasks;

namespace SmokyPet.Workspace.Controllers
{
    [Route("api/pets")]
    public class PetsController : ApiControllerBase
    {
        private readonly ISender _sender;

        public PetsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ApiResult> GetPets()
        {
            return await _sender.Send(new GetPets.Query());
        }

        [HttpGet("{id}")]
        public async Task<ApiResult> GetPet(int id)
        {
            return await _sender.Send(new GetPet.Query(id));
        }

        [HttpPut("{id}")]
        public async Task<ApiResult> UpdatePet(int id, PetUpdateRequest request)
        {
            return await _sender.Send(new UpdatePet.Command(id, request.Name, request.DateOfBirth));
        }


        [HttpPost]
        public async Task<ApiResult> CreatePet(PetCreateRequest request)
        {
            return await _sender.Send(new CreatePet.Command(request.Name, request.DateOfBirth));
        }

        [HttpDelete("{id}")]       
        public async Task<ApiResult> DeletePet(int id)
        {
            return await _sender.Send(new DeletePet.Command(id));
        }
    }
}
