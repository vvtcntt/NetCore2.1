using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Product;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Application.Implementation
{
    public class ProductService : IProductService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }
        public PagedResult<ProductViewModel> GetAllPaging(int? categogyId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(p => p.Status == Data.Enums.Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (categogyId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categogyId.Value);
            }
            int totalRow = query.Count();
            query = query.OrderByDescending(p => p.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = query.ProjectTo<ProductViewModel>().ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

    }
}