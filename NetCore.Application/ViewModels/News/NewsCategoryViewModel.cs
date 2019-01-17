using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.News
{
    public class NewsCategoryViewModel
    {
        public int Id { get; set; }
        public Active Active { set; get; }
        public string Name { set; get; }

        public string Alias { set; get; }

        public string Description { set; get; }
        public virtual ICollection<NewsViewModel> News { set; get; }
        public int SortOrder { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeyWords { set; get; }
        public string SeoDescription { set; get; }
    }
}
