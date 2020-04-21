using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIDAL.SuperMarketManager
{
    public interface IProductServer
    {
        /// <summary>
        /// 商品分类
        /// </summary>
        /// <returns></returns>
        List<ProductCategory> GetCategories();
        /// <summary>
        /// 计量单位
        /// </summary>
        /// <returns></returns>
        List<ProductUnit> GetUnit();

        bool InsertProduct(Produts products, ProductInventory inventory);

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <returns></returns>
        List<Produts> GetAllProduct();

        Produts GetProductWithId(string id);
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int UpdateIN(string id, int count);

        List<Produts> GetProductByWhere(int categoryId, string where);

        int SetProductDiscount(string id, float discount);
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        int SetProductInfor(Produts products);
        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <returns></returns>
        List<ProductInventory> GetProductInventory();
        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <returns></returns>
        List<ProductInventory> SelectProductInventory(string where, string unit);
        /// <summary>
        /// 修改最大库存最小库存
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateInventory(int min, int max, string id);
        /// <summary>
        /// 修改库存数量
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int UpdateInventoryNum(ProductInventory product, int count);
    }
}
