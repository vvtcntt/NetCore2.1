using NetCore.Data.Interfaces;
using NetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using NetCore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Entites
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, INameable, IHasSeoMetaData, IDateTracking,  ISortable, ISwitchable, IMultiLanguage<int>
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name,int? parentId,string description,string content,string image,string icon, bool? homeFlag,
            int sortOder,DateTime dateCreated, 
            DateTime dateModified,string tileMeta,string keyworkMeta,string descriptionMeta,
            string seoAlias, int languageId,Status status)
        {
            Name = name;
            ParentId = parentId;
            Description = description;
            Content = content;
            Image = image;
            Icon = icon;
            HomeFlag = homeFlag;
            SorOrder = sortOder;
            DateCreated = dateCreated;
            DateModified = dateModified;
            TitleMeta = tileMeta;
            KeywordMeta = keyworkMeta;
            DescriptionMeta = descriptionMeta;
            SeoAlias = seoAlias;
            LanguageId = languageId;
            Status = status;
        }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [StringLength(255)]
        [Required]
        public string Description { get; set; }
        public string Content { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(255)]
        public string Icon { get; set; }
        public bool? HomeFlag { get; set; }
         public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        [StringLength(255)]
        public string TitleMeta { set; get; }
        [StringLength(255)]
        public string KeywordMeta { set; get; }
        [StringLength(255)]
        public string DescriptionMeta { set; get; }
        [StringLength(255)]
         public int LanguageId { set; get; }
        public Status Status { set; get; }
        public virtual ICollection<Product> Products { set; get; }
        public int SorOrder  { set; get; }
        public string SeoTitle  { set; get; }
        public string SeoAlias  { set; get; }
        public string SeoKeyWords  { set; get; }
        public string SeoDescription  { set; get; }
    }


}

