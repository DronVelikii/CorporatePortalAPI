using System.ComponentModel;

namespace CorporatePortalAPI.Enums
{
    public enum StatusEnum
    {
        /// <summary>
        /// Утверждено
        /// </summary>
        [Description("Утверждено")]
        Accepted = 1,
        
        /// <summary>
        /// Отклонено
        /// </summary>
        [Description("Отклонено")]
        Declined = 2,
        
        /// <summary>
        /// Отправлено на доработку
        /// </summary>
        [Description("Отправлено на доработку")]
        Todo = 3
    }
}