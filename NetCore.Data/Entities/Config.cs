using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Data.Entites
{
    [Table("Configs")]
    public class Config:DomainEntity<string>,INameable
    {
        public string Name { get; set; }

        [StringLength(250)]
         public string Address { get; set; }
        [StringLength(100)]
         public string Mobile { get; set; }
        [StringLength(100)]
         public string Hotline { get; set; }
        [StringLength(100)]
         public string Fax { get; set; }
        [StringLength(100)]
         public string Email { get; set; }
        [StringLength(100)]
         public string Slogan { get; set; }
        [StringLength(250)]
        [Required]
        public string ImageLogo { get; set; }
        [StringLength(250)]
         public string ImageFavicon { get; set; }
        public string Content { get; set; }
        [StringLength(100)]
         public string UserMail { get; set; }
        [StringLength(250)]
         public string PassMail { get; set; }
        [StringLength(200)]
         public string Analytics { get; set; }
        [StringLength(200)]
          public string WebMasterTool { get; set; }
        [StringLength(200)]
         public string AppFacebook { get; set; }
        [StringLength(500)]
         public string CodeChat { get; set; }
        [StringLength(250)]
         public string FanpgeFacebook { get; set; }
        [StringLength(250)]
         public string FanpageGoogle { get; set; }
        [StringLength(250)]
         public string FanpageYoutube { get; set; }
        [StringLength(500)]
         public string GeoMeta { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar(50)")]
         public string Color { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Host { get; set; }
        public int? Port { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string TimeOut { get; set; }
        public bool? Coppy { get; set; }
        public bool? Social { get; set; }
        public bool? Popup { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar(255)")]
        string TitleMeta { set; get; }
        [StringLength(500)]
        [Column(TypeName = "varchar(500)")]
        string KeywordMeta { set; get; }
        [StringLength(250)]
        [Column(TypeName = "varchar(500)")]
        string DescriptionMeta { set; get; }
    }

}

 