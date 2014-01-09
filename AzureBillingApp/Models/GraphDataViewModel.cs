using System.Collections.Generic;

namespace AzureBillingApp.Models
{
    /// <summary>
    /// Модуль для хранения данных, которые будут отображаться на графике.
    /// </summary>
    public class GraphDataViewModel
    {
        public Dictionary<string, double> SpentByPeriods { get; set; }

        public GraphDataViewModel()
        {
            SpentByPeriods = new Dictionary<string, double>();
        }
    }
}
