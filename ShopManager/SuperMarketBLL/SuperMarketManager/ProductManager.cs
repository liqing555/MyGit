using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using SuperMarketIBLL.SuperMarketManager;
using SuperMarketDAL.SuperMarketManager;
using SuperMarketIDAL.SuperMarketManager;

namespace SuperMarketBLL.SuperMarketManager
{
    public class SuperMarketProductManager : ISuperMarketProductManager
    {
        IProductServer servers = new ProductServer();

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        public List<Produts> GetAllProduct()
        {
            return servers.GetAllProduct();
        }

        /// <summary>
        /// 商品分类业务逻辑
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetCategories()
        {
            return servers.GetCategories();
        }
        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Produts> GetProductByWhere(int categoryId, string where)
        {
            return servers.GetProductByWhere(categoryId, where);
        }
        /// <summary>
        /// 查询商品库存信息
        /// </summary>
        /// <returns></returns>
        public List<ProductInventory> GetProductInventory()
        {
            return servers.GetProductInventory();
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produts GetProductWithId(string id)
        {
            return servers.GetProductWithId(id);
        }

        /// <summary>
        /// 查询计量单位业务逻辑
        /// </summary>
        /// <returns></returns>
        public List<ProductUnit> GetUnit()
        {
            return servers.GetUnit();
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="products"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public bool InsertProduct(Produts products, ProductInventory inventory)
        {
            return servers.InsertProduct(products, inventory);
        }
        /// <summary>
        /// 根据条件查询商品库存
        /// </summary>
        /// <param name="where"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public List<ProductInventory> SelectProductInventory(string where, string unit)
        {
            return servers.SelectProductInventory(where, unit);
        }

        /// <summary>
        /// 更新折扣
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public bool SetProductDiscount(string id, float discount)
        {
            if (servers.SetProductDiscount(id, discount) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public bool SetProductInfor(Produts products)
        {
            if (servers.SetProductInfor(products) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 商品入库后修改数据库数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool UpdateIN(string id, int count)
        {
            if (servers.UpdateIN(id, count) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateInventory(int min, int max, string id)
        {
            if (servers.UpdateInventory(min, max, id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改库存数量
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateInventoryNum(ProductInventory product, int count)
        {
            if (servers.UpdateInventoryNum(product, count) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
