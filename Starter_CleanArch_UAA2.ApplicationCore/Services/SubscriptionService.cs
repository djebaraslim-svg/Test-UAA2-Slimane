using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.Domain.Models;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils;


namespace Starter_CleanArch_UAA2.ApplicationCore.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMailerService _mailerService;

        public SubscriptionService(ISubscriberRepository subscriberRepository, IMailerService emailService)
        {
            _subscriberRepository = subscriberRepository;
            _mailerService = emailService;
        }
        public void Subscribe(string email, bool nouveautes, bool recapitulatifMois, bool faitDuJour)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("L'Email est requis svp", nameof(email));
            }

            Subscriber? subscriber = _subscriberRepository.GetByEmail(email);

            if (subscriber is not null)
            {
                subscriber = new Subscriber(email);
                _subscriberRepository.Add(subscriber);
            }

            if (subscriber is not null)
            {
                subscriber.UpdateSubscription(nouveautes, recapitulatifMois, faitDuJour);
                _subscriberRepository.Update(subscriber);
            }
            
            {
                _mailerService.SendSubscriptionEmail(email);

            }
        }

        public void Unsubscribe(string email)
        {
            Subscriber? subscriber = _subscriberRepository.GetByEmail(email);
            
            if (subscriber == null)
                return;
            {
                _subscriberRepository.Delete(subscriber);
                _subscriberRepository.Save();

               _mailerService.SendUnsubscriptionEmail(email);

            }    
            
        }
    }
}
