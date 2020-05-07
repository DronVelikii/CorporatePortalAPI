using CorporatePortalAPI.Enums;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System2
{
    public class Accept2 : IAccept2
    {
        public IDocProvider DocProvider { get; set; }
        public string Acceptor { get; set; }
        public StatusEnum Status { get; set; } 
    }
}