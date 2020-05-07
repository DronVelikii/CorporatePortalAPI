using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI.Service
{
    public interface IService
    {
        Task<List<IDocProvider>> GetDocuments();
        Task<IDocument> GetDocument(IDocProvider docProvider);
        Task<string> SetAccept(IAccept accept);
    }
}