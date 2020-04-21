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

namespace SuperMarketManger.AdminFrm
{
    public partial class FrmAdmin : Form
    {

        SuperMarketIBLL.SuperMarketManager.ISuperMarketAdminManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketAdminManager();
        public FrmAdmin()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            CshAdmin();
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            currentAdm = source.Current as SysAdmins;
        }

        List<SysAdmins> admins = null;
        BindingSource source = new BindingSource();
        private void CshAdmin()
        {
            admins = manager.GetAllTables();
            source.DataSource = admins;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }
        SysAdmins currentAdm = null;
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 || currentAdm == null || currentAdm.RoleId == 1)
            {
                return;
            }
            currentAdm.AdminStatus = 0;
            if (manager.SetSysAdminRole(currentAdm))
            {
                CshAdmin();
            }
        }
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 || currentAdm == null || currentAdm.RoleId == 1)
            {
                return;
            }
            currentAdm.AdminStatus = 1;
            if (manager.SetSysAdminRole(currentAdm))
            {
                CshAdmin();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 || currentAdm == null)
            {
                MessageBox.Show("请选择需要修改的管理员！", "提示");
                return;
            }
            FrmUpdateAdmin form = new FrmUpdateAdmin(currentAdm);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CshAdmin();
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSys_Click(object sender, EventArgs e)
        {
            FrmAddAdmin form = new FrmAddAdmin();
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                CshAdmin();
            }
        }
    }
}
