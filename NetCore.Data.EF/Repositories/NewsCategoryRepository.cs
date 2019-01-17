using NetCore.Data.Entites;
using NetCore.Data.IRepositories;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Repositories
{
    public class NewsCategoryRepository : EFRepository<NewsCategory, int>, INewsCategoryRepository
    {
        public NewsCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
