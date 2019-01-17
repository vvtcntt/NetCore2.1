using NetCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NetCore.Data.Enums;
using NetCore.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Entites
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable,INameable
    {
       
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }
        public Active Active { get; set; }
    }
}
