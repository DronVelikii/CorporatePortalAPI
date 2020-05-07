using CorporatePortalAPI.Interfaces;

namespace CorporatePortalAPI.Models
{
    public class DocProvider : IDocProvider
    {
        public int Id { get; set; }
        public int Provider { get; set; }
    }
}