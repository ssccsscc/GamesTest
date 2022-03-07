using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Model;
using AutoMapper;
using MediatR;
using Logic.Commands.Company;
using Games.Model;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompanyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <returns>Array of Company</returns>
        /// <response code="200">Returns array of Company</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanyDTO>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<List<CompanyDTO>> GetAll()
        {
            var query = new GetAllCompanyQuery();
            var response = await _mediator.Send(query);
            return _mapper.Map<List<CompanyDTO>>(response);
        }
        /// <summary>
        /// Gets a company by id.
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns>Company</returns>
        /// <response code="200">Returns Company</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<CompanyDTO> Get(int id)
        {
            var query = new GetCompanyQuery(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<CompanyDTO>(response);
        }
        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <returns>A newly created company</returns>
        /// <response code="200">Returns the newly created company</response>
        /// <response code="400">Validation failed</response>
        /// <response code="500">Service unavailable</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<CompanyDTO> Create(CompanyDTO_Create model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new CreateCompanyCommand(_mapper.Map<CompanyModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<CompanyDTO>(response);
        }
        /// <summary>
        /// Updates a company.
        /// </summary>
        /// <returns>Updated company</returns>
        /// <response code="200">Company</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<CompanyDTO> Update(CompanyDTO model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var query = new UpdateCompanyCommand(_mapper.Map<CompanyModel>(model));
            var response = await _mediator.Send(query);
            return _mapper.Map<CompanyDTO>(response);
        }
        /// <summary>
        /// Deletes a company.
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns>Deleted Company</returns>
        /// <response code="200">Returns the deleted company</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Service unavailable</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CompanyDTO), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public async Task<CompanyDTO> Delete(int id)
        {
            var query = new DeleteCompanyCommand(id);
            var response = await _mediator.Send(query);
            return _mapper.Map<CompanyDTO>(response);
        }
    }
}
