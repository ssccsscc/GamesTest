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
    public class UpdateGenereCommand : IRequest<GenereModel>
    {
        public GenereModel Model { get; }
        public UpdateGenereCommand(GenereModel model)
        {
            this.Model = model;
        }

        public class UpdateGenereCommandHandler : IRequestHandler<UpdateGenereCommand, GenereModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public UpdateGenereCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GenereModel> Handle(UpdateGenereCommand request, CancellationToken cancellationToken)
            {
                var genere = _mapper.Map<DataAccess.Entities.Genere>(request.Model);

                if (!_repository.Genere.FindByCondition(x => x.Id == request.Model.Id).Any())
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Genere.Update(genere);
                _repository.SaveChanges();

                return _mapper.Map<GenereModel>(genere);
            }
        }
    }
}
