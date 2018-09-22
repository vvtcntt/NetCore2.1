using AutoMapper;
using NetCore.Application.ViewModels.Product;
using NetCore.Application.ViewModels.System;
using NetCore.Data.Entites;
using System;

namespace NetCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().
                ConstructUsing(x => new ProductCategory(x.Name, x.ParentId, x.Description, x.Content, x.Image, x.Icon, x.HomeFlag, x.SortOrder, x.DateCreated, x.DateModified, x.SeoAlias, x.SeoAlias, x.SeoKeyWords, x.SeoDescription, x.LanguageId, x.Status));
            CreateMap<ProductViewModel, Product>().
                ConstructUsing(x => new Product(
                    x.Name, x.CategoryId, x.Code, x.Description,
                    x.Info, x.Content, x.Parameter, x.ImageDetail,
                    x.ImageThumbs, x.Price, x.PriceSale, x.NotePrice,
                    x.Warranty, x.Age, x.Sale, x.Size,
                    x.Vat, x.New, x.ProductSale, x.HomeFlag,
                    x.SortOrder, x.DateCreated, x.DateModified, x.SeoAlias,
                    x.SeoKeyWords, x.SeoDescription, x.SeoAlias, x.Status,
                    x.LanguageId, x.ViewCount, x.Active, x.Tag));
            CreateMap<AppUserViewModel, AppUser>()
           .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
           c.Email, c.PhoneNumber, c.Avatar, c.Status));
            CreateMap<FunctionViewModel, Function>()
           .ConstructUsing(c => new Function(c.Id,c.Name,c.URL,c.ParentId,c.IconCss,c.SortOrder));
            CreateMap<BillViewModel, Bill>().ConstructUsing(c => new Bill(c.Id,c.CustomerName, c.CustomerAddress, c.CustomerMobile, c.CustomerMessage, c.BillStatus, c.PaymentMethod, c.Status,c.CustomerId));
            CreateMap<BillDetailViewModel, BillDetail>().ConstructUsing(c => new BillDetail(c.Id,c.ProductId,c.Quantity,c.Price,c.ColorId,c.SizeId));
        }
    }
}