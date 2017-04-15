using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.SourceLists;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISourceList _sourceList;

        public HomeController(ISourceList sourceList)
        {
            _sourceList = sourceList;
        }

        public IActionResult Index()
        {
            return View(_sourceList.Get());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
