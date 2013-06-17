using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstDemoApp
{
    public class GreetingController : Controller
    {
        public GreetingController()
        {
            Debug.WriteLine("Greeting Controller is invoked");
        }

        public string Greet(string name)
        {
            return string.Format("Hello {0}!!!",name);
        }
    }
}