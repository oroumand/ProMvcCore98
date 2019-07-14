using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions
{
    public class RootController
    {
        public string Index() => "Hello From Root Controller";
    }
    [NonController]
    public class NotController
    {
        public string Index() => "Hello From Not Controller";
    }
}
