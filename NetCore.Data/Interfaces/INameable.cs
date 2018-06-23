using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore.Data.Interfaces
{
    public interface INameable
    {
        [StringLength(250)]
        [Required]
        string Name { set; get; }
    }
}
