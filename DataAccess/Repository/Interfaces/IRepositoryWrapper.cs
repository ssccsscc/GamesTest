using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        IGenereRepository Genere { get; }
        IGameRepository Game { get; }
        void SaveChanges();
    }
}
