using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practical_9.Controllers;
using System.Web.Mvc;
using Xunit;

namespace Practical_9.Tests
{
    public class Test3ControllerTests
    {
        [Fact]
        public void CheckHelloWorld()
        {
            //Creating controller object
            var controller = new Test3Controller();

            //Invoking the Index Action Method
            var result = controller.Index() as ViewResult;

            //Checking that result is not null
            Assert.NotNull(result);
            //Checking that ViewBag.name is Hello World
            Assert.Equal("Hello World", result.ViewBag.hello);
        }
    }
}
