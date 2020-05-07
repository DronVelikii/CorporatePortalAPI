using System.Threading.Tasks;
using CorporatePortalAPI.Controllers.Models;
using CorporatePortalAPI.Models;
using CorporatePortalAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CorporatePortalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IService service;

        public DataController(IService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Получение списка документов
        /// </summary>
        [HttpGet]
        public async Task<GetDocumentsResponse> GetDocuments()
        {
            var docs = await service.GetDocuments();

            return new GetDocumentsResponse
            {
                Documents = docs
            };
        }

        /// <summary>
        /// Получение документа
        /// </summary>
        [HttpPost]
        public async Task<GetDocumentResponse> GetDocument([FromBody] GetDocumentRequest model)
        {
            var result = await service.GetDocument(new DocProvider
            {
                Id = model.Id,
                Provider = model.Provider
            });
            
            if (result == null)
            {
                return null;
            }

            return new GetDocumentResponse
            {
                Author = result.Author,
                Content = result.Content,
                Id = result.Id,
                Title = result.Title
            };
        }

        /// <summary>
        /// Утверждение документа
        /// </summary>
        [HttpPost]
        public async Task<string> SetAccept([FromBody] SetAcceptRequest model)
        {
            return await service.SetAccept(new Accept
            {
                Acceptor = model.Acceptor,
                Status = model.Status,
                DocProvider = new DocProvider
                {
                    Id = model.DocProvider.Id,
                    Provider = model.DocProvider.Provider
                }
            });
        }
    }
}