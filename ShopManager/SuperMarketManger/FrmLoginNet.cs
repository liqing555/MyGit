using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMarketCommon;
using SuperMarketModel;
using SuperMarketBLL;

namespace SuperMarketManger
{
    public partial class FrmLoginNet : Form
    {
        SuperMarketIBLL.SuperMarketManager.ISuperMarketLoginMemberManager manager = new SuperMarketBLL.SuperMarketManager.SuperMarketLoginMemberManager();
        public FrmLoginNet()
        {
            InitializeComponent();
            startTime.Focus();
            txtwhere.GotFocus += Txtwhere_GotFocus;
            txtwhere.LostFocus += Txtwhere_LostFocus;
            txtwhere.TextChanged += Txtwhere_TextChanged;
            logs = manager.GetLoginLogs();
            CshPage();
        }

        private void Txtwhere_TextChanged(object sender, EventArgs e)
        {
            txtwhere.Tag = "0";
        }

        private void Txtwhere_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtwhere.Text))
            {
                txtwhere.Text = "姓名，账号，服务器名";
                txtwhere.Tag = "1";
                txtwhere.ForeColor = Color.Gray;
            }
        }

        private void Txtwhere_GotFocus(object sender, EventArgs e)
        {
            txtwhere.SelectAll();
            txtwhere.ForeColor = Color.Black;
        }

        List<LoginLogs> logs = null;
        List<LoginLogs> currentpage = null;
        BindingSource source = new BindingSource();
        private void CshPage()
        {
            if (logs == null)
            {
                MessageBox.Show("暂无任何登录记录！", "提示");
                return;
            }
            else
            {
                setPage1.RecordCount = logs.Count;
                setPage1.CurrentPageIndex = 1;
                setPage1.SortString = SortString.ASC;
                setPage1.PageSize = 15;
                setPage1.ExceuteSetPageEvent += SetPage1_ExceuteSetPageEvent;
                setPage1.FistSerch();
            }

        }

        private void SetPage1_ExceuteSetPageEvent(int currentPage)
        {
            if (logs != null)
            {
                currentpage = logs.Skip((setPage1.CurrentPageIndex - 1) * setPage1.PageSize).Take(setPage1.PageSize).ToList();
                source.DataSource = currentpage;
                dataGridView1.DataSource = source;
                setPage1.SetButtonEnable();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //没有输入条件,不需要根据时间查询
            if (txtwhere.Tag.ToString() == "1" && checkBox1.Checked == false)
            {
                logs = manager.GetLoginLogs();
                setPage1.RecordCount = logs.Count;
                setPage1.FistSerch();
            }
            else
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                string where = "";
                int check = 0;
                //按照时间查询
                if (checkBox1.Checked == true)
                {
                    check = 1;
                    //不带条件
                    if (txtwhere.Tag.ToString() == "1")
                    {
                        if (startTime.Value.CompareTo(endTime.Value) < 0)//早于
                        {
                            start = Convert.ToDateTime(startTime.Value.ToShortDateString());
                            end = Convert.ToDateTime(endTime.Value.ToShortDateString()).AddDays(1);
                        }

                        else if (startTime.Value.CompareTo(endTime.Value) == 0)//等于
                        {
                            check = 0;
                            start = Convert.ToDateTime(startTime.Value.ToShortDateString());
                            end = Convert.ToDateTime(startTime.Value.ToShortDateString());
                        }
                        else if (startTime.Value.CompareTo(endTime.Value) > 0)//晚于
                        {
                            check = -1;
                            start = startTime.Value;
                        }
                    }
                    else
                    {
                        where = txtwhere.Text.Trim();
                    }
                }
                //不按照区间查询
                else
                {
                    check = 0;
                    where = txtwhere.Text.Trim();
                }
                logs = manager.GetLoginLogBy(start, end, where, check);
                setPage1.RecordCount = logs.Count;
                setPage1.FistSerch();
            }
        }
    }
}
