using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMarketIBLL.SuperMarketCashier;
using SuperMarketBLL.SuperMarketCashier;
using SuperMarketModel;
using SuperMarketCommon;

namespace SuperMarketManger
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing += FrmMain_FormClosing;
            this.FormClosed += FrmMain_FormClosed;
            toollblUser.Text = $"【{Program.CurrentAdmin.AdminName}】";
            //将主窗体设置为MDI容器
            this.IsMdiContainer = true;
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath, "restart");
        }
        #region 负责开启功能窗体
        Form currentMDIChild = null;
        void ShowMDIChild(Form mdiForm)
        {
            if (currentMDIChild != null)
            {
                currentMDIChild.Close();
            }
            currentMDIChild = mdiForm;
            mdiForm.MdiParent = this;
            mdiForm.Parent = panel1;
            mdiForm.Left = panel1.Width / 2 - mdiForm.Width / 2;
            mdiForm.Top = panel1.Height / 2 - mdiForm.Height / 2;
            mdiForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mdiForm.Show();
        }
        #endregion

        #region 主程序退出
        private void toolMenuExitSys_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            IISuperMarketSaleManager saleManager = new SuperMarketSaleManager();
            LogHelper.Info($"[{Program.CurrentAdmin.LoginId}]退出程序！");
            saleManager.WriteSalesExitLog(Program.CurrentAdmin.LoginLogId);
        }
        #endregion

        #region 系统时间更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            toollblTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        #endregion


        #region 用户管理模块
        private void toolMenuUserManager_Click(object sender, EventArgs e)
        {
            AdminFrm.FrmAdmin admin = new AdminFrm.FrmAdmin();
            ShowMDIChild(admin);
        }
        #endregion

        #region 修改密码
        private void toolMenuUpdatePwd_Click(object sender, EventArgs e)
        {
            FrmUpdatePwd pwd = new FrmUpdatePwd();
            DialogResult Restart = pwd.ShowDialog();
            //密码修改成功，意味着需要重新登录
            if (Restart == DialogResult.OK)
            {
                LogHelper.Info($"[{Program.CurrentAdmin.LoginId}]成功修改密码");
                this.Close();//主线程关闭
                //修改密码之后重启
            }
        }

        #endregion

        #region 添加商品功能
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAddProduct addProduct = new FrmAddProduct();
            addProduct.FormClosed += AddProduct_FormClosed;
            ShowMDIChild(addProduct);
        }
        #endregion

        #region 商品入库功能
        Produts currentProduct = null;
        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmAddProduct frmAdd = sender as FrmAddProduct;
            if (frmAdd.DialogResult == DialogResult.OK)
            {
                currentProduct = frmAdd.Tag as Produts;
                frmAdd.DialogResult = DialogResult.Cancel;
                btnIntoProduct_Click(frmAdd, null);
            }
        }
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIntoProduct_Click(object sender, EventArgs e)
        {
            FrmIntoProduct intoProduct = new FrmIntoProduct();
            if (currentProduct != null)
            {
                intoProduct.txtProductId.Text = currentProduct.ProductId;
                intoProduct.txtProductName.Text = currentProduct.ProductName;
            }
            ShowMDIChild(intoProduct);
            currentProduct = null;
        }
        #endregion
        /// <summary>
        /// 库存管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            FrmInventory form = new FrmInventory();
            ShowDialog(form);
        }
        /// <summary>
        /// 商品维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            FrmProduct from = new FrmProduct();
            ShowDialog(from);
        }
        /// <summary>
        /// 会员维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProtectMember_Click(object sender, EventArgs e)
        {
            FrmVipWH from = new FrmVipWH();
            ShowDialog(from);
        }
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            FrmAddVip form = new FrmAddVip();
            ShowDialog(form);
        }
    }
}
