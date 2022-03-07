using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Model;
using AutoMapper;
using MediatR;
using Logic.Commands.Game;
using Games.Model;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GameController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns>Array of Game</returns>
        /// <response code="200">Returns array of Game</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<GameDTO>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<List<GameDTO>> GetAll()
        {
            var query = new GetAllGameQuery();
            var response = await _mediator.Send(query);
            return _mapper.Map<List<GameDTO>>(response);
        }
        /// <summary>
        /// Gets a game by id.
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns>Game</returns>
        /// <response code="200">Returns Game</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> Get(int id)
        {
            var query = new GetGameQuery(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <returns>A newly created game</returns>
        /// <response code="200">Returns the newly created game</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> Create(GameDTO_Create model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new CreateGameCommand(_mapper.Map<GameModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
        /// <summary>
        /// Updates a game.
        /// </summary>
        /// <returns>Updated game</returns>
        /// <response code="200">Game</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> Update(GameDTO_Update model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new UpdateGameCommand(_mapper.Map<GameModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
        /// <summary>
        /// Deletes a game.
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns>Deleted Game</returns>
        /// <response code="200">Returns the deleted game</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> Delete(int id)
        {
            var query = new DeleteGameCommand(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
        /// <summary>
        /// Add genere to a game.
        /// </summary>
        /// <param name="id">Game id</param>
        /// <param name="genereId">Genere id</param>
        /// <returns>Updated Game</returns>
        /// <response code="200">Returns updated game</response>
        /// <response code="400">Error</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpPost("{id}/Genere/{genereId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> AddGenere(int id, int genereId)
        {
            var query = new AddGenereGameCommand(id, genereId);
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
        /// <summary>
        /// Remove genere from a game.
        /// </summary>
        /// <param name="id">Game id</param>
        /// <param name="genereId">Genere id</param>
        /// <returns>Updated Game</returns>
        /// <response code="200">Returns updated game</response>
        /// <response code="400">Error</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpDelete("{id}/Genere/{genereId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GameDTO), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<GameDTO> DeleteGenere(int id, int genereId)
        {
            var query = new DeleteGenereGameCommand(id, genereId);
            var response = await _mediator.Send(query);
            return _mapper.Map<GameDTO>(response);
        }
    }
}
