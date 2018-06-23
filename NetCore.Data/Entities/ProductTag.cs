using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Data.Entites
{
   public class ProductTag:DomainEntity<int>
    {

        public int ProductId { set; get; }
        [StringLength(30)]
         public string TagId { set; get; }
        [ForeignKey("ProductId")]

        public virtual Product Product { set; get; }
        [ForeignKey("TagId")]

        public virtual Tag Tag { set; get; }
    }
}
