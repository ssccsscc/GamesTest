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
    public class CreateCompanyCommand : IRequest<CompanyModel>
    {
        public CompanyModel Model { get; }
        public CreateCompanyCommand(CompanyModel model)
        {
            this.Model = model;
        }

        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public CreateCompanyCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CompanyModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                var Company = _mapper.Map<DataAccess.Entities.Company>(request.Model);

                Company.Id = 0;

                _repository.Company.Create(Company);
                _repository.SaveChanges();

                return _mapper.Map<CompanyModel>(Company);
            }
        }
    }
}
