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
    public class DeleteCompanyCommand : IRequest<CompanyModel>
    {
        public int _id { get; }
        public DeleteCompanyCommand(int id)
        {
            this._id = id;
        }

        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, CompanyModel>
        {
            private readonly IRepositoryWrapper _repository;
            private readonly IMapper _mapper;

            public DeleteCompanyCommandHandler(IRepositoryWrapper repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CompanyModel> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {

                var toDelete =_repository.Company.FindByCondition(x=> x.Id == request._id).FirstOrDefault();

                if (toDelete == null)
                {
                    throw new LogicExceptionNotFound("Не найден id");
                }

                _repository.Company.Delete(toDelete);
                _repository.SaveChanges();

                return _mapper.Map<CompanyModel>(toDelete);
            }
        }
    }
}
