using NetCore.Application.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.News
{
   public class NewsTagViewModel
    {
        public int Id { set; get; }
        public int NewsId { set; get; }
         public string TagId { set; get; }
 
        public  NewsViewModel News { set; get; }

        public TagViewModel Tag { set; get; }
    }
}
