using NetCore.Data.Entities;
using NetCore.Data.IRepositories;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Repositories
{
    public class WholePriceRepository : EFRepository<WholePrice, int>, IWholePriceRepository
    {
        public WholePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
