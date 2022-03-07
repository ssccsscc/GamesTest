using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
