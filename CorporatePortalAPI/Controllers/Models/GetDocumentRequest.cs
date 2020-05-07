using CorporatePortalAPI.Interfaces;

namespace CorporatePortalAPI.Controllers.Models
{
    public class GetDocumentRequest : IDocProvider
    {
        public int Id { get; set; }
        public int Provider { get; set; }
    }
}