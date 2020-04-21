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
    public partial class FrmUpdateVip : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketVipMeberManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketVipMemberManager();
        public FrmUpdateVip(SMMembers member)
        {
            InitializeComponent();
            txtName.Focus();
            txtId.Text = member.MemberId.ToString();
            txtName.GotFocus += TxtName_GotFocus;
            txtNumber.GotFocus += TxtName_GotFocus;
            txtAddress.GotFocus += TxtName_GotFocus;
            members = member;
        }
        SMMembers members = null;
        private void TxtName_GotFocus(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtNumber.CheckData(@"^1\d{10}$", "手机号格式有误") != 0)
            {
                members.MemberName = txtName.Text.Trim();
                members.PhoneNumber = txtNumber.Text.Trim();
                members.MemberAddress = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? "地址不详" : txtAddress.Text.Trim();
                if (manager.UpdateVip(members) != false)
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
