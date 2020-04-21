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
    public partial class FrmAddSale : Form
    {
        SuperMarketIBLL.SuperMarketCashier.IISuperMarketSaleManager manager = new SuperMarketBLL.SuperMarketCashier.SuperMarketSaleManager();
        public FrmAddSale()
        {
            InitializeComponent();
            txtName.Focus();
            txtPwd.GotFocus += TxtPwd_GotFocus;
        }

        private void TxtPwd_GotFocus(object sender, EventArgs e)
        {
            txtPwd.SelectAll();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtPwd.CheckData(@"^\w{6.}$", "密码必须为6为字母，数字，下划线组合") == 0)
            {
                return;
            }
            else
            {
                SalePerson sales = new SalePerson()
                {
                    SPName = txtName.Text.Trim(),
                    LoginPwd = txtPwd.Text.Trim()
                };
                sales = manager.InsertSale(sales);
                if (sales == null)
                {
                    MessageBox.Show("添加失败！", "提示");
                }
                else
                {
                    if (MessageBox.Show($"添加销售员成功！登陆账号为【{sales.SalePersonId}】\r\n是否继续添加", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtName.Text = "";
                        txtPwd.Text = "123456";
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
