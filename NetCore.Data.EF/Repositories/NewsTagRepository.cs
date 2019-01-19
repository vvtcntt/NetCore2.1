using NetCore.Data.Entities;
using NetCore.Data.IRepositories;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Repositories
{
    public class NewsTagRepository : EFRepository<NewsTag, int>, INewsTagRepository
    {
        public NewsTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
