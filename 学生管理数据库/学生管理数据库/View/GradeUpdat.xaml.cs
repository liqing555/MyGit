using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentModel.ObjExt;
using StudentBLL;

namespace 学生管理数据库.View
{
    /// <summary>
    /// GradeUpdat.xaml 的交互逻辑
    /// </summary>
    public partial class GradeUpdat : Window
    {
        StudentClassManger csm = new StudentClassManger();
        StudentBLL.GradeManager manager = new StudentBLL.GradeManager();
        public GradeExt GradeList { get; set; }
        public GradeUpdat(GradeExt stu)
        {
            InitializeComponent();
            GradeList = stu;
            textcshap.Text = stu.CSharp.ToString();
            textsql.Text = stu.SQLServerDB.ToString();
        }
        // 确认修改
        private void btnSureUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfor())
            {
                GradeList.CSharp = Convert.ToInt32(textcshap.Text);
                GradeList.SQLServerDB = Convert.ToInt32(textsql.Text);
                if (manager.UpdateStudentInfor(GradeList))
                {
                    System.Windows.MessageBox.Show("修改成功！", "提示");
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("修改失败，请稍后再试！", "提示");
                }
            }
        }
        // 取消修改
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        bool CheckInfor()
        {
            if (string.IsNullOrEmpty(textcshap.Text))
            {
                System.Windows.MessageBox.Show("c#不能为空！");
                textcshap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textsql.Text))
            {
                System.Windows.MessageBox.Show("sql不能为空！");
                textsql.Focus();
                return false;
            }
            return true;
        }
    }
}
