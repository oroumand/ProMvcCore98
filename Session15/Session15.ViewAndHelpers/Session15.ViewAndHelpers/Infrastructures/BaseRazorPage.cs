using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session15.ViewAndHelpers.Infrastructures
{
    public abstract class BaseRazorPage<TModel> : RazorPage<TModel>
    {
        public bool IsValid()
        {
            return true;
        }

    }
}
