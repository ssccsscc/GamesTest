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
    public class GetAllGameQuery : IRequest<List<GameModel>>
    {
        public GetAllGameQuery()
        {
        }

        public class GetAllGameQueryHandler : IRequestHandler<GetAllGameQuery, List<GameModel>>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetAllGameQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GameModel>> Handle(GetAllGameQuery request, CancellationToken cancellationToken)
            {
                var Games = _repository.Game.FindAll();

                return _mapper.Map<List<GameModel>>(Games);
            }
        }
    }
}
