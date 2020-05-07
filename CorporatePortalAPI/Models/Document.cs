using CorporatePortalAPI.Interfaces;

namespace CorporatePortalAPI.Models
{
    public class Document : IDocument
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }
    }
}