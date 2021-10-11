using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Owners.Commands
{
    public class DeleteOwner
    {
        public record Command(int Id) : ICommand;

        public class Handler : ICommandHandler<Command>
        {
            private readonly DbContext _dbContext;

            public Handler(DbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var owner = await _dbContext.Set<Owner>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if(owner is not null)
                {
                    _dbContext.Remove(owner);

                    await _dbContext.SaveChangesAsync();
                }

                return Result.Success();
            }
        }
    }
}