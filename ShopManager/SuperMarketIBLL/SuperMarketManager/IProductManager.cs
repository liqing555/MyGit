﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketManager
{
    public interface ISuperMarketProductManager
    {
        List<ProductCategory> GetCategories();
        List<ProductUnit> GetUnit();

        bool InsertProduct(Produts products, ProductInventory inventory);
        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        List<Produts> GetAllProduct();

        Produts GetProductWithId(string id);

        bool UpdateIN(string id, int count);
        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        List<Produts> GetProductByWhere(int categoryId, string where);
        /// <summary>
        /// 更新折扣
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        bool SetProductDiscount(string id, float discount);
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        bool SetProductInfor(Produts products);
        /// <summary>
        /// 查询商品库存信息
        /// </summary>
        /// <returns></returns>
        List<ProductInventory> GetProductInventory();
        /// <summary>
        /// 根据条件查询库存
        /// </summary>
        /// <param name="where"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        List<ProductInventory> SelectProductInventory(string where, string unit);
        /// <summary>
        /// 修改最大库存最小库存
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateInventory(int min, int max, string id);
        /// <summary>
        /// 修改库存数量
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool UpdateInventoryNum(ProductInventory product, int count);
    }
}
