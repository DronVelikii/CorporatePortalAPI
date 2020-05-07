using CorporatePortalAPI.Controllers;
using CorporatePortalAPI.Controllers.Models;
using CorporatePortalAPI.Enums;
using CorporatePortalAPI.Helpers;
using CorporatePortalAPI.Models;
using CorporatePortalAPI.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorporatePortalAPI.Tests
{
    [TestClass]
    public class DataControllerTests
    {
        [TestMethod]
        public void GetDocumentsTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.InitServices();

            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = new DataController(serviceProvider.GetService<IService>());

            var result = controller.GetDocuments().GetAwaiter().GetResult();

            Assert.IsTrue(result.Documents.Count == 5);
        }

        [TestMethod]
        public void GetDocumentTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.InitServices();

            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = new DataController(serviceProvider.GetService<IService>());

            var result = controller.GetDocument(new GetDocumentRequest
            {
                Id = 1,
                Provider = 1
            }).GetAwaiter().GetResult();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Title == "Заголовок 1");
        }

        [TestMethod]
        public void GetDocumentDoesNotExistsTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.InitServices();

            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = new DataController(serviceProvider.GetService<IService>());

            var result = controller.GetDocument(new GetDocumentRequest
            {
                Id = 500,
                Provider = 1
            }).GetAwaiter().GetResult();

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void SetAcceptTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.InitServices();

            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = new DataController(serviceProvider.GetService<IService>());

            var result = controller.SetAccept(new SetAcceptRequest
            {
                Acceptor = "Иванов",
                Status = StatusEnum.Accepted,
                DocProvider = new DocProvider
                {
                    Id = 1,
                    Provider = 1
                }
            }).GetAwaiter().GetResult();

            Assert.IsTrue(!string.IsNullOrEmpty(result));
            Assert.IsTrue(result.StartsWith("Иванов успешно выполнил операцию Утверждено"));
        }
    }
}