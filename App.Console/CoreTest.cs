using System.Collections.Generic;
using App.Common.Enums;
using App.Core;
using App.Core.Helpers;

namespace App.Console
{
    public static class CoreTest
    {
        private const string Filename = "201305.csv";

        public static void LoadBillingData()
        {
            var data = BillingDataFileReader.ReadDataFile(Filename);
        }

        public static void CreateHistoryFile()
        {
            BillingHistory history = new BillingHistory();
            history.BillingDataFiles.AddRange(new List<BillingDataFile>
            {
                new BillingDataFile {Name = "April 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201305.csv", Description = "Плата за апрель 2013"},
                new BillingDataFile {Name = "May 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201306.csv", Description = "Плата за май 2013"},
                new BillingDataFile {Name = "June 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201307.csv", Description = "Плата за июнь 2013"},
                new BillingDataFile {Name = "July 1013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201308.csv", Description = "Плата за июль 2013"},
                new BillingDataFile {Name = "August 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201309.csv", Description = "Плата за август 2013"},
                new BillingDataFile {Name = "September 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201310.csv", Description = "Плата за сентябрь 2013"},
                new BillingDataFile {Name = "October 1013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201311.csv", Description = "Плата за октябрь 2013"}
            });

            history.Name = "My test billing history (in csv)";
            history.FileType = FileTypes.CSV;

            HistoryFileWorker.SaveToFile("history.xml", history);
        }

        public static void CreateHistoryFile2()
        {
            BillingHistory history = new BillingHistory();
            history.BillingDataFiles.AddRange(new List<BillingDataFile>
            {
                new BillingDataFile {Name = "April 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201305.xml", Description = "Плата за апрель 2013"},
                new BillingDataFile {Name = "May 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201306.xml", Description = "Плата за май 2013"},
                new BillingDataFile {Name = "June 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201307.xml", Description = "Плата за июнь 2013"},
                new BillingDataFile {Name = "July 1013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201308.xml", Description = "Плата за июль 2013"},
                new BillingDataFile {Name = "August 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201309.xml", Description = "Плата за август 2013"},
                new BillingDataFile {Name = "September 2013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201310.xml", Description = "Плата за сентябрь 2013"},
                new BillingDataFile {Name = "October 1013", Filename = @"d:\WorkProj\AzureUtils\AzureBilling\App.Console\bin\Debug\201311.xml", Description = "Плата за октябрь 2013"}
            });

            history.Name = "My test billing history (in xml)";
            history.FileType = FileTypes.XML;

            HistoryFileWorker.SaveToFile("history2.xml", history);
        }

        public static void ReadHistoryFile()
        {
            var history = HistoryFileWorker.LoadFromFile("history.xml");
        }

        public static void TestCollectionAndHistory()
        {
            var history = HistoryFileWorker.LoadFromFile("history.xml");

            var collection = new BillingDataCollection(history);

            foreach (var data in collection.BillingDatas)
            {
                System.Console.WriteLine("Spent value - {0} USD", data.GetSpentValue());
            }
        }

        public static void LoadCollectionAndSaveToXml()
        {
            var history = HistoryFileWorker.LoadFromFile("history.xml");

            var collection = new BillingDataCollection(history);

            foreach (var data in collection.BillingDatas)
            {
                System.Console.WriteLine("Spent value - {0} USD", data.GetSpentValue());
            }

            BillingDataHelper.SaveDataToXmlFile("201305.xml", collection.BillingDatas[0]);
            BillingDataHelper.SaveDataToXmlFile("201306.xml", collection.BillingDatas[1]);
            BillingDataHelper.SaveDataToXmlFile("201307.xml", collection.BillingDatas[2]);
            BillingDataHelper.SaveDataToXmlFile("201308.xml", collection.BillingDatas[3]);
            BillingDataHelper.SaveDataToXmlFile("201309.xml", collection.BillingDatas[4]);
            BillingDataHelper.SaveDataToXmlFile("201310.xml", collection.BillingDatas[5]);
            BillingDataHelper.SaveDataToXmlFile("201311.xml", collection.BillingDatas[6]);
        }

        public static void TestCollectionAndHistory2()
        {
            var history = HistoryFileWorker.LoadFromFile("history2.xml");

            var collection = new BillingDataCollection(history);

            foreach (var data in collection.BillingDatas)
            {
                System.Console.WriteLine("Spent value - {0} USD", data.GetSpentValue());
            }
        }
    }
}
