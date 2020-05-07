using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System1
{
    public interface ISystem1
    {
        Task<List<int>> GetDocuments();
        Task<IDocument> GetDocument(IDocProvider docProvider);
        Task<string> SetAccept(IAccept1 accept);
    }
}