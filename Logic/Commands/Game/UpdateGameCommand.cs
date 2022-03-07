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
    public class UpdateGameCommand : IRequest<GameModel>
    {
        public GameModel Model { get; }
        public UpdateGameCommand(GameModel model)
        {
            this.Model = model;
        }

        public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public UpdateGameCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                var Game = _mapper.Map<DataAccess.Entities.Game>(request.Model);

                if (!_repository.Game.FindByCondition(x=>x.Id == request.Model.Id).Any())
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Game.Update(Game);
                _repository.SaveChanges();

                Game = _repository.Game.FindByCondition(x => x.Id == Game.Id).FirstOrDefault();

                return _mapper.Map<GameModel>(Game);
            }
        }
    }
}
