using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using App.Common.Enums;

namespace App.Core
{
    /// <summary>
    /// История оплат в виде списка файлов CSV, в которых находится информация о каждом отчетном периоде.
    /// </summary>
    public class BillingHistory
    {
        /// <summary>
        /// Название для истории оплаты.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Список файлов со счетами по каждому расчетному периоду.
        /// </summary>
        public List<BillingDataFile> BillingDataFiles { get; set; }

        /// <summary>
        /// Тип файлов, в которых содержится история оплат.
        /// </summary>
        [XmlAttribute("filetype")]
        public FileTypes FileType { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта с данными об истории оплат, размещенной в файлах.
        /// </summary>
        public BillingHistory()
        {
            BillingDataFiles = new List<BillingDataFile>();
        }

        public override string ToString()
        {
            return String.Format("Billing history for {0} data.", Name);
        }

        /// <summary>
        /// Добавление нового файла в историю.
        /// </summary>
        /// <param name="file">Файл с данными об оплате за период.</param>
        public void AddBillingFile(BillingDataFile file)
        {
            if (file != null)
                BillingDataFiles.Add(file);
        }

        /// <summary>
        /// Очистка списка файлов с историей оплат по периодам.
        /// </summary>
        public void Clear()
        {
            BillingDataFiles.Clear();
        }
    }
}
