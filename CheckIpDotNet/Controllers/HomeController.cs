using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckIpDotNet.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : Controller
    {
        private IHttpContextAccessor _accessor;
        public HomeController(IHttpContextAccessor accessor) : base()
        {
            _accessor = accessor;
        }

        [HttpGet]
        public string Index()
        {
            return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}