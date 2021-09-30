using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmokyPet.Applicaiton.Features.App.Queries;
using System.Threading.Tasks;

namespace SmokyPet.Workspace.Controllers
{
    public class AppController : ApiControllerBase
    {
        private readonly ISender _sender;

        public AppController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("version")]
        public async Task<ApiResult> GetVersion()
        {
            return await _sender.Send(new GetDbVersion.Query());
        }
    }
}
