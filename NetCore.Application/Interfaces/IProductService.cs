using NetCore.Application.ViewModels.Product;
using NetCore.Data.Enums;
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
        void UpdateFast(int id,decimal?price, decimal?priceSale,int?sortOrd,int?active,bool?productSale,bool?homeFlag);
        void AddImages(int productId, string[] Images);
        List<ProductImageViewModel> GetImages(int productId);
        void AddWholePrice(int productId, List<WholePriceViewModel> wholePrice);
        List<WholePriceViewModel> GetWholePrices (int productId);
    }
}
