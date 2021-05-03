using System;
using pdouelle.Entity;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.CreateInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.DeleteInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.PatchInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.UpdateInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Queries.GetInsectById;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Queries.GetInsectList;
using pdouelle.GenericMediatR;

namespace pdouelle.GenericController.Api.Debug.Models.Insects.Entities
{
    [
        GenericControllerEntity
        (
            Dto = typeof(InsectDto),
            QueryList = typeof(GetInsectListQueryModel),
            QueryById = typeof(GetInsectByIdQueryModel),
            Create = typeof(CreateInsectCommandModel),
            Update = typeof(UpdateInsectCommandModel),
            Patch = typeof(PatchInsectCommandModel),
            Delete = typeof(DeleteInsectCommandModel)
        )
    ]
    [
        GenericMediatREntity
        (
            QueryList = typeof(GetInsectListQueryModel),
            QueryById = typeof(GetInsectByIdQueryModel),
            Create = typeof(CreateInsectCommandModel),
            Update = typeof(UpdateInsectCommandModel),
            Patch = typeof(PatchInsectCommandModel),
            Delete = typeof(DeleteInsectCommandModel)
        )
    ]
    public class Insect : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}