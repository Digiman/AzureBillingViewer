using System.Collections.Generic;

namespace App.Common.Abstarct
{
    public interface IBillingDataCollection <TBillingData, TSubscription>
    {
        List<TSubscription> GetSubscriptions();

        List<TBillingData> GetBillingDataBySubscription(TSubscription subscription);
    }
}
