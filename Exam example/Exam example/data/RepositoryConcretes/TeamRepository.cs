using core.Model;
using core.RepositoryAbstracts;
using data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.RepositoryConcretes
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
