using System;

namespace SmokyPet.Workspace.Models
{
    public record PetCreateRequest(string Name, DateTime DateOfBirth);
}
