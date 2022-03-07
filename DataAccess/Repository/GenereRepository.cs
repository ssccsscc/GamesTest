using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class GenereRepository : RepositoryBase<Genere>, IGenereRepository
    {
        public GenereRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
