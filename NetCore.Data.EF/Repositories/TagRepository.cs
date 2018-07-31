using NetCore.Data.Entites;
using NetCore.Data.IRepositories;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
