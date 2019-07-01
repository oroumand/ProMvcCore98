using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions.Controllers
{
    [Controller]
    public class MyAttr
    {
        public string Index() => "Hello From Attribute Controller";
    }
}
