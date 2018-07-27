﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Extensions;

namespace NetCore.Areas.Admin.Controllers
{
    
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var email = User.getSpecificClaim("Email");
            return View();
        }
    }
}