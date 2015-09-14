using System.Linq;
using App.Common.Abstarct;

namespace App.Common.Tree
{
    /// <summary>
    /// Класс для реализации вспомогательного дерева с данными о подписках и периодах в них.
    /// </summary>
    public class BillingDataTree<TData, TCollection, TSubscription> 
        where TSubscription: ISubscriptionStatus
        where TData: IBillingData 
        where TCollection : IBillingDataCollection<TData, TSubscription>
    {
        private const string DefaultNodeName = "Subscriptions";

        /// <summary>
        /// Корень дерева.
        /// </summary>
        public BillingDataNode<TData> Root { get; set; }

        /// <summary>
        /// Инициализация пустого дерева с коренем и все.
        /// </summary>
        public BillingDataTree()
        {
            Root = new BillingDataNode<TData>(DefaultNodeName);
        }

        /// <summary>
        /// Инициализация дерева и его построения на основе данных из коллекции.
        /// </summary>
        /// <param name="collection">Коллекция с данными о файлах и их содержимым (прочитанным и разобранным).</param>
        public BillingDataTree(TCollection collection)
        {
            Root = new BillingDataNode<TData>(DefaultNodeName);
            BuildTree(collection);
        }

        /// <summary>
        /// Построение дерева из узлов с данными и списком подписок.
        /// </summary>
        /// <param name="collection">Коллекция для построения дерева.</param>
        public void BuildTree(TCollection collection)
        {
            // получение списка подписок для группировки периодов по ним в дереве
            var subscriptions = collection.GetSubscriptions();

            foreach (var subscription in subscriptions)
            {
                var node = Root.AddNode(subscription.SubscriptionName);

                // получение сведенйи о периодах оплаты для подписки
                var data = collection.GetBillingDataBySubscription(subscription);

                foreach (var billingData in data)
                {
                    if (billingData.GetSettlementPeriod() != null)
                        node.AddNode(billingData);
                }
            }
        }

        /// <summary>
        /// Перестройка дерева из узлов с данными и списком подписок.
        /// </summary>
        /// <param name="collection">Коллекция для построения дерева.</param>
        public void RebuildTree(TCollection collection)
        {
            Root = new BillingDataNode<TData>(DefaultNodeName);
            BuildTree(collection);
        }

        /// <summary>
        /// Поиск узла по названию.
        /// </summary>
        /// <param name="root">Корневой узел, с которого следует начинать рекурсивный поиск.</param>
        /// <param name="name">Название (текст) для поиска.</param>
        /// <returns>Возвращает найденный узел.</returns>
        /// <remarks>Используется при выборе узлов из дерева.</remarks>
        public BillingDataNode<TData> GetNodeByName(BillingDataNode<TData> root, string name)
        {
            // искать сразу следует во втором уровне вложенности, когда там есть данные у узлов, которые и собственно нужны

            BillingDataNode<TData> result = null;

            if (root == null || root.Name.Contains(name))
                return root;
            else
            {
                if (root != null && root.Nodes.Any())
                {
                    for (int i = 0; i < root.Nodes.Count() && result == null; i++)
                    {
                        result = GetNodeByName(root.Nodes[i], name);
                    }
                }
                return result;
            }
        }
    }
}
