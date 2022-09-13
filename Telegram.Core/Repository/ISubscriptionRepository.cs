using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Repository
{
    public interface ISubscriptionRepository
    {
        
        List<GetAllSubscription> GetAllSubscription();

        List<GetUserSubscription> GetUserSubscription(int Uid);

        List<ProfitsAndLosses> GetProfitsAndLosses();

        bool InsertSubscription(Subscription subscription);

        List<Subscription> AllSubscribe();
        bool DeleteSubscription(Subscription subscription);

        
       

    }
}
