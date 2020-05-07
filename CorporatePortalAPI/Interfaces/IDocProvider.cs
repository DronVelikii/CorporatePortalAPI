namespace CorporatePortalAPI.Interfaces
{
    public interface IDocProvider
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID провайдера документа
        /// </summary>
        public int Provider { get; set; }
    }
}