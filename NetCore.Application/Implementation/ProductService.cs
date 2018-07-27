using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Product;
using NetCore.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Application.Implementation
{
    public class ProductService : IProductService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x=>x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }
    }
}
