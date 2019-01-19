using NetCore.Data.Entites;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.IRepositories
{
   public interface IImageRepository : IRepository<Image, int>
    {
    }
}
