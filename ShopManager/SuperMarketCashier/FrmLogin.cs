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
using SuperMarketIBLL;
using System.Net;

namespace SuperMarketCashier
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        SuperMarketIBLL.SuperMarketCashier.IISuperMarketSaleManager manager = new SuperMarketBLL.SuperMarketCashier.SuperMarketSaleManager();
        //登录
        private void btnLog_Click(object sender, EventArgs e)
        {
            //【1】文本框数据的验证
            //如果为0则有必填项未填写
            if (txtLogId.CheckData(@"^[1-9]\d*$", "账号格式为纯数字！") *txtLogPwd.CheckNullOrEmpty()!= 0)
            {
                //【2】登录账号和密码封装成收银员对象
                SalePerson person = new SalePerson()
                {
                    SalePersonId = int.Parse(txtLogId.Text),
                    LoginPwd = txtLogPwd.Text.Trim()
                }; 
                //【3】数据库中查询
                SalePerson res = manager.SaleLogin(person);
                if (res != null)//证明登录成功
                {
                    //(1)将登录对象保存到全局
                    Program.Sale = res;
                    //(2)将登录信息记录进系统日志
                    int logId = manager.WriteSalesLog(new LoginLogs()
                    {
                        LoginId = res.SalePersonId,
                        SPName = res.SPName,
                        ServerName = Dns.GetHostName()
                    });
                    Program.Sale.LogId = logId;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("账号或密码错误!", "登录提示");
                }
            }
        }
        //取消
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
