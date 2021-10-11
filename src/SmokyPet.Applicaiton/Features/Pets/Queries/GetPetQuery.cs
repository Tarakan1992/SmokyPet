using AutoMapper;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Applicaiton.Features.Pets.Models;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Pets.Queries
{
    public class GetPet
    {
        public record Query(int Id) : IQuery<PetModel>;

        public class Handler : IQueryHandler<Query, PetModel>
        {
            private readonly DbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(DbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Result<PetModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pet = await _dbContext.Set<Pet>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (pet == null)
                {
                    return Result.NotFound($"'Pet' with Id: {request.Id} doesn't exist");
                }

                return _mapper.Map<PetModel>(pet);
            }
        }
    }
}
