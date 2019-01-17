using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using NetCore.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Entites
{ [Table("News")]
    public class Image : DomainEntity<int>, INameable,ISortable, ISwitchable
    {
        public string Name { set; get; }
        public int CategoryId { set; get; }
        [StringLength(200)]
        public string ImageLink { set; get; }
        public bool? TypeLink { set; get; }
        [StringLength(200)]
        public string Url { set; get; }
        public Active Active { set; get; }
        [ForeignKey("CategoryId")]
        public virtual ImageCategory ImageCategories { set; get; }
        public int SortOrder { set; get; }
    }
}
