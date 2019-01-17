using NetCore.Data.Entites;
using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public int? ParentId { get; set; }        
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public bool? HomeFlag { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
   
        public int LanguageId { set; get; }
        public Active Active { set; get; }
        public int SortOrder { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeyWords { set; get; }
        public string SeoDescription { set; get; }
        public  ICollection<ProductViewModel> Products { set; get; }
    }
}
