using CorporatePortalAPI.Interfaces; 

namespace CorporatePortalAPI._3rdParty.System2
{
    public interface IAccept2 : IAccept
    {
        // IAccept2 расширяет IAccept параметром partner = "ООО Рога и копыта"
        public string Partner => "ООО Рога и копыта";
    }
}