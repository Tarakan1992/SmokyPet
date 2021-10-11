using FluentValidation;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Owners.Commands
{
    public class CreateOwner 
    {
        public record Command(string FirstName, string LastName) : ICommand<int>;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class Handler : ICommandHandler<Command, int>
        {
            private readonly DbContext _dbContext;

            public Handler(DbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var owner = new Owner(request.FirstName, request.LastName);

                await _dbContext.AddAsync(owner);

                await _dbContext.SaveChangesAsync();

                return owner.Id;
            }
        }
    }
}
