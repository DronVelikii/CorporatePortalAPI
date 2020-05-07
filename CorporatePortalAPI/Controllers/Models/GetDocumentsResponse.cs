using System.Collections.Generic;
using CorporatePortalAPI.Interfaces;
using CorporatePortalAPI.Models;

namespace CorporatePortalAPI.Controllers.Models
{
    public class GetDocumentsResponse
    {
        public List<IDocProvider> Documents { get; set; }
    }
}