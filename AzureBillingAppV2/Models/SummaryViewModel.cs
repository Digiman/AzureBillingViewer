namespace AzureBillingAppV2.Models
{
    /// <summary>
    /// Модель для отображения итоговых данных и значений в окне с итогами.
    /// </summary>
    public class SummaryViewModel
    {
        /// <summary>
        /// Количество подписок.
        /// </summary>
        public int SubscriptionCount { get; set; }

        /// <summary>
        /// Всего израсходовано.
        /// </summary>
        public double TotalSpent { get; set; }

        /// <summary>
        /// Валюта, в которой приводятся значения затрат.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Количество периодов, которые есть в истории.
        /// </summary>
        public int PeriodsCount { get; set; }

        /// <summary>
        /// Средние затраты.
        /// </summary>
        public double AverageSpent { get; set; }

        /// <summary>
        /// Служб использовано (количество сервисов, которые используются).
        /// </summary>
        public int ServicesCount { get; set; }
    }
}
