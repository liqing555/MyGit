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
    public partial class FrmVipWH : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketVipMeberManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketVipMemberManager();
        public FrmVipWH()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            txtSelect.Focus();
            txtSelect.GotFocus += TxtSelect_GotFocus;
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            currentSMM = source.Current as SMMembers;
        }

        private void TxtSelect_GotFocus(object sender, EventArgs e)
        {
            txtSelect.SelectAll();
        }

        SMMembers currentSMM = null;
        BindingSource source = new BindingSource();
        List<SMMembers> members = null;
        SMMembers sm = null;
        private void CshVip()
        {
            members = manager.GetMembers();
            source.DataSource = members;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }
        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectOK_Click(object sender, EventArgs e)
        {
            //有条件的查询
            if (txtSelect.Text != "")
            {
                //通过卡号或者电话号查询
                if (txtSelect.CheckData(@"^[1-9]\d*$", "会员卡号有误") != 0)
                {
                    sm = manager.GetSMMemberByIdOrNum(txtSelect.Text.Trim());
                    source.DataSource = sm;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = source;
                    txtSelect.Text = "";
                }
                else if (txtSelect.CheckData(@"^[\u2E80-\u9FFF]+$", "姓名输入不正确") != 0)
                {
                    //通过姓名查询
                    sm = manager.GetMemberByrName(txtSelect.Text.Trim());
                    source.DataSource = sm;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = source;
                    txtSelect.Text = "";
                }
            }
            else
            {
                members = manager.GetMembers();
                CshVip();
            }
        }
        /// <summary>
        /// 修改会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateVid_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || currentSMM == null)
            {
                MessageBox.Show("请选择要修改的会员！", "提示");
            }
            FrmUpdateVip form = new FrmUpdateVip(currentSMM);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CshVip();
            }
        }
        /// <summary>
        /// 会员注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVipZX_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || currentSMM == null || currentSMM.MemberStatus == 1)
            {
                return;
            }
            currentSMM.MemberStatus = -1;
            if (manager.UpVIP(currentSMM))
            {
                CshVip();
            }
        }
        /// <summary>
        /// 会员激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVipOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || currentSMM == null || currentSMM.MemberStatus == 1)
            {
                return;
            }
            currentSMM.MemberStatus = 1;
            if (manager.UpVIP(currentSMM))
            {
                CshVip();
            }
        }
        /// <summary>
        /// 会员冻结
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVipStop_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || currentSMM == null || currentSMM.MemberStatus == 0 || currentSMM.MemberStatus == -1)
            {
                return;
            }
            currentSMM.MemberStatus = 0;
            if (manager.UpVIP(currentSMM))
            {
                CshVip();
            }
        }
    }
}
