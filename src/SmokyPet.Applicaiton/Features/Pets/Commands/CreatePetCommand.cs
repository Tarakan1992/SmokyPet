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
    public class CreatePet
    {
        public record Command(string Name, DateTime DateOfBirth) : ICommand<int>;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.DateOfBirth).NotEmpty();
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
                var pet = new Pet(request.Name, request.DateOfBirth);

                await _dbContext.AddAsync(pet);
                await _dbContext.SaveChangesAsync();

                return pet.Id;
            }
        }
    }
}
