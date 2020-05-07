using CorporatePortalAPI.Enums;
using CorporatePortalAPI.Interfaces;

namespace CorporatePortalAPI.Models
{
    public class Accept : IAccept
    {
        public IDocProvider DocProvider { get; set; }
        public string Acceptor { get; set; }
        public StatusEnum Status { get; set; }
    }
}