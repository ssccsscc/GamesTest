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
    public class GetAllCompanyQuery : IRequest<List<CompanyModel>>
    {
        public GetAllCompanyQuery()
        {
        }

        public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, List<CompanyModel>>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public GetAllCompanyQueryHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<CompanyModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
            {
                var Companys = _repository.Company.FindAll();

                return _mapper.Map<List<CompanyModel>>(Companys);
            }
        }
    }
}
