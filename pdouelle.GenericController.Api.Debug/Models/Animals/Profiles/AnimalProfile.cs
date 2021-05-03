using AutoMapper;
using pdouelle.GenericController.Api.Debug.Models.Animals.Entities;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.CreateAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.PatchAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.UpdateAnimal;

namespace pdouelle.GenericController.Api.Debug.Models.Animals.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<CreateAnimalCommandModel, Animal>();
            CreateMap<UpdateAnimalCommandModel, Animal>();
            CreateMap<PatchAnimalCommandModel, Animal>();
        }
    }
}