using NetCore.Data.Entites;
using NetCore.Data.IRepositories;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Repositories
{
    public class ColorRepository : EFRepository<Color, int>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
