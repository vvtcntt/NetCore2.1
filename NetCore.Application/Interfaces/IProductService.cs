using NetCore.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
   public interface IProductService:IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
