using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI._3rdParty.System1;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI.Service.ServiceGates
{
    public class ServiceGate1 : ServiceGate
    {
        private readonly ISystem1 system;

        public ServiceGate1(ISystem1 system)
        {
            this.system = system;
        }

        public override int ProviderId => 1;

        public override async Task<List<int>> GetDocuments()
        {
            return await system.GetDocuments();
        }

        public override async Task<IDocument> GetDocument(IDocProvider docProvider)
        {
            return await system.GetDocument(docProvider);
        }

        public override async Task<string> SetAccept(IAccept accept)
        {
            return await system.SetAccept(new Accept1
            {
                Acceptor = accept.Acceptor,
                Status = accept.Status,
                DocProvider = accept.DocProvider,
                Date = DateTime.Now // IAccept1 расширяет IAccept параметром date со значением текущей даты 
            });
        }
    }
}