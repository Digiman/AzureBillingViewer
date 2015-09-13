using App.Common.Enums;

namespace AzureBillingApp
{
    /// <summary>
    /// Класс для хранения и управления глобальными настройками приложения, которые можно изменить в специальном окне с настройками.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Версия файла использования, которая имеет свои особенности по детализации и сведениям, которые в нем содержатся.
        /// </summary>
        public ResourceFileVersion ApiVersion { get; set; }
    }
}
