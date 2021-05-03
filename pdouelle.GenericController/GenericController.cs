using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using pdouelle.Entity;
using pdouelle.GenericMediatR.Models.Generics.Models.Commands.Create;
using pdouelle.GenericMediatR.Models.Generics.Models.Commands.Delete;
using pdouelle.GenericMediatR.Models.Generics.Models.Commands.Patch;
using pdouelle.GenericMediatR.Models.Generics.Models.Commands.Save;
using pdouelle.GenericMediatR.Models.Generics.Models.Queries.IdQuery;
using pdouelle.GenericMediatR.Models.Generics.Models.Queries.ListQuery;

namespace pdouelle.GenericController
{
    [Produces("application/json")]
    [Route("[controller]")]
    [GenericControllerName]
    public class
        GenericController<TEntity, TDto, TQueryList, TQueryById, TCreate, TUpdate, TPatch, TDelete> : ControllerBase
        where TEntity : IEntity, new()
        where TDto : IEntity
        where TQueryById : IEntity, new()
        where TPatch : class, new()
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        public GenericController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public virtual async Task<IActionResult> GetList([FromQuery] TQueryList request)
        {
            IEnumerable<TEntity> response = await Mediator.Send(new ListQueryModel<TEntity, TQueryList>
            {
                Request = request
            });

            var mappedResponse = Mapper.Map<IEnumerable<TDto>>(response);

            return Ok(mappedResponse);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id, [FromQuery] TQueryById request)
        {
            TEntity response = await Mediator.Send(new IdQueryModel<TEntity, TQueryById>
            {
                Request = request
            });

            var mappedResponse = Mapper.Map<TDto>(response);

            return Ok(mappedResponse);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TCreate request)
        {
            var entity = Mapper.Map<TEntity>(request);

            await Mediator.Send(new CreateCommandModel<TEntity, TCreate>
            {
                Request = request
            });

            await Mediator.Send(new SaveCommandModel<TEntity>());

            var mappedResponse = Mapper.Map<TDto>(entity);

            return CreatedAtAction(nameof(GetById), new {id = mappedResponse.Id}, mappedResponse);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, [FromBody] TUpdate request)
        {
            TEntity entity = await Mediator.Send(new IdQueryModel<TEntity, TQueryById>
            {
                Request = new TQueryById {Id = id}
            });

            if (entity == null)
                return NotFound();

            Mapper.Map(request, entity);

            await Mediator.Send(new SaveCommandModel<TEntity>());

            var mappedResponse = Mapper.Map<TDto>(entity);

            return Ok(mappedResponse);
        }

        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}")]
        public virtual async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<TPatch> patchDocument)
        {
            TEntity entity = await Mediator.Send(new IdQueryModel<TEntity, TQueryById>
            {
                Request = new TQueryById {Id = id}
            });

            if (entity == null)
                return NotFound();

            var request = new TPatch();
            patchDocument.ApplyTo(request);

            TEntity response = await Mediator.Send(new PatchCommandModel<TEntity, TPatch>
            {
                Entity = entity,
                Request = request
            });

            await Mediator.Send(new SaveCommandModel<TEntity>());

            var mappedResponse = Mapper.Map<TDto>(entity);

            return Ok(mappedResponse);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id, [FromQuery] TDelete request)
        {
            TEntity entity = await Mediator.Send(new IdQueryModel<TEntity, TQueryById>
            {
                Request = new TQueryById {Id = id}
            });

            if (entity == null)
                return NotFound();

            await Mediator.Send(new DeleteCommandModel<TEntity, TDelete>
            {
                Entity = entity,
                Request = request
            });

            await Mediator.Send(new SaveCommandModel<TEntity>());

            return NoContent();
        }
    }
}