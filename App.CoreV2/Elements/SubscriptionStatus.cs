namespace App.CoreV2.Elements
{
    /// <summary>
    /// Класс для описания статуса подписки (по сути, шапка счета за отчетный период).
    /// </summary>
    public class SubscriptionStatus
    {
        /// <summary>
        /// Идентификатор подписки.
        /// </summary>
        public string SubscriptionId { get; set; }
        /// <summary>
        /// Название подписки.
        /// </summary>
        public string SubscriptionName { get; set; }
        /// <summary>
        /// ИД заказа.
        /// </summary>
        public string IdOrder { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата выставления счетов (дата годовщины).
        /// </summary>
        public string SubscriptionDate { get; set; }
        /// <summary>
        /// Название предложения.
        /// </summary>
        public string TitleOfPropostal { get; set; }
        /// <summary>
        /// Имя службы.
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Состояние подписок.
        /// </summary>
        public string SubscriptionsStatus { get; set; }
        /// <summary>
        /// Особое состояние подписок.
        /// </summary>
        public string SubscriptionStatusAdditional { get; set; }
        /// <summary>
        /// Состояние подготовки.
        /// </summary>
        public string StateOfPreparation { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public SubscriptionStatus()
        { }

        /// <summary>
        /// Инициализация объекта с данными, полученными при разборе строки файла CSV.
        /// </summary>
        /// <param name="data">Массив строк с данными из разобранной строки.</param>
        public SubscriptionStatus(string[] data)
        {
            SubscriptionId = data[0];
            SubscriptionName = data[1];
            IdOrder = data[2];
            Description = data[3];
            SubscriptionDate = data[4];
            TitleOfPropostal = data[5];
            ServiceName = data[6];
            SubscriptionsStatus = data[7]; 
            SubscriptionStatusAdditional = data[8];
            StateOfPreparation = data[9];
        }
    }
}
