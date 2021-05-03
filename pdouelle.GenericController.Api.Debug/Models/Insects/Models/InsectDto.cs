using System;
using pdouelle.Entity;

namespace pdouelle.GenericController.Api.Debug.Models.Insects.Models
{
    public class InsectDto : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}