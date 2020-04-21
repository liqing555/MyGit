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
    public partial class FrmSale : Form
    {
        SuperMarketIBLL.SuperMarketCashier.IISuperMarketSaleManager manager = new SuperMarketBLL.SuperMarketCashier.SuperMarketSaleManager();
        public FrmSale()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            GetSale();
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            person = source.Current as SalePerson;
        }

        public SalePerson person { get; set; }
        List<SalePerson> sales = null;
        BindingSource source = new BindingSource();
        private void GetSale()
        {
            sales = manager.GetSales();
            source.DataSource = sales;
            dataGridView1.DataSource = source;
        }
        /// <summary>
        /// 添加营业员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddSale form = new FrmAddSale();
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                GetSale();
            }
            GetSale();
        }

        /// <summary>
        /// 修改营业员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            FrmUpdateSale form = new FrmUpdateSale(person);
            if (form.ShowDialog() == DialogResult.OK)
            {
                GetSale();
            }
        }
    }
}
