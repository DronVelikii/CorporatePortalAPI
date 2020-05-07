using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI.Service.ServiceGates
{
    public interface IServiceGate
    {
        Task<List<int>> GetDocuments();
        Task<IDocument> GetDocument(IDocProvider docProvider);
        Task<string> SetAccept(IAccept accept);
    }
}