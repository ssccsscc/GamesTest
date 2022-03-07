using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _repoContext;
        private ICompanyRepository _Company;
        private IGenereRepository _Genere;
        private IGameRepository _Game;
        public ICompanyRepository Company
        {
            get
            {
                if (_Company == null)
                {
                    _Company = new CompanyRepository(_repoContext);
                }
                return _Company;
            }
        }
        public IGenereRepository Genere
        {
            get
            {
                if (_Genere == null)
                {
                    _Genere = new GenereRepository(_repoContext);
                }
                return _Genere;
            }
        }
        public IGameRepository Game
        {
            get
            {
                if (_Game == null)
                {
                    _Game = new GameRepository(_repoContext);
                }
                return _Game;
            }
        }
        public RepositoryWrapper(DatabaseContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void SaveChanges()
        {
            _repoContext.SaveChanges();
        }
    }
}
