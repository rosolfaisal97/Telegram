using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository ;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public bool DeleteSubscription(Subscription subscription)
        {
            return subscriptionRepository.DeleteSubscription(subscription); 
        }

        public List<GetAllSubscription> GetAllSubscription()
        {
           return subscriptionRepository.GetAllSubscription();
        }

        public List<ProfitsAndLosses> GetProfitsAndLosses()
        {
            return subscriptionRepository.GetProfitsAndLosses();
        }

        public List<GetUserSubscription> GetUserSubscription(int Uid)
        {
            return subscriptionRepository.GetUserSubscription(Uid);
        }

        public bool InsertSubscription(Subscription subscription)
        {
           return subscriptionRepository.InsertSubscription(subscription);
        }
    }
}
