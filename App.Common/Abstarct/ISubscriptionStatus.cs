namespace App.Common.Abstarct
{
    public interface ISubscriptionStatus
    {
        /// <summary>
        /// Идентификатор подписки.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Название подписки.
        /// </summary>
        string SubscriptionName { get; set; }

        /// <summary>
        /// ИД заказа.
        /// </summary>
        string IdOrder { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Дата выставления счетов (дата годовщины).
        /// </summary>
        string SubscriptionDate { get; set; }

        /// <summary>
        /// Название предложения.
        /// </summary>
        string TitleOfPropostal { get; set; }

        /// <summary>
        /// Имя службы.
        /// </summary>
        string ServiceName { get; set; }

        /// <summary>
        /// Состояние подписок.
        /// </summary>
        string SubscriptionsStatus { get; set; }

        /// <summary>
        /// Особое состояние подписок.
        /// </summary>
        string SubscriptionStatusAdditional { get; set; }

        /// <summary>
        /// Состояние подготовки.
        /// </summary>
        string StateOfPreparation { get; set; }
    }
}