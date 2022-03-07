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
    public class GetAllGenereQuery : IRequest<List<GenereModel>>
    {
        public GetAllGenereQuery()
        {
        }

        public class GetAllGenereQueryHandler : IRequestHandler<GetAllGenereQuery, List<GenereModel>>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetAllGenereQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GenereModel>> Handle(GetAllGenereQuery request, CancellationToken cancellationToken)
            {
                var generes = _repository.Genere.FindAll();

                return _mapper.Map<List<GenereModel>>(generes);
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
