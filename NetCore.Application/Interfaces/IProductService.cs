using NetCore.Application.ViewModels.Product;
using NetCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
   public interface IProductService:IDisposable
    {
        List<ProductViewModel> GetAll();
        PagedResult<ProductViewModel> GetAllPaging(int? categoryId,string keyword,int page, int pageSize);
        ProductViewModel GetById(int id);
        ProductViewModel Add(ProductViewModel productVm);
        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);
        List<ProductQuantityViewModel> GetQuantities(int productId);
        void delete(int id);
        void Save();
        void ImportExcel(string filePath, int categoryId);
        void Update(ProductViewModel productVm);
    }
}
