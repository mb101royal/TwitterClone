using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Core.Entities;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.Business.Repositories.Implements
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(TwitterCloneDbContext context) : base(context)
        {
        }
    }
}
