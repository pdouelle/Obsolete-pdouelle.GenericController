using System;
using pdouelle.Entity;

namespace pdouelle.GenericController.Api.Debug.Models.Animals.Models.Queries.GetAnimalById
{
    public class GetAnimalByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}