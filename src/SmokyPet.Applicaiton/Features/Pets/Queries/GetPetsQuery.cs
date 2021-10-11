using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Applicaiton.Features.Pets.Models;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Pets.Queries
{
    public class GetPets
    {
        public record Query : IQuery<List<PetModel>>;

        public class Handler : IQueryHandler<Query, List<PetModel>>
        {
            private readonly DbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(DbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Result<List<PetModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Set<Pet>()
                    .ProjectTo<PetModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
