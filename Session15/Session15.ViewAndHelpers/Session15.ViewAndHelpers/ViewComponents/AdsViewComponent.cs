using Microsoft.AspNetCore.Mvc;
using Session15.ViewAndHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session15.ViewAndHelpers.ViewComponents
{
    [ViewComponent]
    public class AdsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string prefixAdd)
        {
            var Ads = new List<Ads>
                {
                   new Ads{Id = 1, Description ="Adds Description", Titr =$"{prefixAdd} - Adds Titrt"},
                   new Ads{Id =2, Description ="Adds Description", Titr =$"{prefixAdd} - Adds Titrt 2"}
                };
            return View("",Ads);

        }
    }
}
