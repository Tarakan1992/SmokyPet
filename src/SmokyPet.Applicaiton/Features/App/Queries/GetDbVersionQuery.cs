using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.App.Queries
{
    public static class GetDbVersion
    {
        public record Query() : IQuery<string>;

        public class Handler : IQueryHandler<Query, string>
        {
            private readonly DbContext _dbContext;

            public Handler(DbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dbVersion = await _dbContext.Set<DbVersion>().OrderByDescending(x => x.DateApplied).FirstAsync();

                return dbVersion.Version;
            }
        }
    }
}
