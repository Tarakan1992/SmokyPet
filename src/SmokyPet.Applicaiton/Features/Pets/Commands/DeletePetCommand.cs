using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Pets.Commands
{
    public class DeletePet
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
                var pet = await _dbContext.Set<Pet>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (pet != null)
                {
                    _dbContext.Remove(pet);

                    await _dbContext.SaveChangesAsync();
                }

                return Result.Success();
            }
        }
    }
}
