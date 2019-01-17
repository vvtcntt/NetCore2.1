using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Product;
using NetCore.Data.Entites;
using NetCore.Data.Entities;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using NetCore.Utilities.Constants;
using NetCore.Utilities.Dtos;
using NetCore.Utilities.Helpers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
        private IProductQuantityRepository _productQuantityRepository;
        private IProductImageRepository _productImageRepository;
        private IWholePriceRepository _wholePriceRepository;
        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, 
            ITagRepository tagRepository, IUnitOfWork unitOfWork, IProductQuantityRepository productQuantityRepository, 
            IProductImageRepository productImageRepository, IWholePriceRepository wholePriceRepository)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _productQuantityRepository = productQuantityRepository;
            _productImageRepository = productImageRepository;
            _wholePriceRepository = wholePriceRepository;
        }
        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }
        public PagedResult<ProductViewModel> GetAllPaging(int? categogyId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll();
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
              

                //_productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.ProductId == productVm.Id).ToList());
                //_tagRepository.RemoveMultiple(_tagRepository.FindAll(x => x.Id == "1").ToList());
                //_unitOfWork.Commit();

                //string[] tags = productVm.Tag.Split(',');
                //foreach (var item in tags)
                //{
                //    var tagId = TextHelper.ToUnsignString(item);
                //    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                //    {
                //        Tag tag = new Tag
                //        {
                //            Id = tagId,
                //            Name = item,
                //            Type = CommonConstants.ProductTag
                //        };
                //        _tagRepository.Add(tag);
               
                //        ProductTag productTag = new ProductTag
                //        {
                //            TagId = tagId,
                //            ProductId=productVm.Id
                //        };

                //        _productTagRepository.Add(productTag);
                //    }
                //}
                 
            }
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            product.Tag = productVm.Tag;
            //foreach (var productTag in productTags)
            //{
            //    product.ProductTags.Add(productTag);
            //}
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

        public void ImportExcel(string filePath, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();
                    product.CategoryId = categoryId;

                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    product.Code = workSheet.Cells[i, 2].Value.ToString();
                    product.Description = workSheet.Cells[i, 3].Value.ToString();
                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                    product.Price = price;
                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var priceSale);
                    product.PriceSale = priceSale;
                    product.Content = workSheet.Cells[i, 6].Value.ToString();
                    product.SeoTitle = workSheet.Cells[i, 7].Value.ToString();
                    product.SeoKeyWords = workSheet.Cells[i, 8].Value.ToString();
                    product.SeoDescription = workSheet.Cells[i, 9].Value.ToString();  
                    product.SeoAlias=  TextHelper.ToUnsignString(workSheet.Cells[i, 1].Value.ToString());
                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                    product.HomeFlag = homeFlag;
                    product.Status = Status.Ready;
                    _productRepository.Add(product);
                }
            }
        }
        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productQuantityRepository.RemoveMultiple(_productQuantityRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
        }

        List<ProductQuantityViewModel> IProductService.GetQuantities(int productId)
        {

            return _productQuantityRepository.FindAll(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _productImageRepository.FindAll(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>().ToList();
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.RemoveMultiple(_productImageRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage()
                {
                    Image = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }

        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrice)
        {
            _wholePriceRepository.RemoveMultiple(_wholePriceRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach(var item in wholePrice)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId=productId,
                    FromQuantity=item.FromQuantity,
                    ToQuantity=item.ToQuantity,
                    Price=item.Price
                });

            }
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            return _wholePriceRepository.FindAll(x => x.ProductId == productId).ProjectTo<WholePriceViewModel>().ToList();
        }

        public void UpdateFast(int id,decimal? price, decimal? priceSale,int?sortOrd, int? active, bool? productSale, bool? homeFlag)
        {
            var product = _productRepository.FindById(id);
            bool activeM = true;
            if(price.HasValue)
            {
                product.Price = price.Value;
                _productRepository.Update(product);
            }
            if (priceSale.HasValue)
            {
                product.PriceSale = priceSale.Value;
                _productRepository.Update(product);
            }
            if (sortOrd.HasValue)
            {
                product.SortOrder = sortOrd.Value;
                _productRepository.Update(product);
            }
            if (active.HasValue)
            {
              if(product.Active==Active.Active)
                {
                    product.Active = Active.IsActive;
                }
              else
                {
                    product.Active = Active.Active;
                }
                _productRepository.Update(product);
            }
            if (productSale.HasValue)
            {
                if (product.ProductSale ==true)
                {
                    product.ProductSale = false;
                }
                else
                {
                    product.ProductSale = true;
                }
                _productRepository.Update(product);
            }
            if (homeFlag.HasValue)
            {
                if (product.HomeFlag == true)
                {
                    product.HomeFlag = false;
                }
                else
                {
                    product.HomeFlag = true;
                }
                _productRepository.Update(product);
            }
        }
    }
}