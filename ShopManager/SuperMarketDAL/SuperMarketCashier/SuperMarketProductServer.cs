using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIDAL.SuperMarketCashier;
using SuperMarketModel;
using System.Data;
using System.Data.SqlClient;

namespace SuperMarketDAL.SuperMarketCashier
{
    public class SuperMarketProductServer : ISuperMarketProductServer
    {
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns></returns>
        public Produts GetProductWithId(string productId)
        {
            string procName = "GetProductWithId";
            SqlParameter[] sp =
            {
                new SqlParameter("@productId", SqlDbType.NVarChar,50)
            };
            sp[0].Value = productId;
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            Produts products = null;
            while (reader.Read())
            {
                products = new Produts()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    Unit = reader["Unit"].ToString(),
                    Discount = Convert.ToInt32(reader["Discount"]),
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryNmae = reader["CategoryNmae"].ToString()
                };
            }
            reader.Close();
            return products;
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public bool SaveSalerInfo(SalesList sales, SMMembers members)
        {
            List<string> procList = new List<string>();
            List<SqlParameter[]> psList = new List<SqlParameter[]>();
            //给消费主表中添加数据
            procList.Add("AddSalesList");
            SqlParameter[] saleSp = new SqlParameter[]
            {
                new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
                new SqlParameter("@TotalMoney", SqlDbType.Decimal),
                new SqlParameter("@RealReceive", SqlDbType.Decimal),
                new SqlParameter("@ReturnMoney", SqlDbType.Decimal),
                new SqlParameter("@SalesPersonId", SqlDbType.Int)
            };
            saleSp[0].Value = sales.SerialNum;
            saleSp[1].Value = sales.TotalMoney;
            saleSp[2].Value = sales.RealReceive;
            saleSp[3].Value = sales.ReturnMoney;
            saleSp[4].Value = sales.SalesPersonId;
            psList.Add(saleSp);
            //给消费明细表中添加每次购物的详细数据
            foreach (SalesListDetail item in sales.salesLists)
            {
                procList.Add("AddSalesListDetail");
                SqlParameter[] sp = new SqlParameter[]
                {
                new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
                new SqlParameter("@ProductId", SqlDbType.NVarChar,50),
                new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
                new SqlParameter("@UnitPrice", SqlDbType.Decimal),
                new SqlParameter("@Discount", SqlDbType.Int),
                new SqlParameter("@Quantity", SqlDbType.Int),
                new SqlParameter("@SubTotalMoney", SqlDbType.Decimal)
                };
                sp[0].Value = item.SerialNum;
                sp[1].Value = item.ProductId;
                sp[2].Value = item.ProductName;
                sp[3].Value = item.UnitPrice;
                sp[4].Value = item.Discount;
                sp[5].Value = item.Quantity;
                sp[6].Value = item.SubTotalMoney;
                psList.Add(sp);
            }
            //更新会员的积分
            if (members != null)
            {
                procList.Add("RefreshMemberPoint");
                SqlParameter[] sp = new SqlParameter[]
                {
                new SqlParameter("@point", SqlDbType.Int),
                new SqlParameter("@memberId", SqlDbType.Int)
                };
                sp[0].Value = members.Points;
                sp[1].Value = members.MemberId;
                psList.Add(sp);
            }
            return SQLHelper.UpdateByTran(procList, psList);
        }
    }
}
