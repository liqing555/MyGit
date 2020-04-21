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
using SuperMarketCommon;

namespace SuperMarketManger
{
    public partial class FrmUpdateProduct : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketProductManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketProductManager();
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();
        public FrmUpdateProduct(Produts products)
        {
            InitializeComponent();
            txtProductName.Focus();
            Categories = manager.GetCategories();
            source.DataSource = Categories;
            comCategory.DataSource = source;
            comCategory.DisplayMember = "CategoryName";
            comCategory.ValueMember = "CategoryId";
            comCategory.SelectedIndex = products.CategoryId - 1;
            units = manager.GetUnit();
            source1.DataSource = units;
            comUnit.DataSource = source1;
            comUnit.DisplayMember = "Unit";
            comUnit.ValueMember = "Id";
            comUnit.SelectedIndex = (from item in units where item.Unit == products.Unit select item.Id).FirstOrDefault() - 1;

            if (Categories.Count == 0 || units.Count == 0)
            {
                return;
            }
            txtProdunctId.Text = products.ProductId;
            txtProductName.Text = products.ProductName;
            txtUnitPrice.Text = products.UnitPrice.ToString("F2");
            currentProduct = products;
            txtProdunctId.GotFocus += TxtProdunctId_GotFocus;
            txtProductName.GotFocus += TxtProdunctId_GotFocus;
            txtUnitPrice.GotFocus += TxtProdunctId_GotFocus;
        }

        private void TxtProdunctId_GotFocus(object sender, EventArgs e)
        {
            SuperText text = sender as SuperText;
            text.SelectAll();
        }

        List<ProductCategory> Categories = null;
        List<ProductUnit> units = null;
        public Produts currentProduct { get; set; }
        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtProdunctId.CheckData(@"^\d(6.)$", "商品编号格式不正确！") * txtProductName.CheckNullOrEmpty() * txtUnitPrice.CheckData(@"^\d*(.\d\d?)+$", "单价格式错误！") != 0)
            {
                currentProduct.ProductId = txtProdunctId.Text.Trim();
                currentProduct.ProductName = txtProductName.Text.Trim();
                currentProduct.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                currentProduct.CategoryId = (from item in Categories where item.CategoryId == Convert.ToInt32(comCategory.SelectedValue) select item.CategoryId).FirstOrDefault();
                currentProduct.Unit = (from item in units where item.Id == comUnit.SelectedIndex + 1 select item.Unit).FirstOrDefault();
                if (manager.SetProductInfor(currentProduct))
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败！", "提示");
                }
            }
        }
        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
