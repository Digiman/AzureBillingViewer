using System;

namespace App.Core
{
    /// <summary>
    /// Описание файла с данными о расходах за период действия подписки (месяц).
    /// </summary>
    /// <remarks>Собственно класс, который и сериализуется в XML файл и хранит сведения о файле с данными о периоде оплаты.</remarks>
    [Serializable]
    public class BillingDataFile
    {
        /// <summary>
        /// Имя файла и путь к нему.
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// Название файла.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание для содержимого файла (в произвольном виде).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public BillingDataFile()
        { }
    }
}
