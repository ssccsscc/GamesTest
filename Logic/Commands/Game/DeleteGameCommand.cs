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

namespace Logic.Commands.Game
{
    public class DeleteGameCommand : IRequest<GameModel>
    {
        public int _id { get; }
        public DeleteGameCommand(int id)
        {
            this._id = id;
        }

        public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, GameModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public DeleteGameCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {

                var toDelete =_repository.Game.FindByCondition(x=> x.Id == request._id).FirstOrDefault();

                if (toDelete == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Game.Delete(toDelete);
                _repository.SaveChanges();

                return _mapper.Map<GameModel>(toDelete);
            }
        }
    }
}
