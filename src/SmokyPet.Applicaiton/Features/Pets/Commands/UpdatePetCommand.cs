using FluentValidation;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using SmokyPet.Application.CQRS;
using SmokyPet.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Applicaiton.Features.Pets.Commands
{
    public class UpdatePet
    {
        public record Command(int Id, string Name, DateTime DateOfBirth) : ICommand;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.DateOfBirth).NotEmpty();
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
                var pet = await _dbContext.Set<Pet>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (pet == null)
                {
                    return Result.NotFound($"'Pet' with Id: {request.Id} doesn't exist");
                }

                pet.Update(request.Name, request.DateOfBirth);

                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
        }
    }
}
