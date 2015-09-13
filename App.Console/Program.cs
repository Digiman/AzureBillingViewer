namespace App.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            //CoreTest.LoadBillingData();

            CoreTest.CreateHistoryFile();
            CoreTest.CreateHistoryFile2();
            //CoreTest.ReadHistoryFile();
            
            CoreTest.TestCollectionAndHistory();

            CoreTest.LoadCollectionAndSaveToXml();

            CoreTest.TestCollectionAndHistory2();

            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }
    }
}
