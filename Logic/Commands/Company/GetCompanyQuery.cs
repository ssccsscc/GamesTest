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

namespace Logic.Commands.Company
{
    public class GetCompanyQuery : IRequest<CompanyModel>
    {
        public int _id { get; }
        public GetCompanyQuery(int id)
        {
            this._id = id;
        }

        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetCompanyQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CompanyModel> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                var Company = _repository.Company.FindByCondition(x => x.Id == request._id).FirstOrDefault();
                if (Company == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                return _mapper.Map<CompanyModel>(Company);
            }
        }
    }
}
