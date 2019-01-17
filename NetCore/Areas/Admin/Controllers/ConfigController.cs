using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore.Application.Implementation;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.System;


namespace NetCore.Areas.Admin.Controllers
{
    public class ConfigController:BaseController
    {
        public IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetById(string id)
        {
            var model = _configService.GetById(id);

            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(ConfigViewModel configVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                _configService.update(configVm);
                _configService.Save();
                return new OkObjectResult(configVm);
            }
        }
    }
}