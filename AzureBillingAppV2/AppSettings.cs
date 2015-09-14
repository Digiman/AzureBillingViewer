using App.Common.Enums;

namespace AzureBillingAppV2
{
    /// <summary>
    /// Класс для хранения и управления глобальными настройками приложения, которые можно изменить в специальном окне с настройками.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Версия файла использования, которая имеет свои особенности по детализации и сведениям, которые в нем содержатся.
        /// </summary>
        public static ResourceFileVersion ApiVersion { get; set; }
    }
}
