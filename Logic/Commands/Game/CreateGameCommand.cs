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
    public class CreateGameCommand : IRequest<GameModel>
    {
        public GameModel Model { get; }
        public CreateGameCommand(GameModel model)
        {
            this.Model = model;
        }

        public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public CreateGameCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                var Game = _mapper.Map<DataAccess.Entities.Game>(request.Model);

                Game.Id = 0;

                _repository.Game.Create(Game);
                _repository.SaveChanges();

                Game = _repository.Game.FindByCondition(x => x.Id == Game.Id).FirstOrDefault();

                return _mapper.Map<GameModel>(Game);
            }
        }
    }
}
