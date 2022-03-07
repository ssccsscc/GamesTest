using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }
        public override IQueryable<Game> FindAll()
        {
            return this.RepositoryContext.Set<Game>().Include(x => x.Company).Include(x => x.Generes).AsNoTracking();
        }
        public override IQueryable<Game> FindByCondition(Expression<Func<Game, bool>> expression)
        {
            return this.RepositoryContext.Set<Game>().Include(x => x.Company).Include(x => x.Generes).Where(expression);
        }
    }
}
