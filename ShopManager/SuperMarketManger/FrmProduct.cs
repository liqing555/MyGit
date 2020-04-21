using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMarketBLL;
using SuperMarketModel;

namespace SuperMarketManger
{
    public partial class FrmProduct : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketProductManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketProductManager();
        public FrmProduct()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            categories = manager.GetCategories();
            comProduct.Items.Add("所有");
            foreach (ProductCategory item in categories)
            {
                comProduct.Items.Add(item.CategoryName);
            }
            comProduct.SelectedIndex = 0;
            products = manager.GetAllProduct();
            CshProduct();
            source.CurrentChanged += Source_CurrentChanged;
            txtProduct.TextChanged += TxtProduct_TextChanged;
            txtProduct.GotFocus += TxtProduct_GotFocus;
            txtProduct.LostFocus += TxtProduct_LostFocus;
        }

        private void TxtProduct_LostFocus(object sender, EventArgs e)
        {
            txtProduct.ForeColor = Color.Black;
        }

        private void TxtProduct_GotFocus(object sender, EventArgs e)
        {
            txtProduct.SelectAll();
            txtProduct.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            txtProduct.Tag = "1";
        }

        public Produts currentProduct { get; set; }
        List<Produts> products = null;
        List<ProductCategory> categories = null;
        BindingSource source = new BindingSource();
        /// <summary>
        /// 商品初始化
        /// </summary>
        private void CshProduct()
        {

            source.DataSource = products;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolProductRK_Click(object sender, EventArgs e)
        {
            FrmIntoProduct form = new FrmIntoProduct();
            form.ShowDialog();
            CshProduct();
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolProductADD_Click(object sender, EventArgs e)
        {
            FrmAddProduct form = new FrmAddProduct();
            form.ShowDialog();
            CshProduct();
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolProductUpdate_Click(object sender, EventArgs e)
        {
            if (products.Count == 0 || currentProduct == null)
            {
                MessageBox.Show("请选择要修改的商品！", "提示");
                return;
            }
            FrmUpdateProduct form = new FrmUpdateProduct(currentProduct);
            if (form.ShowDialog() == DialogResult.OK)
            {
                products = manager.GetAllProduct();
                CshProduct();
            }
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void toolProductDel_Click(object sender, EventArgs e)
        {
            if (products.Count <= 0)
            {
                return;
            }
            source.DataSource = products;
            dataGridView1.DataSource = source;
        }

        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            var selectIndex = from item in categories where item.CategoryName == comProduct.SelectedItem.ToString() select item.CategoryId;
            int index = 0;
            string where = txtProduct.Text.Trim();
            //没有条件的查询
            if (txtProduct.Tag.ToString() == "0" && selectIndex.FirstOrDefault() == 0)
            {
                products = manager.GetAllProduct();
                CshProduct();
                return;
            }
            else if (txtProduct.Tag.ToString() == "0" && selectIndex.FirstOrDefault() != 0)
            {
                where = "";
                index = selectIndex.FirstOrDefault();
            }
            else if (txtProduct.Tag.ToString() != "0" && selectIndex.FirstOrDefault() == 0)
            {
                where = txtProduct.Text.Trim();
                index = 0;
            }
            else if (txtProduct.Tag.ToString() != "0" && selectIndex.FirstOrDefault() != 0)
            {
                where = txtProduct.Text.Trim();
                index = selectIndex.FirstOrDefault();
            }
            products = manager.GetProductByWhere(index, where);
            CshProduct();
            txtProduct.Text = "商品名称，商品编号";
            comProduct.SelectedIndex = 0;
            txtProduct.Tag = 0;
        }
        /// <summary>
        /// 更新折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnit_Click(object sender, EventArgs e)
        {
            if (txtDis.CheckData(@"^\d(.\d)?$", "输入有误") != 0)
            {
                if (currentProduct != null)
                {
                    if (manager.SetProductDiscount(currentProduct.ProductId, Convert.ToSingle(txtDis.Text.Trim())))
                    {
                        currentProduct.Discount = Convert.ToSingle(txtDis.Text.Trim());
                        CshProduct();
                        txtDis.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("商品修改失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择要更改的商品", "提示");
                }
            }
        }
    }
}
