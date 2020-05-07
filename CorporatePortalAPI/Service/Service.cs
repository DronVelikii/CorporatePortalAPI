using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporatePortalAPI.Interfaces;
using CorporatePortalAPI.Models;
using CorporatePortalAPI.Service.ServiceGates;
using Microsoft.Extensions.Logging;

namespace CorporatePortalAPI.Service
{
    /// <summary>
    /// Сервис поддерживает взаимодействие с неограниченным набором шлюзов реализующих похожий протокол
    /// </summary>
    public class Service : IService
    {
        private readonly List<ServiceGate> serviceGates;
        private readonly ILogger<Service> logger;

        public Service(List<ServiceGate> serviceGates, ILogger<Service> logger)
        {
            this.logger = logger;
            this.serviceGates = serviceGates;
        }

        public async Task<List<IDocProvider>> GetDocuments()
        {
            logger.LogInformation($"{DateTime.Now} {nameof(GetDocuments)}");

            var gateTasks = new Dictionary<int, Task<List<int>>>();

            foreach (var serviceGate in serviceGates)
            {
                var task = serviceGate.GetDocuments();
                gateTasks.Add(serviceGate.ProviderId, task);
            }

            await Task.WhenAll(gateTasks.Values);

            var result = new List<IDocProvider>();

            // Сервис компонует данные, добавляет ID шлюза (провайдер) и возвращает вышеописанную структуру выходных параметров.
            foreach (var providerId in gateTasks.Keys)
            {
                var task = gateTasks[providerId];

                result.AddRange(task.Result.Select(x => new DocProvider
                {
                    Id = x,
                    Provider = providerId
                }));
            }

            return result;
        }

        public async Task<IDocument> GetDocument(IDocProvider docProvider)
        {
            logger.LogInformation($"{DateTime.Now} {nameof(GetDocument)}");

            var serviceGate = serviceGates.FirstOrDefault(x => x.ProviderId == docProvider.Provider);

            if (serviceGate == null)
            {
                throw new InvalidOperationException($"Провайдера с ID {docProvider.Provider} не существует");
            }

            return await serviceGate.GetDocument(docProvider);
        }

        public async Task<string> SetAccept(IAccept accept)
        {
            logger.LogInformation($"{DateTime.Now} {nameof(SetAccept)}");

            var serviceGate = serviceGates.FirstOrDefault(x => x.ProviderId == accept.DocProvider.Provider);

            if (serviceGate == null)
            {
                throw new InvalidOperationException($"Провайдера с ID {accept.DocProvider.Provider} не существует");
            }

            return await serviceGate.SetAccept(accept);
        }
    }
}