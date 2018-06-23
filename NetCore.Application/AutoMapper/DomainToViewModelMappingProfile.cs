using AutoMapper;
using NetCore.Application.ViewModels.Product;
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
           

        }
    }
}
