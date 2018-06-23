using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using NetCore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Entites
{
    public class ImageCategory : DomainEntity<int>, INameable, ISortable, ISwitchable
    {
        public int Ord { set; get; }
        public Status Status { set; get; }
        string INameable.Name { set; get; }

        public virtual ICollection<Image> Images { set; get; }
        public int SorOrder { set; get; }
    }
}