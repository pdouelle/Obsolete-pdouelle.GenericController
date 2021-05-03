using System;
using pdouelle.Entity;

namespace pdouelle.GenericController.Api.Debug.Models.Insects.Models.Queries.GetInsectById
{
    public class GetInsectByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}