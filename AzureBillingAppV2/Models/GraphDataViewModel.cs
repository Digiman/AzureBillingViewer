using System.Collections.Generic;

namespace AzureBillingAppV2.Models
{
    /// <summary>
    /// Модуль для хранения данных, которые будут отображаться на графике.
    /// </summary>
    public class GraphDataViewModel
    {
        /// <summary>
        /// Словарь с данными для отображения на графике (ключ - название периода, значение - сумма расходов).
        /// </summary>
        public Dictionary<string, double> SpentByPeriods { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public GraphDataViewModel()
        {
            SpentByPeriods = new Dictionary<string, double>();
        }
    }
}
