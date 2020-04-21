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
    public partial class FrmAddAdmin : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketAdminManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketAdminManager();
        public FrmAddAdmin()
        {
            InitializeComponent();
            txtName.Focus();
            txtPwd.GotFocus += TxtPwd_GotFocus;
        }

        private void TxtPwd_GotFocus(object sender, EventArgs e)
        {
            txtPwd.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.CheckNullOrEmpty() * txtPwd.CheckData(@"^\w{6.}$", "密码必须为6为字母，数字，下划线组合") == 0)
            {
                return;
            }
            else
            {
                SysAdmins sys = new SysAdmins()
                {
                    AdminName = txtName.Text.Trim(),
                    LoginPwd = txtPwd.Text.Trim(),
                    AdminStatus = 1,
                    RoleId = comboBox1.SelectedIndex + 1
                };
                sys = manager.InsertAdmin(sys);
                if (sys == null)
                {
                    MessageBox.Show("添加成功！", "提示");
                }
                else
                {
                    if (MessageBox.Show($"添加成功！登录账号为【{sys.LoginId}】\r\n是否继续添加", "提示") == DialogResult.Yes)
                    {
                        txtName.Text = "";
                        txtPwd.Text = "123456";
                        comboBox1.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
