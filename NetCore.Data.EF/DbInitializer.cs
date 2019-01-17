using NetCore.Data.Entites;
using NetCore.Data.Enums;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace NetCore.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
                public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Active = Active .Active
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if(_context.Configs.Count()==0)
            {
                _context.Configs.AddRange(new List<Config>()
                {
                    new Config(){Id="Config",Name="An Vũ Company",Address="Hà Nội",Mobile="12345",Hotline="0987200700", Slogan="An vu Company",ImageLogo="",ImageFavicon="",Content="",UserMail="thiepdaicaca@gmail.com",PassMail="Vanthiep1",Analytics="",WebMasterTool="",AppFacebook="",CodeChat="",FanpageGoogle="",FanpageYoutube="",FanpageFacebook="",GeoMeta="",Color="",Host="smtp.googlemail.com",Port=587,TimeOut="20000",Coppy=true}
                });
            }
            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder= 1,Active = Active .Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder= 1,Active = Active .Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder= 2,Active = Active .Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder=3,Active = Active .Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder= 4,Active = Active .Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder= 5,Active = Active .Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder= 6,Active = Active .Active,URL = "/admin/setting/index",IconCss = "fa-home"  },
                    new Function() {Id = "PRODUCT",Name = "Product Management",ParentId = null,SortOrder= 2,Active = Active .Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder=1,Active = Active .Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder= 2,Active = Active .Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder= 3,Active = Active .Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder= 3,Active = Active .Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder= 1,Active = Active .Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder= 4,Active = Active .Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder= 1,Active = Active .Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder= 2,Active = Active .Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder= 3,Active = Active .Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder= 4,Active = Active .Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder= 5,Active = Active .Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder= 6,Active = Active .Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },
                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder= 5,Active = Active .Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder= 1,Active = Active .Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder= 2,Active = Active .Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder= 3,Active = Active .Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                });
            }


            if (_context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color() {Name="Black", Code="#000000" },
                    new Color() {Name="White", Code="#FFFFFF"},
                    new Color() {Name="Red", Code="#ff0000" },
                    new Color() {Name="Blue", Code="#1000ff" },
                };
                _context.Colors.AddRange(listColor);
            }
            if (_context.Sizes.Count() == 0)
            {
                List<Size> listSize = new List<Size>()
                {
                    new Size() {Name="XXL" },
                    new Size() { Name="XL"},
                    new Size() { Name="L" },
                    new Size() { Name="M" },
                    new Size() {Name="S" },
                    new Size() { Name="XS" }
                };
                _context.Sizes.AddRange(listSize);
            }

            if (_context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Men shirt",SeoAlias="men-shirt",ParentId = null,Active = Active .Active,SortOrder=1, DateCreated=DateTime.Now,DateModified=DateTime.Now,LanguageId=1, Description="Baba men",
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 1",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-1",Price = 1000,Active = Active .Active,
                                DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 2",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-2",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 3",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-3",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 4",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-4",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 5",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-5",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                        }
                    },
                    new ProductCategory() { Name="Women shirt",SeoAlias="women-shirt",ParentId = null,Active = Active .Active ,SortOrder=2,DateCreated=DateTime.Now,DateModified=DateTime.Now,LanguageId=1,  Description="Baba men",
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 6",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-6",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 7",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-7",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 8",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-8",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 9",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-9",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 10",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-10",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                        }},
                    new ProductCategory() { Name="Men shoes",SeoAlias="men-shoes",ParentId = null,Active = Active .Active ,SortOrder=3,DateCreated=DateTime.Now,DateModified=DateTime.Now,LanguageId=1, Description="Baba men",
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 11",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-11",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 12",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-12",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 13",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-13",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 14",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-14",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 15",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-15",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                        }},
                    new ProductCategory() { Name="Woment shoes",SeoAlias="women-shoes",ParentId = null,Active = Active .Active,SortOrder=4,DateCreated=DateTime.Now,DateModified=DateTime.Now,LanguageId=1, Description="Baba men",
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 16",DateCreated=DateTime.Now, ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-16",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 17",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-17",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 18",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-18",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 19",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-19",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                            new Product(){Name = "Product 20",DateCreated=DateTime.Now,ImageDetail="/client-side/images/products/product-1.jpg",Tag = "san-pham-20",Price = 1000,Active = Active .Active,   DateModified =DateTime.Now, PriceSale=5000,Warranty=1, CategoryId=1},
                        }}
                };
                _context.ProductCategories.AddRange(listProductCategory);
            }


            await _context.SaveChangesAsync();
        }
    }
}
