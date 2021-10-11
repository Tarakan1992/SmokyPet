using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Applicaiton.Features.Owners.Models;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Owners.Queries
{
    public class GetOwners
    {
        public record Query : IQuery<List<OwnerModel>>;

        public class Handler : IQueryHandler<Query, List<OwnerModel>>
        {
            private readonly DbContext _dbContext;

            private readonly IMapper _mapper;

            public Handler(DbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Result<List<OwnerModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Set<Owner>()
                    .ProjectTo<OwnerModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
