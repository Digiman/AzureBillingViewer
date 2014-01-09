namespace AzureBillingApp.Models
{
    /// <summary>
    /// Фильтр для фильтрации записей по ежедневному использованию.
    /// </summary>
    public class DayUsageFilter
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ресурс.
        /// </summary>
        public string Resource { get; set; }
        /// <summary>
        /// Субрегион.
        /// </summary>
        public string Subregion { get; set; }
        /// <summary>
        /// Служба.
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// Компонент.
        /// </summary>
        public string Component { get; set; }
    }
}
