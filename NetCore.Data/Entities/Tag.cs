using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore.Data.Entites
{
    public class Tag : DomainEntity<string>, INameable
    {
        
        public string Name { set; get; }
        [StringLength(50)]
        [Required]
        public string Type { set; get; }
        public virtual ICollection<ProductTag> ProductTags { set; get; }
    }
}
