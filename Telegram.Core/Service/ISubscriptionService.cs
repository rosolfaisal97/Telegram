using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Core.Data;
using Telegram.Core.DTO;

namespace Telegram.Core.Service
{
    public interface ISubscriptionService
    {

        List<GetAllSubscription> GetAllSubscription();

        List<GetUserSubscription> GetUserSubscription(int Uid);

        bool InsertSubscription(Subscription subscription);

        List<ProfitsAndLosses> GetProfitsAndLosses();

        bool DeleteSubscription(Subscription subscription);
    }
}
