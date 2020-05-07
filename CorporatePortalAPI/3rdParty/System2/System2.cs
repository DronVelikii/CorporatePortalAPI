using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces;
using CorporatePortalAPI.Models;

namespace CorporatePortalAPI._3rdParty.System2
{
    public class System2 : ISystem2
    {
        private readonly List<IDocument> documents;

        public System2()
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
                new Document
                {
                    Id = 3,
                    Title = "Заголовок 3",
                    Content = "Содержимое 3",
                    Author = "Иванов И.И. 3"
                }
            };
        }


        public Task<List<int>> GetDocuments(DateTime date)
        {
            // date в запросе не обрабатывается
            return Task.FromResult(documents.Select(x => x.Id).ToList());
        }

        public Task<IDocument> GetDocument(IDocProvider docProvider)
        {
            return Task.FromResult(documents.FirstOrDefault(x => x.Id == docProvider.Id));
        }

        public Task<string> SetAccept(IAccept2 accept)
        {
            return Task.FromResult($"Операция с документом успешно выполнена со стороны компании {accept.Partner}");
        }
    }
}