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
    public partial class FrmUpdateSale : Form
    {
        SuperMarketIBLL.SuperMarketCashier.IISuperMarketSaleManager manager = new SuperMarketBLL.SuperMarketCashier.SuperMarketSaleManager();
        public FrmUpdateSale(SalePerson person)
        {
            InitializeComponent();
            txtName.Text = person.SPName;
            txtPwd.Text = person.LoginPwd;
            sales = person;
        }
        public SalePerson sales { get; set; }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtPwd.CheckData(@"^\w{6.}$", "密码格式不正确！") != 0)
            {
                sales.SPName = txtName.Text.Trim();
                sales.LoginPwd = txtPwd.Text.Trim();
                if (manager.UpdateSale(sales) != null)
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
