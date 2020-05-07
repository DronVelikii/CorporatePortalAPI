using System;
using CorporatePortalAPI.Enums;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System1
{
    public class Accept1 : IAccept1
    {
        public IDocProvider DocProvider { get; set; }
        public string Acceptor { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime Date { get; set; }
    }
}