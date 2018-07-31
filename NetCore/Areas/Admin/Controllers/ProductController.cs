using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Product;
using NetCore.Utilities.Helpers;

namespace NetCore.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService=productCategoryService;
    }
        public IActionResult Index()
        {
            
            return View();
        }
        #region Api
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
        }
        public IActionResult GetAllPaging(int? categoryId,string keyword,int page,int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
            return new OkObjectResult(model);
        }
        public IActionResult GetAllCategories()
        {
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return new OkObjectResult(model);
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }
          [HttpPost]
        public IActionResult SaveEntity(ProductViewModel productVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (productVm.Id == 0)
                {
                    _productService.Add(productVm);
                }
                else
                {
                    _productService.Update(productVm);
                }
                _productService.Save();
                return new OkObjectResult(productVm);

            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                _productService.delete(id);
                _productService.Save();
                return new OkObjectResult(id);
            }
        }
        #endregion
    }
}