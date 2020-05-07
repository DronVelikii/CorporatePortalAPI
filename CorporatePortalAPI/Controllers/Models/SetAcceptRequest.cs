using CorporatePortalAPI.Enums; 
using CorporatePortalAPI.Models;

namespace CorporatePortalAPI.Controllers.Models
{
    public class SetAcceptRequest
    {
        public DocProvider DocProvider { get; set; }
        public string Acceptor { get; set; }
        public StatusEnum Status { get; set; }
    }
}