using AutoMapper;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Applicaiton.Features.Owners.Models;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Owners.Queries
{
    public class GetOwner
    {
        public record Query(int Id) : IQuery<OwnerModel>;

        public class Handler : IQueryHandler<Query, OwnerModel>
        {
            private readonly DbContext _dbContext;

            private readonly IMapper _mapper;

            public Handler(DbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Result<OwnerModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var owner = await _dbContext.Set<Owner>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (owner == null)
                {
                    return Result.NotFound($"'Owner' with Id: {request.Id} doesn't exist");
                }

                return _mapper.Map<OwnerModel>(owner);
            }
        }
    }
}
