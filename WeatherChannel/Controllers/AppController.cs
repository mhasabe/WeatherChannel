﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherChannel.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
 
    }
}
