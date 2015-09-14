using System.Collections.Generic;
using App.Common.Abstarct;

namespace App.Common.Tree
{
    /// <summary>
    /// Узел дерева, содержащий набор узлов дочерних.
    /// </summary>
    public class BillingDataNode<TData> where TData : IBillingData
    {
        /// <summary>
        /// Данные в узле.
        /// </summary>
        public TData BillingData { get; set; }

        /// <summary>
        /// Название периода с данными о нем.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дочерние узлы дерева.
        /// </summary>
        public List<BillingDataNode<TData>> Nodes { get; set; }


        public BillingDataNode(string name)
        {
            Name = name;
            Nodes = new List<BillingDataNode<TData>>();
        }

        public BillingDataNode(TData data, string name)
        {
            BillingData = data;
            Name = name;
            Nodes = new List<BillingDataNode<TData>>();
        }

        /// <summary>
        /// Добавление узла, который содержит только название.
        /// </summary>
        /// <param name="text">Текст для названия узла.</param>
        /// <returns>Возвращает созданный узел.</returns>
        public BillingDataNode<TData> AddNode(string text)
        {
            var node = new BillingDataNode<TData>(text);

            Nodes.Add(node);

            return node;
        }

        /// <summary>
        /// Добавление узла с данными, которые можно будет просматривать.
        /// </summary>
        /// <param name="data">Данные для добавления их в узел.</param>
        /// <returns>Возвращает созданный узел.</returns>
        public BillingDataNode<TData> AddNode(TData data)
        {
            var node = new BillingDataNode<TData>(data, data.GetSettlementPeriod());

            Nodes.Add(node);

            return node;
        }
    }
}
