using NetCore.Application.ViewModels.Common;
using NetCore.Application.ViewModels.Image;
using NetCore.Application.ViewModels.News;
using NetCore.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class HomeViewModel
    {
        public List<NewsViewModel> LastestBlogs { set; get; }
        public List<ImageViewModel> HomeSlides { set; get; }
        public List<ProductViewModel> HotProducts { set; get; }
        public List<ProductViewModel> TopSellProducts { set; get; }
        public List<ProductCategoryViewModel> HomeCategories { set; get; }
        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}
