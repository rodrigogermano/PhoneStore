using PhoneStore.Application.Cqrs.Events;
using PhoneStore.Infra.SendMail;
using PhoneStory.PhoneStore.Application.Interfaces.Events;
using System;
using System.Collections.Generic;

namespace PhoneStore.Application.Cqrs.EventHandlers
{
    public class ProductEventHandler : EventHandler, IProductEventHandler
    {
        private readonly string _emailAddress = "rodrigo.germanos@al.infnet.edu.br";
        private readonly ISendMailService _mailService;

        public ProductEventHandler(
            ISendMailService mailService)
        {
            _mailService = mailService;
        }
        public void Handle(ProductAddedEvent domainEvent)
        {
            _mailService.Send(
                to: new List<string>() { _emailAddress },
                subject: "Um novo produto foi cadastrado!",                
                body: $"{domainEvent.Product.Id} - {domainEvent.Product.DisplayName}"
                );
        }

        public void Handle(ProductUpdatedEvent domainEvent)
        {
            _mailService.Send(
               to: new List<string>() { _emailAddress },
               subject: $"O produto {domainEvent.Product.DisplayName} foi atualizado!",
               body: $"{domainEvent.Product.Id} - {domainEvent.Product.DisplayName}"
               );
        }

        public void Handle(ProductDeletedEvent domainEvent)
        {
            _mailService.Send(
               to: new List<string>() { _emailAddress },
               subject: $"O produto {domainEvent.Product.DisplayName} foi deletado!",
               body: $"{domainEvent.Product.Id} - {domainEvent.Product.DisplayName}"
               );
        }

    }
}
