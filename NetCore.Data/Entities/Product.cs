using NetCore.Data.Enums;
using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Data.Entites
{
    [Table("Products")]
    public class Product : DomainEntity<int>, INameable, ISwitchable, ISwitchStatus, IHasSeoMetaData, IDateTracking, ISortable, IMultiLanguage<int>
    {
        public Product()
        {
            ProductTags = new List<ProductTag>();
        }
        public Product(
            string name, int catelogyId, string code, string description, 
            string info, string content, string parameter, string imageDetail, 
            string imageThumb, decimal price, decimal priceSale,string notePrice, 
            int warranty, int age, string sale, string size, 
            bool vat, bool news, bool productSale, bool homeFlag,
            int sortOrder, DateTime dateCreate, DateTime dateModifire, string seoTitle,
            string seoKeywords, string seoDescription, string seoAlias, Active active,Status status, 
            int languageId, int viewCount,  string tag)
        {

            Name = name;
            CategoryId = catelogyId;
            Code = code;
            Description = description;
            Info = info;
            Content = content;
            Parameter = parameter;
            ImageDetail = imageDetail;
            ImageThumbs = imageThumb;
            Price = price;
            PriceSale = priceSale;
            NotePrice = notePrice;
            Warranty = warranty;
            Age = age;
            Sale = sale;
            Size = size;
            Vat = vat;
            New = news;
            ProductSale = productSale;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            DateCreated = dateCreate;
            DateModified = dateModifire;
            SeoTitle = seoTitle;
            SeoKeyWords = seoKeywords;
            SeoDescription = seoDescription;
            SeoAlias = seoAlias;
            Active = active;
            LanguageId = languageId;
            ViewCount = viewCount;
            Status = status;
            Tag = tag; ProductTags = new List<ProductTag>();


        }
        public Product(int id, string name, int catelogyId, string code, string description, string info, string content, string parameter, string imageDetail, string imageThumb, decimal price, decimal priceSale,
          string notePrice, int warranty, int age, string sale, string size, bool vat, bool news, bool productSale, bool homeFlag, int sortOrder, DateTime dateCreate, DateTime dateModifire, string seoTitle, string seoKeywords, string seoDescription, string seoAlias, Active active, Status status, int languageId, int viewCount, string tag)
        {
            Id = id;
            Name = name;
            CategoryId = catelogyId;
            Code = code;
            Description = description;
            Info = info;
            Content = content;
            Parameter = parameter;
            ImageDetail = imageDetail;
            ImageThumbs = imageThumb;
            Price = price;
            PriceSale = priceSale;
            NotePrice = notePrice;
            Warranty = warranty;
            Age = age;
            Sale = sale;
            Size = size;
            Vat = vat;
            New = news;
            ProductSale = productSale;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            DateCreated = dateCreate;
            DateModified = dateModifire;
            SeoTitle = seoTitle;
            SeoKeyWords = seoKeywords;
            SeoDescription = seoDescription;
            SeoAlias = seoAlias;
            Active = active;
            LanguageId = languageId;
            ViewCount = viewCount;
            Tag = tag; ProductTags = new List<ProductTag>();

        }

        public string Name { get; set; }

        [Required]
        public int CategoryId { set; get; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        [StringLength(500)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public string Info { get; set; }
        public string Content { get; set; }
        public string Parameter { get; set; }

        [StringLength(250)]
        public string ImageDetail { get; set; }

        [StringLength(250)]
        public string ImageThumbs { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal PriceSale { get; set; }

        [StringLength(250)]
        public string NotePrice { get; set; }

        [DefaultValue(0)]
        public int Warranty { get; set; }

        [DefaultValue(0)]
        public int? Age { get; set; }

        public string Sale { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        public bool? Vat { get; set; }
        public bool? New { get; set; }
        public bool? ProductSale { get; set; }
        public bool? HomeFlag { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
 

        public Status Status { set; get; }
        public int? LanguageId { set; get; }

        [DefaultValue(0)]
        public int? ViewCount { set; get; }

 
        [StringLength(255)]
        public string Tag { set; get; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }
        public string SeoTitle  { set; get; }
        public string SeoAlias  { set; get; }
        public string SeoKeyWords  { set; get; }
        public string SeoDescription  { set; get; }
        public int SortOrder  { set; get; }
        public Active Active { set; get; }
        int IMultiLanguage<int>.LanguageId  { set; get; }
    }
}