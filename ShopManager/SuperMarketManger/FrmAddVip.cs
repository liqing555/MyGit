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
    public partial class FrmAddVip : Form
    {
        public FrmAddVip()
        {
            InitializeComponent();
            txtName.Focus();
        }
        SuperMarketIBLL.SuperMarketManager.ISuperMarketVipMeberManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketVipMemberManager();
        /// <summary>
        /// 确认注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZC_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtMumber.CheckData(@"^1\d{10}$", "手机号格式有误") != 0)
            {
                if (manager.GetSMMemberByIdOrPhone(txtMumber.Text.Trim()) != null)
                {
                    MessageBox.Show("手机号已经注册时会员！", "提示");
                }
                SMMembers members = new SMMembers()
                {
                    MemberName = txtName.Text.Trim(),
                    PhoneNumber = txtMumber.Text.Trim(),
                    MemberAddress = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? "地址不详" : txtAddress.Text.Trim()
                };
                if (manager.addMembers(members) != null)
                {
                    if (MessageBox.Show($"会员注册成功！账号是【{members.MemberId}】\r\n是否继续注册", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtName.Text = "";
                        txtMumber.Text = "";
                        txtAddress.Text = "";
                        txtName.Focus();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("会员注册失败！", "提示");
                }
            }
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
