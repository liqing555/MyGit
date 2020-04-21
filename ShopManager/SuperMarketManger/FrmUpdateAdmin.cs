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
    public partial class FrmUpdateAdmin : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketAdminManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketAdminManager();
        public FrmUpdateAdmin(SysAdmins admins)
        {
            InitializeComponent();
            txtAdminId.Text = admins.LoginId.ToString();
            txtName.Text = admins.AdminName;
            this.Text = $"修改【{admins.AdminName}】的信息";
            txtPwd.Text = admins.LoginPwd;
            comboBox1.SelectedIndex = admins.RoleId - 1;
            currentAdmin = admins;
            txtName.Focus();
            txtName.GotFocus += TxtName_GotFocus;
            txtPwd.GotFocus += TxtName_GotFocus;
        }
        public SysAdmins currentAdmin { get; set; }
        private void TxtName_GotFocus(object sender, EventArgs e)
        {
            SuperText text = sender as SuperText;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtPwd.CheckData(@"^\w{6.}$", "密码必须为6为字母，数字，下划线组合") == 0)
            {
                return;
            }
            else
            {
                currentAdmin.AdminName = txtName.Text.Trim();
                currentAdmin.LoginPwd = txtPwd.Text.Trim();
                currentAdmin.RoleId = comboBox1.SelectedIndex + 1;
                currentAdmin = manager.UpdateAdmin(currentAdmin);
                if (currentAdmin == null)
                {
                    MessageBox.Show("修改失败！", "提示");
                }
                else
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
