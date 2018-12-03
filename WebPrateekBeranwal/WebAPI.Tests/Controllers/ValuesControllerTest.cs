using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using WebAPI;
using WebAPI.Controllers;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {


        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            //   HttpResponseMessage result = controller.GetPerson(5);
            var result = controller.GetPerson(1);
                  var contentResult = result as OkNegotiatedContentResult<PersonModel>;
            Assert.IsNotNull(result);
            // Assert
            Assert.AreEqual("Prateek", contentResult.Content.ForeName);            
        }

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}


    }
}
