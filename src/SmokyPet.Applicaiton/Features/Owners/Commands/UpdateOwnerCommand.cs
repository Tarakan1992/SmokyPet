using FluentValidation;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Owners.Commands
{
    public class UpdateOwner
    {
        public record Command(int Id, string FirstName, string LastName) : ICommand;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

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

                if (owner == null)
                {
                    return Result.NotFound($"'Owner' with Id: {request.Id} doesn't exist");
                }

                owner.Update(request.FirstName, request.LastName);

                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
        }
    }
}
