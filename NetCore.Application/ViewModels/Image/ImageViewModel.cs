using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.Image
{
    public class ImageViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CategoryId { set; get; }
         public string ImageLink { set; get; }
        public bool? TypeLink { set; get; }
         public string Url { set; get; }
        public string Type { set; get; }

        public Active Active { set; get; }
        public int SortOrder { set; get; }
    }
}
