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
    public class GetGameQuery : IRequest<GameModel>
    {
        public int _id { get; }
        public GetGameQuery(int id)
        {
            this._id = id;
        }

        public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetGameQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(GetGameQuery request, CancellationToken cancellationToken)
            {
                var Game = _repository.Game.FindByCondition(x => x.Id == request._id).FirstOrDefault();
                if (Game == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                return _mapper.Map<GameModel>(Game);
            }
        }
    }
}
