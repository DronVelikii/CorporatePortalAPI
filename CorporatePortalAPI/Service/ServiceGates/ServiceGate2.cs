using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorporatePortalAPI._3rdParty.System2;
using CorporatePortalAPI.Interfaces;
using CorporatePortalAPI.Models;

namespace CorporatePortalAPI.Service.ServiceGates
{
    public class ServiceGate2 : ServiceGate
    {
        private readonly ISystem2 system;

        public ServiceGate2(ISystem2 system)
        {
            this.system = system;
        }

        public override int ProviderId => 2;

        public override async Task<List<int>> GetDocuments()
        {
            return await system.GetDocuments(DateTime.Now); // При вызове шлюза 2 в параметры вызова добавляется date = текущей дате. В запросе не обрабатывается.
        }

        public override async Task<IDocument> GetDocument(IDocProvider docProvider)
        {
            return await system.GetDocument(docProvider);
        }

        public override async Task<string> SetAccept(IAccept accept)
        {
            return await system.SetAccept(new Accept2
            {
                Acceptor = accept.Acceptor,
                Status = accept.Status,
                DocProvider = accept.DocProvider
            });
        }
    }
}