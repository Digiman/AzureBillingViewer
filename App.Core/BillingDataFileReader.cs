using System.Collections.Generic;
using System.Linq;
using App.Common;
using App.Common.Extensions;
using App.Core.Elements;

namespace App.Core
{
    /// <summary>
    /// Класс для реализации чтения файла с данными о расходах.
    /// </summary>
    /// <remarks>Принять во внимание, что класс читает данные для файла версии 2!</remarks>
    public static class BillingDataFileReader
    {
        public static BillingData ReadDataFile(string filename)
        {
            var data = new BillingData();

            // чтение по блокам файла с данными в формате CVS
            var lines = CsvFileReader.ReadByBlocks(filename);

            // 1. блок с данными о состоянии подписки
            data.SubscriptionStatuses = ParseSubscriptionStatusData(lines[0]);

            // 2. блок с данными о заявления к оплате по компонентам
            data.Declarations = ParseDeclarationsData(lines[1]);

            // 3. блок с данными об ежедневном использовании
            data.DayUsages = ParseDayUsagesData(lines[2]);

            return data;
        }

        private static List<SubscriptionStatus> ParseSubscriptionStatusData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new SubscriptionStatus(line.ParseLine())).ToList();
        }

        private static List<Declaration> ParseDeclarationsData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new Declaration(line.ParseLine())).ToList();
        }

        private static List<DayUsage> ParseDayUsagesData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new DayUsage(line.ParseLine())).ToList();
        }
    }
}
