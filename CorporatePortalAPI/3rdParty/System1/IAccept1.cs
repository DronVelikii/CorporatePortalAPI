using System;
using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System1
{
    public interface IAccept1 : IAccept
    {
        public DateTime Date { get; set; }
    }
}