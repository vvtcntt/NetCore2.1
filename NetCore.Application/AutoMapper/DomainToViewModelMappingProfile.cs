using AutoMapper;
using NetCore.Application.ViewModels.Product;
using NetCore.Application.ViewModels.System;
using NetCore.Data.Entites;
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
        }
    }
}
