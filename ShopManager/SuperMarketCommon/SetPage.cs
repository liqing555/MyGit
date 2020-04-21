using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketCommon
{
    public enum SortString
    {
        DESC,
        ASC
    }
    //声明委托
    public delegate void PagerQueryDelegate(int currentPage);

    public partial class SetPage : UserControl
    {
        public event PagerQueryDelegate ExceuteSetPageEvent;
        public SetPage()
        {
            InitializeComponent();
            btnFirst.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnEnd.Enabled = false;
            btnReturn.Enabled = false;
        }

        /// <summary>
        /// 查询分页的存储过程名称
        /// </summary>
        public string ProcName { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public SortString SortString { get; set; } = SortString.ASC;
        /// <summary>
        /// 总数据条数
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 每页的数据条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 分页的表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 获取表的总数据页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (RecordCount % PageSize == 0)
                {
                    return RecordCount / PageSize;
                }
                else
                {
                    return (RecordCount / PageSize) + 1;
                }
            }
        }
        void ShowInfo()
        {
            lblPage.Text = CurrentPageIndex.ToString();
            lblCountPage.Text = PageCount.ToString();
        }
        /// <summary>
        /// 设置当前按钮的状态
        /// </summary>
        public void SetButtonEnable()
        {
            ShowInfo();
            if (PageCount <= 1)
            {
                btnFirst.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnEnd.Enabled = false;
                btnReturn.Enabled = false;
                return;
            }
            btnFirst.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnEnd.Enabled = true;
            btnReturn.Enabled = true;
            if (CurrentPageIndex == 1)
            {
                btnFirst.Enabled = false;
                btnUp.Enabled = false;
            }
            else if (CurrentPageIndex == PageCount)
            {
                btnDown.Enabled = false;
                btnEnd.Enabled = false;
            }
        }
        /// <summary>
        /// 首次查询的方法
        /// </summary>
        public void FistSerch()
        {
            CurrentPageIndex = 1;
            ExceuteSetPageEvent(CurrentPageIndex);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            ExceuteSetPageEvent(CurrentPageIndex);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            CurrentPageIndex--;
            ExceuteSetPageEvent(CurrentPageIndex);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            CurrentPageIndex++;
            ExceuteSetPageEvent(CurrentPageIndex);
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = PageCount;
            ExceuteSetPageEvent(CurrentPageIndex);
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            string input = txtPage.Text.Trim();
            if (input.Length == 0)
            {
                MessageBox.Show("请输入需要跳转到的页数！", "提示");
                return;
            }
            if (input.Length >= 1)
            {
                if (txtPage.CheckData(@"^\d*$", "输入的格式不正确") == 0)
                {
                    MessageBox.Show("请输入有效数字！", "提示");
                    txtPage.Text = "";
                    return;
                }
                else
                {
                    int pageIndex = Convert.ToInt32(input);
                    if (pageIndex > PageCount)
                    {
                        MessageBox.Show($"最大页数不能超出{PageCount}", "提示");
                        return;
                    }
                    else
                    {
                        CurrentPageIndex = pageIndex;
                        ExceuteSetPageEvent(CurrentPageIndex);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
