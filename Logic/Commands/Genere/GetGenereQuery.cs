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
    public class GetGenereQuery : IRequest<GenereModel>
    {
        public int _id { get; }
        public GetGenereQuery(int id)
        {
            this._id = id;
        }

        public class GetGenereQueryHandler : IRequestHandler<GetGenereQuery, GenereModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetGenereQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GenereModel> Handle(GetGenereQuery request, CancellationToken cancellationToken)
            {
                var genere = _repository.Genere.FindByCondition(x => x.Id == request._id).FirstOrDefault();
                if (genere == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                return _mapper.Map<GenereModel>(genere);
            }
        }
    }

    //public class GetAllNinjasQueryHandler :
    //IRequestHandler<GetAllNinjasQuery, IEnumerable<NinjaDTO>>
    //{
    //    private readonly IUnitOfWork _repository;
    //    private readonly IMapper _mapper;

    //    public GetAllNinjasQueryHandler(
    //            IUnitOfWork repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }

    //    public async Task<IEnumerable<NinjaDTO>> Handle(
    //            GetAllNinjasQuery request, CancellationToken cancellationToken)
    //    {
    //        var entities = await Task.FromResult(_repository.Ninjas.GetAll());
    //        return _mapper.Map<IEnumerable<NinjaDTO>>(entities);
    //    }
    //}
}
