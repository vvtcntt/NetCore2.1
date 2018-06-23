using NetCore.Data.Entites;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.iRepositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory,int>
    {
      
    }
}
