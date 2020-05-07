using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporatePortalAPI.Helpers;
using CorporatePortalAPI.Interfaces;
using CorporatePortalAPI.Models;

namespace CorporatePortalAPI._3rdParty.System1
{
    public class System1 : ISystem1
    {
        private readonly List<IDocument> documents;

        public System1()
        {
            documents = new List<IDocument>
            {
                new Document
                {
                    Id = 1,
                    Title = "Заголовок 1",
                    Content = "Содержимое 1",
                    Author = "Иванов И.И. 1"
                },
                new Document
                {
                    Id = 2,
                    Title = "Заголовок 2",
                    Content = "Содержимое 2",
                    Author = "Иванов И.И. 2"
                },
            };
        }

        public Task<List<int>> GetDocuments()
        {
            return Task.FromResult(documents.Select(x => x.Id).ToList());
        }

        public Task<IDocument> GetDocument(IDocProvider docProvider)
        {
            return Task.FromResult(documents.FirstOrDefault(x => x.Id == docProvider.Id));
        }

        public Task<string> SetAccept(IAccept1 accept)
        {
            var statusSescription = EnumHelper.GetEnumDescription(accept.Status);

            return Task.FromResult($"{accept.Acceptor} успешно выполнил операцию {statusSescription}, {accept.Date}");
        }
    }
}