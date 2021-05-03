using System;
using pdouelle.Entity;

namespace pdouelle.GenericController.Api.Debug.Models.Animals.Models
{
    public class AnimalDto : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}