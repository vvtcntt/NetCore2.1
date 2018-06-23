using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Data.Entites
{
    public class ProductColor:DomainEntity<int>
    {
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { set; get; }
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        public int ColorId { set; get; }
    }
}
