using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Data.Entites
{
    [Table("ProductSizes")]
    public class ProductSize:DomainEntity<int>,INameable
    {
         
        public string Name
        {
            get; set;
        }
    }
}
