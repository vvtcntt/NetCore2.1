using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.Product
{
   public class ProductImageViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        
        public ProductViewModel Product { get; set; }

        public string Image { get; set; }

        public string Caption { get; set; }
    }
}
