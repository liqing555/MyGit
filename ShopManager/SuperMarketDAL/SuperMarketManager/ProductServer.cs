using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIDAL.SuperMarketManager;
using SuperMarketModel;
using System.Data.SqlClient;

namespace SuperMarketDAL.SuperMarketManager
{
    public class ProductServer : IProductServer
    {
        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        public List<Produts> GetAllProduct()
        {
            string procName = "GetProducts";
            List<Produts> products = new List<Produts>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, null);
            while (reader.Read())
            {
                products.Add(new Produts()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    Unit = reader["Unit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    CategoryNmae = reader["CategoryNmae"].ToString(),
                    TotalCount = Convert.ToInt32(reader["TotalCount"])
                });
            }
            reader.Close();
            return products;
        }

        /// <summary>
        /// 商品分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetCategories()
        {
            string procName = "GetProductCategory";
            List<ProductCategory> products = new List<ProductCategory>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, null);
            while (reader.Read())
            {
                products.Add(new ProductCategory()
                {
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString()
                });
            }
            reader.Close();
            return products;
        }
        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Produts> GetProductByWhere(int categoryId, string where)
        {
            string procName = "GetProductByWhere";
            SqlParameter[] sp =
            {
                new SqlParameter("@category",categoryId),
                new SqlParameter("@where",where)
            };
            List<Produts> products = new List<Produts>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            while (reader.Read())
            {
                products.Add(new Produts()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    Unit = reader["Unit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    CategoryNmae = reader["CategoryNmae"].ToString(),
                    TotalCount = Convert.ToInt32(reader["TotalCount"])
                });
            }
            reader.Close();
            return products;
        }
        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <returns></returns>
        public List<ProductInventory> GetProductInventory()
        {
            string procName = "GetProductInventory";
            List<ProductInventory> products = new List<ProductInventory>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, null);
            while (reader.Read())
            {
                products.Add(new ProductInventory()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    MinCount = Convert.ToInt32(reader["MinCount"]),
                    TotalCount = Convert.ToInt32(reader["TotalCount"]),
                    MaxCount = Convert.ToInt32(reader["MaxCount"]),
                    StatusDesc = reader["StatusDesc"].ToString()
                });
            }
            reader.Close();
            return products;
        }

        public Produts GetProductWithId(string id)
        {
            string procName = "GetProductWithId";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@productId",id)
            };
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            Produts products = null;
            while (reader.Read())
            {
                products = new Produts()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryNmae = reader["CategoryNmae"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
            }
            reader.Close();
            return products;
        }

        /// <summary>
        /// 查询计量单位
        /// </summary>
        /// <returns></returns>
        public List<ProductUnit> GetUnit()
        {
            string procName = "GetProductUnit";
            List<ProductUnit> units = new List<ProductUnit>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, null);
            while (reader.Read())
            {
                units.Add(new ProductUnit()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Unit = reader["Unit"].ToString()
                });
            }
            reader.Close();
            return units;
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="products"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public bool InsertProduct(Produts products, ProductInventory inventory)
        {
            List<string> proc = new List<string>()
            {
                "InsertProduct",
                "InsertInventory"
            };
            List<SqlParameter[]> parameters = new List<SqlParameter[]>();
            SqlParameter[] prodps = new SqlParameter[]
            {
                new SqlParameter("@productId",products.ProductId),
                new SqlParameter("@productName",products.ProductName),
                new SqlParameter("@unitPrice",products.UnitPrice),
                new SqlParameter("@unit",products.Unit),
                new SqlParameter("@discount",products.Discount),
                new SqlParameter("@categoryId",products.CategoryId)
            };
            SqlParameter[] inventps = new SqlParameter[]
            {
                new SqlParameter("@productId",inventory.ProductId),
                new SqlParameter("@minCount",inventory.MinCount),
                new SqlParameter("@maxCount",inventory.MaxCount)
            };
            parameters.Add(prodps);
            parameters.Add(inventps);
            return SQLHelper.UpdateByTran(proc, parameters);
        }
        /// <summary>
        /// 根据条件查询商品
        /// </summary>
        /// <returns></returns>
        public List<ProductInventory> SelectProductInventory(string where, string unit)
        {
            string procName = "SelectProductInventory";
            SqlParameter[] sp =
            {
                new SqlParameter("@where",where),
                new SqlParameter("@unit", unit)
            };
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            List<ProductInventory> products = new List<ProductInventory>();
            while (reader.Read())
            {
                products.Add(new ProductInventory()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    MinCount = Convert.ToInt32(reader["MinCount"]),
                    TotalCount = Convert.ToInt32(reader["TotalCount"]),
                    MaxCount = Convert.ToInt32(reader["MaxCount"]),
                    StatusDesc = reader["StatusDesc"].ToString()
                });
            }
            reader.Close();
            return products;
        }

        /// <summary>
        /// 更新折扣
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public int SetProductDiscount(string id, float discount)
        {
            string procName = "SetProductDiscount";
            SqlParameter[] sp =
            {
                new SqlParameter("@discount",discount),
                new SqlParameter("@productId",id)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int SetProductInfor(Produts products)
        {
            string procName = "SetProductInfor";
            SqlParameter[] sp =
            {
                new SqlParameter("@productName",products.ProductName),
                new SqlParameter("@uniPrice",products.UnitPrice),
                new SqlParameter("@categoryId",products.CategoryId),
                new SqlParameter("@unit",products.Unit),
                new SqlParameter("@productId",products.ProductId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int UpdateIN(string id, int count)
        {
            string procName = "UpdateIN";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@productId",id),
                new SqlParameter("@count",count)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
        /// <summary>
        /// 修改最大库存最小库存
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateInventory(int min, int max, string id)
        {
            string procName = "UpdateInventory";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@minCount",min),
                new SqlParameter("@maxCount",max),
                new SqlParameter("@productId",id)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int UpdateInventoryNum(ProductInventory product, int count)
        {
            string procName = "UpdateInventoryNum";
            SqlParameter[] sp =
            {
                new SqlParameter("@count",count),
                new SqlParameter("@productId",product.ProductId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
    }
}
