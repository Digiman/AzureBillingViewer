using System;
using System.Collections.Generic;
using App.Core.Elements;

namespace App.Core.Extensions
{
    /// <summary>
    /// Класс для реализации сравнения объектов со сведениями о подписках.
    /// </summary>
    public class SubscriptionStatusComparer : IEqualityComparer<SubscriptionStatus>
    {
        public bool Equals(SubscriptionStatus x, SubscriptionStatus y)
        {
            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal. 
            return x.SubscriptionId == y.SubscriptionId && x.IdOrder == y.IdOrder;
        }

        public int GetHashCode(SubscriptionStatus obj)
        {
            return obj.SubscriptionId.GetHashCode();
        }
    }
}
