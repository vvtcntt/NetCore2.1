using NetCore.Data.Entites;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Data.Entities
{
    public class NewsTag : DomainEntity<int>
    {
        public int NewsId { set; get; }
        [StringLength(50)]
        public string TagId { set; get; }
        [ForeignKey("ProductId")]

        public virtual News News { set; get; }
        [ForeignKey("TagId")]

        public virtual Tag Tag { set; get; }
    }
}
