using AutoMapper;
using NetCore.Application.ViewModels.Product;
using NetCore.Application.ViewModels.System;
using NetCore.Data.Entites;
using NetCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Bill, BillViewModel>().MaxDepth(2);
            CreateMap<BillDetail, BillDetailViewModel>().MaxDepth(2);
            CreateMap<Color, ColorViewModel>().MaxDepth(2);
            CreateMap<Size, SizeViewModel>().MaxDepth(2);
            CreateMap<ProductQuantity, ProductQuantityViewModel>().MaxDepth(2);
            CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);

        }
    }
}
