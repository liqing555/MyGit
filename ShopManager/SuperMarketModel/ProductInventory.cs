using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketModel
{
    [Serializable]
    public class ProductInventory
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// 最大库存
        /// </summary>
        public int MaxCount { get; set; }
        /// <summary>
        /// 库存状态
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// 库存状态信息
        /// </summary>
        public string StatusDesc { get; set; }
        //扩展属性
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
