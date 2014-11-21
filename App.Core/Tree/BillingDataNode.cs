using System.Collections.Generic;

namespace App.Core.Tree
{
    /// <summary>
    /// Узел дерева, содержащий набор узлов дочерних.
    /// </summary>
    public class BillingDataNode
    {
        /// <summary>
        /// Данные в узле.
        /// </summary>
        public BillingData BillingData { get; set; }

        /// <summary>
        /// Название периода с данными о нем.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дочерние узлы дерева.
        /// </summary>
        public List<BillingDataNode> Nodes { get; set; }


        public BillingDataNode(string name)
        {
            Name = name;
            Nodes = new List<BillingDataNode>();
        }

        public BillingDataNode(BillingData data, string name)
        {
            BillingData = data;
            Name = name;
            Nodes = new List<BillingDataNode>();
        }

        /// <summary>
        /// Добавление узла, который содержит только название.
        /// </summary>
        /// <param name="text">Текст для названия узла.</param>
        /// <returns>Возвращает созданный узел.</returns>
        public BillingDataNode AddNode(string text)
        {
            var node = new BillingDataNode(text);

            Nodes.Add(node);

            return node;
        }

        /// <summary>
        /// Добавление узла с данными, которые можно будет просматривать.
        /// </summary>
        /// <param name="data">Данные для добавления их в узел.</param>
        /// <returns>Возвращает созданный узел.</returns>
        public BillingDataNode AddNode(BillingData data)
        {
            var node = new BillingDataNode(data, data.GetSettlementPeriod());

            Nodes.Add(node);

            return node;
        }
    }
}
