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
                ConstructUsing(x => new ProductCategory(x.Name, x.ParentId, x.Description, x.Content, x.Image, x.Icon, x.HomeFlag, x.SortOrder, x.DateCreated, x.DateModified, x.SeoAlias, x.SeoAlias, x.SeoKeyWords, x.SeoDescription, x.LanguageId, x.Active));
            CreateMap<ProductViewModel, Product>().
                ConstructUsing(x => new Product(
                    x.Name, x.CategoryId, x.Code, x.Description,
                    x.Info, x.Content, x.Parameter, x.ImageDetail,
                    x.ImageThumbs, x.Price, x.PriceSale, x.NotePrice,
                    x.Warranty, x.Age, x.Sale, x.Size,
                    x.Vat, x.New, x.ProductSale, x.HomeFlag,
                    x.SortOrder, x.DateCreated, x.DateModified,x.SeoTitle, 
                    x.SeoKeyWords, x.SeoDescription, x.SeoAlias,x.Active, x.Status,
                    x.LanguageId, x.ViewCount, x.Tag));
            CreateMap<AppUserViewModel, AppUser>()
           .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
           c.Email, c.PhoneNumber, c.Avatar, c.Active));
            CreateMap<FunctionViewModel, Function>()
           .ConstructUsing(c => new Function(c.Id,c.Name,c.URL,c.ParentId,c.IconCss,c.SortOrder));
            CreateMap<BillViewModel, Bill>().ConstructUsing(c => new Bill(c.Id,c.CustomerName, c.CustomerAddress, c.CustomerMobile, c.CustomerMessage, c.BillStatus, c.PaymentMethod,c.Active, c.Status,c.CustomerId));
            CreateMap<BillDetailViewModel, BillDetail>().ConstructUsing(c => new BillDetail(c.Id,c.ProductId,c.Quantity,c.Price,c.ColorId,c.SizeId));
            CreateMap<ConfigViewModel, Config>().ConstructUsing(c => new Config(c.Id,c.Name,c.Address,c.Mobile,c.Hotline,c.Fax,c.Email,c.Slogan,c.ImageLogo,c.ImageFavicon,c.Content,c.UserMail,c.PassMail,c.Analytics,c.WebMasterTool,c.AppFacebook,c.CodeChat,c.FanpageFacebook,c.FanpageGoogle,c.FanpageYoutube,c.GeoMeta,c.Color,c.Host,c.Port,c.TimeOut,c.Coppy,c.Status,c.TitleMeta,c.KeywordMeta,c.DescriptionMeta));
        }
    }
}