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
        public Config() { }
        public Config(string name, string address, string mobile, string hotline, string fax, string email,string emailReceive, string slogan, string imageLogo, string imageFavicon,
            string content, string userEmail, string passEmail, string analytics, string webMasterTool, string appFacebook, string codeChat, string fanpageFacebook, string fanpageGoogle,
            string fanpageYoutube, string geoMeta, string color, string host, int port, string timeOut, bool coppy, bool status,  string titleMeta, string keywordMeta, string descriptionMeta)
        {
            Name = name;
            Address = Address;
            Mobile = mobile;
            Hotline = hotline;
            Fax = fax;
            Email = email;
            Slogan = slogan;
            ImageLogo = imageLogo;
            ImageFavicon = imageFavicon;
            Content = content;
            UserMail = userEmail;
            PassMail = passEmail;
            Analytics = analytics;
            WebMasterTool = webMasterTool;
            AppFacebook = appFacebook;
            CodeChat = codeChat;
            FanpageFacebook = fanpageFacebook;
            FanpageGoogle = fanpageGoogle;
            FanpageYoutube = fanpageYoutube;
            GeoMeta = geoMeta;
            Color = color;
            Host = host;
            Port = port;
            TimeOut = timeOut;
            EmailReceive = emailReceive;
            Status = status;
            Coppy = coppy;
             TitleMeta = titleMeta;
            KeywordMeta = keywordMeta;
            DescriptionMeta = descriptionMeta;
        }
     
        
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
        public string EmailReceive { get; set; }
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
        [StringLength(100)]
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
         public string FanpageFacebook { get; set; }
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
        public bool? Status { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar(255)")]
        public string TitleMeta { set; get; }
        [StringLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string KeywordMeta { set; get; }
        [StringLength(250)]
        [Column(TypeName = "varchar(500)")]
        public string DescriptionMeta {
            set; get;
        }
    }

}

 