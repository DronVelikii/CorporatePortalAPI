using CorporatePortalAPI.Enums; 

namespace CorporatePortalAPI.Interfaces
{
    public interface IAccept
    {
        IDocProvider DocProvider { get; set; }

        string Acceptor { get; set; }

        StatusEnum Status { get; set; }
    }
}