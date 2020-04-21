using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMarketModel;
using SuperMarketBLL;

namespace SuperMarketManger
{
    public partial class FrmInventory : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketProductManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketProductManager();
        public FrmInventory()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            CshInventory();
            manager.GetCategories();
            source.MoveLast();
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            currentPro = source.Current as ProductInventory;
        }

        ProductInventory currentPro = null;
        List<ProductInventory> products = null;
        List<ProductCategory> categories = null;
        BindingSource source = new BindingSource();
        BindingSource source1 = new BindingSource();
        private void CshInventory()
        {
            products = manager.GetProductInventory();
            source.DataSource = products;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
            categories = manager.GetCategories();
            source1.DataSource = categories;
            comFL.DataSource = source1;
            comFL.DisplayMember = "CategoryName";
            comFL.ValueMember = "CategoryId";
        }
        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string where = txtWhere.Text.Trim();
            string unit = (from item in categories where item.CategoryId == Convert.ToInt32(comFL.SelectedValue) select item.CategoryName).FirstOrDefault();

            //如果没有查询条件查询全部
            if (string.IsNullOrEmpty(txtWhere.Text.Trim()) && checkBox1.Checked == false)
            {
                CshInventory();
            }
            //根据输入的条件查询
            else if (!string.IsNullOrEmpty(txtWhere.Text.Trim()) && checkBox1.Checked == false)
            {
                products = manager.SelectProductInventory(where, "");
            }
            //根据分类查询
            else if (string.IsNullOrEmpty(txtWhere.Text.Trim()) && checkBox1.Checked == true)
            {
                products = manager.SelectProductInventory("", unit);
            }
            //根据输入的条件还有分类查询
            else if (!string.IsNullOrEmpty(txtWhere.Text.Trim()) && checkBox1.Checked == true)
            {
                products = manager.SelectProductInventory(where, unit);
            }
            source.DataSource = products;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }
        /// <summary>
        /// 高于库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCX_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 修改库存大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtMax.Text.Trim()) > currentPro.MinCount || Convert.ToInt32(txtMax.Text.Trim()) != currentPro.MaxCount || Convert.ToInt32(txtMin.Text.Trim()) != currentPro.MinCount || Convert.ToInt32(txtMin.Text.Trim()) < currentPro.MaxCount)
            {
                if (!string.IsNullOrEmpty(txtMax.Text.Trim()) && string.IsNullOrEmpty(txtMin.Text.Trim()))
                {
                    if (manager.UpdateInventory(currentPro.MinCount, Convert.ToInt32(txtMax.Text.Trim()), currentPro.ProductId))
                    {
                        MessageBox.Show("修改最大库存成功！", "提示");
                        CshInventory();
                        txtMax.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("修改失败！", "提示");
                    }
                }
                else if (!string.IsNullOrEmpty(txtMin.Text.Trim()) && string.IsNullOrEmpty(txtMax.Text.Trim()))
                {
                    if (manager.UpdateInventory(Convert.ToInt32(txtMin.Text.Trim()), currentPro.MaxCount, currentPro.ProductId))
                    {
                        MessageBox.Show("修改最小库存成功！", "提示");
                        CshInventory();
                        txtMax.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("修改失败！", "提示");
                    }
                }
                else if (!string.IsNullOrEmpty(txtMin.Text.Trim()) && !string.IsNullOrEmpty(txtMax.Text.Trim()) && Convert.ToInt32(txtMax.Text.Trim()) > Convert.ToInt32(txtMin.Text.Trim()))
                {
                    if (manager.UpdateInventory(Convert.ToInt32(txtMin.Text.Trim()), Convert.ToInt32(txtMax.Text.Trim()), currentPro.ProductId))
                    {
                        MessageBox.Show("修改最大和最小库存成功！", "提示");
                        CshInventory();
                        txtMax.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("修改失败！", "提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("您输入的库存大小有误！", "提示");
            }
        }
        /// <summary>
        /// 修改库存数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtCCSL.CheckData(@"^\d+$", "数量输入有误！") * txtCCSL.CheckNullOrEmpty() != 0)
            {
                if (manager.UpdateInventoryNum(currentPro, Convert.ToInt32(txtCCSL.Text.Trim())))
                {
                    MessageBox.Show("库存数量修改成功！", "提示");
                    CshInventory();
                    txtCCSL.Text = "";
                }
                else
                {
                    MessageBox.Show("库存数量修改失败！", "提示");
                }
            }
        }
    }
}
