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
    public class DeleteGenereCommand : IRequest<GenereModel>
    {
        public int _id { get; }
        public DeleteGenereCommand(int id)
        {
            this._id = id;
        }

        public class DeleteGenereCommandHandler : IRequestHandler<DeleteGenereCommand, GenereModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public DeleteGenereCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GenereModel> Handle(DeleteGenereCommand request, CancellationToken cancellationToken)
            {

                var toDelete =_repository.Genere.FindByCondition(x=> x.Id == request._id).FirstOrDefault();

                if (toDelete == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Genere.Delete(toDelete);
                _repository.SaveChanges();

                return _mapper.Map<GenereModel>(toDelete);
            }
        }
    }
}
