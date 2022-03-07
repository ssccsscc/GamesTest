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
    public class DeleteGenereGameCommand : IRequest<GameModel>
    {
        public int _gameId { get; }
        public int _genereId { get; }
        public DeleteGenereGameCommand(int gameId, int genereId)
        {
            this._gameId = gameId;
            this._genereId = genereId;
        }

        public class DeleteGenereGameCommandHandler : IRequestHandler<DeleteGenereGameCommand, GameModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public DeleteGenereGameCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(DeleteGenereGameCommand request, CancellationToken cancellationToken)
            {
                var Game = _repository.Game.FindByCondition(x => x.Id == request._gameId).FirstOrDefault();

                if (Game == null)
                {
                    throw new LogicExceptionNotFound("Игра не найдена");
                }

                var Genere = _repository.Genere.FindByCondition(x => x.Id == request._genereId).FirstOrDefault();

                if (Genere == null)
                {
                    throw new LogicExceptionNotFound("Жанр не найден");
                }

                if (!Game.Generes.Any(x=>x.Id == Genere.Id))
                {
                    throw new LogicExceptionOtherError("Такого жанра нету у игры");
                }

                Game.Generes.RemoveAll(x => x.Id == Genere.Id);

                _repository.Game.Update(Game);
                _repository.SaveChanges();

                Game = _repository.Game.FindByCondition(x => x.Id == Game.Id).FirstOrDefault();

                return _mapper.Map<GameModel>(Game);
            }
        }
    }
}
