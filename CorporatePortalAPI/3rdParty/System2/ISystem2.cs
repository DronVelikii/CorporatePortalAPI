using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System2
{
    public interface ISystem2
    {
        Task<List<int>> GetDocuments(DateTime date);
        Task<IDocument> GetDocument(IDocProvider docProvider);
        Task<string> SetAccept(IAccept2 accept);
    }
}