using Microsoft.AspNetCore.Mvc;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.System;
using NetCore.Extensions;
using NetCore.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore.Areas.Admin.Components
{
    public class SideBarViewComponent:ViewComponent
    {
        private IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var role = ((ClaimsPrincipal)User).getSpecificClaim("Role");
            List<FunctionViewModel> function;
            if (role.Split(";").Contains(CommonConstants.AdminRole))
            {
                function = await _functionService.GetAll();
            }
            else
            {
                // Get by permistion
                function = new List<FunctionViewModel>();
            }
            return View(function);
        }
    }
}
