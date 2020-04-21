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
using StudentModel;
using StudentModel.ObjExt;
using StudentBLL;
using System.IO;

namespace 学生管理数据库.View
{
    /// <summary>
    /// GradeAdd.xaml 的交互逻辑
    /// </summary>
    public partial class GradeAdd : Window
    {
        StudentClassManger csm = new StudentClassManger();
        StudentBLL.GradeManager manager = new StudentBLL.GradeManager();
        public GradeExt GradeList { get; set; }
        public GradeAdd()
        {
            InitializeComponent();
            GradeExt stu = new GradeExt();
            textcshap.Text = stu.CSharp.ToString();
            textsql.Text = stu.SQLServerDB.ToString();
            texttime.Text = stu.UpdateTime.ToString("yyyy-MM-dd");
            smclassCmb.DisplayMemberPath = "Sid";
            smclassCmb.SelectedIndex = stu.Sid - 1;
        }
        //确认录入
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfor())
            {
                GradeList.CSharp = Convert.ToInt32(textcshap.Text);
                GradeList.SQLServerDB = Convert.ToInt32(textsql.Text);
                GradeList.UpdateTime = Convert.ToDateTime(texttime.Text);
                GradeList.Sid = Convert.ToInt32(smclassCmb.SelectedItem);
                if (manager.Getdaa(GradeList) > 0)
                {
                    System.Windows.MessageBox.Show("添加成功！", "提示");
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("添加失败，请稍后再试！", "提示");
                }
            }
        }
        //取消录入
        private void btncancl_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
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
