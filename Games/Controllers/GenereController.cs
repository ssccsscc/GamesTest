using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Model;
using AutoMapper;
using MediatR;
using Logic.Commands.Genere;
using Games.Model;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenereController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GenereController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all generes.
        /// </summary>
        /// <returns>Array of Genere</returns>
        /// <response code="200">Returns array of Genere</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<GenereDTO>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<List<GenereDTO>> GetAll()
        {
            var query = new GetAllGenereQuery();
            var response = await _mediator.Send(query);
            return _mapper.Map<List<GenereDTO>>(response);
        }
        /// <summary>
        /// Gets a genere by id.
        /// </summary>
        /// <param name="id">Genere id</param>
        /// <returns>Genere</returns>
        /// <response code="200">Returns Genere</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GenereDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GenereDTO> Get(int id)
        {
            var query = new GetGenereQuery(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<GenereDTO>(response);
        }
        /// <summary>
        /// Creates a new genere.
        /// </summary>
        /// <returns>A newly created genere</returns>
        /// <response code="200">Returns the newly created genere</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GenereDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GenereDTO> Create(GenereDTO_Create model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new CreateGenereCommand(_mapper.Map<GenereModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<GenereDTO>(response);
        }
        /// <summary>
        /// Updates a genere.
        /// </summary>
        /// <returns>Updated genere</returns>
        /// <response code="200">Genere</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GenereDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GenereDTO> Update(GenereDTO model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new UpdateGenereCommand(_mapper.Map<GenereModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<GenereDTO>(response);
        }
        /// <summary>
        /// Deletes a genere.
        /// </summary>
        /// <param name="id">Genere id</param>
        /// <returns>Deleted Genere</returns>
        /// <response code="200">Returns the deleted genere</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GenereDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GenereDTO> Delete(int id)
        {
            var query = new DeleteGenereCommand(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<GenereDTO>(response);
        }
    }
}
