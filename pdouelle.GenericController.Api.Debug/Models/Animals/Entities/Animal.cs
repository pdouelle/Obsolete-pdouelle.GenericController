using System;
using pdouelle.Entity;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.CreateAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.DeleteAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.PatchAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Commands.UpdateAnimal;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Queries.GetAnimalById;
using pdouelle.GenericController.Api.Debug.Models.Animals.Models.Queries.GetAnimalList;
using pdouelle.GenericMediatR;

namespace pdouelle.GenericController.Api.Debug.Models.Animals.Entities
{
    [
        GenericControllerEntity
        (
            Dto = typeof(AnimalDto),
            QueryList = typeof(GetAnimalListQueryModel),
            QueryById = typeof(GetAnimalByIdQueryModel),
            Create = typeof(CreateAnimalCommandModel),
            Update = typeof(UpdateAnimalCommandModel),
            Patch = typeof(PatchAnimalCommandModel),
            Delete = typeof(DeleteAnimalCommandModel)
        )
    ]
    [
        GenericMediatREntity
        (
            QueryList = typeof(GetAnimalListQueryModel),
            QueryById = typeof(GetAnimalByIdQueryModel),
            Create = typeof(CreateAnimalCommandModel),
            Update = typeof(UpdateAnimalCommandModel),
            Patch = typeof(PatchAnimalCommandModel),
            Delete = typeof(DeleteAnimalCommandModel)
        )
    ]
    public class Animal : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}