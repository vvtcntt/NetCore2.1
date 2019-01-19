using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.News
{
   public class NewsViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string Name { set; get; }
        public int CategoryId { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public int ViewCount { set; get; }
        public bool ViewHomes { set; get; }
        public string Image { set; get; }
        public NewsCategoryViewModel NewsCategories { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeyWords { set; get; }
        public string SeoDescription { set; get; }
        public string Tag { set; get; }

        public int SortOrder { set; get; }
        public Active Active { set; get; }
        public NewsTagViewModel NewsTags { set; get; }
    }
}
