using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Product;
using NetCore.Data.Entites;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using NetCore.Utilities.Constants;
using NetCore.Utilities.Dtos;
using NetCore.Utilities.Helpers;
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

        private IProductTagRepository _productTagRepository;
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
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
        public ProductViewModel GetById(int id)
        {
            return Mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

 
        public ProductViewModel Add(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();
            if (!string.IsNullOrEmpty(productVm.Tag))
            {
                string[] tags = productVm.Tag.Split(',');
                foreach (var item in tags)
                {
                    var tagId = TextHelper.ToUnsignString(item);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                        ProductTag productTag = new ProductTag
                        {
                            ProductId = productVm.Id,
                            TagId = tagId
                        };
                        productTags.Add(productTag);
                    }
                }
            }
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Add(product);
            return productVm;
        }

        public void Update(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();

            if (!string.IsNullOrEmpty(productVm.Tag))
            {
                string[] tags = productVm.Tag.Split(',');
                foreach (var item in tags)
                {
                    var tagId = TextHelper.ToUnsignString(item);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                        _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productVm.Id).ToList());
                        ProductTag productTag = new ProductTag
                        {
                            TagId = tagId
                        };

                        _productTagRepository.Add(productTag);
                    }
                }
            }
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Update(product);
        }

        public void delete(int id)
        {
            _productRepository.Remove(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

       

    }
}