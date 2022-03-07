using AutoMapper;
using DataAccess.Repository;
using Logic.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Logic.Commands.Genere
{
    public class CreateGenereCommand : IRequest<GenereModel>
    {
        public GenereModel Model { get; }
        public CreateGenereCommand(GenereModel model)
        {
            this.Model = model;
        }

        public class AddGenereCommandHandler : IRequestHandler<CreateGenereCommand, GenereModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public AddGenereCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GenereModel> Handle(CreateGenereCommand request, CancellationToken cancellationToken)
            {
                var genere = _mapper.Map<DataAccess.Entities.Genere>(request.Model);

                genere.Id = 0;

                _repository.Genere.Create(genere);
                _repository.SaveChanges();

                return _mapper.Map<GenereModel>(genere);
            }
        }
    }
}
