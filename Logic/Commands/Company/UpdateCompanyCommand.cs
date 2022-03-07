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
    public class UpdateCompanyCommand : IRequest<CompanyModel>
    {
        public CompanyModel Model { get; }
        public UpdateCompanyCommand(CompanyModel model)
        {
            this.Model = model;
        }

        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, CompanyModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public UpdateCompanyCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CompanyModel> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                var Company = _mapper.Map<DataAccess.Entities.Company>(request.Model);

                if (!_repository.Company.FindByCondition(x => x.Id == request.Model.Id).Any())
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Company.Update(Company);
                _repository.SaveChanges();

                return _mapper.Map<CompanyModel>(Company);
            }
        }
    }
}
