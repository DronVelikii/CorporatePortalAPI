using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI.Service.ServiceGates
{
    public abstract class ServiceGate : IServiceGate
    {
        public abstract int ProviderId { get; }

        public abstract Task<List<int>> GetDocuments();

        public abstract Task<IDocument> GetDocument(IDocProvider docProvider);

        public abstract Task<string> SetAccept(IAccept accept);
    }
}