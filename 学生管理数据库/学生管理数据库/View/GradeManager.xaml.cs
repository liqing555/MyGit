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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentModel;
using StudentModel.ObjExt;
using StudentBLL;
using Common;
using System.Data;
using System.IO;

namespace 学生管理数据库.View
{
    /// <summary>
    /// GradeManager.xaml 的交互逻辑
    /// </summary>
    public partial class GradeManager : UserControl
    {
        StudentClassManger csm = new StudentClassManger();
        StudentBLL.GradeManager sm = new StudentBLL.GradeManager();
        List<GradeExt> students = null;
        GradeExt selectStu = null;
        public GradeManager()
        {
            InitializeComponent();
            List<StudentClass> classes = csm.GetStudentClasses();
            smclassCmb.ItemsSource = classes;
            smclassCmb.DisplayMemberPath = "Scname";//设置下拉框的显示文本
            smclassCmb.SelectedValuePath = "Scid";//设置下拉框显示文本对应的value
            smclassCmb.SelectedIndex = 0;
            //给DataGrid进行数据绑定,需要针对DG中列进行绑定对应的数据列
            students = sm.GetGrades(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgGradeLsit.ItemsSource = students;
        }
        //导出到Excel工作簿
        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
            fileDialog.Filter = "Excel工作簿(*.xlsx;*.xls)|*.xlsx;*.xls";
            fileDialog.FileName = "学生信息表.xlsx";
            fileDialog.Title = "导出到Excel表";
            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                System.Data.DataTable table = sm.GetDataTable((int)smclassCmb.SelectedValue);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show("该班级暂无学生数据！", "提示");
                    return;
                }
                if (Common.ImportOrExportData.ExportToExcel(table, path))
                {
                    MessageBox.Show("导出数据完成！", "提示");
                }
                else
                {
                    MessageBox.Show("导出数据失败，请稍后再试！", "提示");
                }
            }
        }
        List<int> IdList = new List<int>();
        //修改成绩信息
        private void xgcj_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgGradeLsit.SelectedItem as GradeExt;
            if (IdList.Contains(selectStu.Sid))
            {
                MessageBox.Show("请关闭正在查看的学员成绩信息界面", "提示");
                return;
            }
            if (selectStu == null)
            {
                MessageBox.Show("请选择要修改的学员成绩！", "提示");
                return;
            }
            GradeExt objStu = sm.GetStudentById(selectStu.Sid);
            GradeUpdat  updateStuInfor = new GradeUpdat(objStu);
            updateStuInfor.ShowDialog();
            students = sm.GetGrades(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgGradeLsit.ItemsSource = students;
        }
        //根据学号，姓名，提交查询,包括模糊查询功能
        private void btnSelectBySIN_Click(object sender, RoutedEventArgs e)
        {
            smclassCmb.SelectedIndex = -1;
            string target = mstxtIdorName.Text.Trim();
            List<GradeExt> liststu = sm.GetStudentByldOrName(target);
            if (liststu.Count <= 0)
            {
                MessageBox.Show("未查询到相关信息", "提示");
                return;
            }
            students = liststu;
            smDgGradeLsit.ItemsSource = null;
            smDgGradeLsit.ItemsSource = students;
        }
        //关闭窗口
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        //删除成绩
        private void btnDeleteGrade_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgGradeLsit.SelectedItem as GradeExt;
            if (IdList.Contains(selectStu.Sid))
            {
                MessageBox.Show("请关闭正在查看的学员信息界面", "提示");
                return;
            }
            if (selectStu == null)
            {
                MessageBox.Show("请选择要删除的学员！", "提示");
                return;
            }
            GradeExt student = sm.GetStudentById(selectStu.Sid);
            if (student != null)
            {
                MessageBox.Show("您选择的学员信息已经被删除！", "提示");
                return;
            }
            MessageBoxResult mbr = MessageBox.Show("您确定要删除【" + student.Sname + "】", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (mbr == MessageBoxResult.OK)
            {
                if (sm.DeleteStudentById(student.Sid))
                {
                    MessageBox.Show("删除成功！", "提示");
                }
                else
                {
                    MessageBox.Show("删除失败请稍后再试！", "提示");
                }
            }
        }
        //班级查询
        private void btnSelectByCId_Click(object sender, RoutedEventArgs e)
        {
            if (smclassCmb.SelectedIndex < 0)
            {
                MessageBox.Show("请选择班级！", "提示");
                return;
            }
            //给DataGrid进行对应列数据绑定
            students = sm.GetGrades(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgGradeLsit.ItemsSource = students;
        }
        //学号排列
        private void btnGroupBySid_Click(object sender, RoutedEventArgs e)
        {
            if (smDgGradeLsit.ItemsSource == null)
            {
                return;
            }
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new ScoreListIdDESC(true));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/up.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new ScoreListIdDESC(false));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/down.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "True";
            }
            smDgGradeLsit.ItemsSource = null;
            smDgGradeLsit.ItemsSource = students;
        }
        //姓名排列
        private void btnGroupBySName_Click(object sender, RoutedEventArgs e)
        {
            if (smDgGradeLsit.ItemsSource == null)
            {
                return;
            }
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new StudentsNameDESC(true));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/jiang.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentsNameDESC(false));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/sheng.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "True";
            }
            smDgGradeLsit.ItemsSource = null;
            smDgGradeLsit.ItemsSource = students;
        }
    }
        class ScoreListIdDESC : IComparer<GradeExt>
        {
            public ScoreListIdDESC(bool b)
            {
                B = b;
            }
            public bool B { get; set; }
            /// <summary>
            /// 升序
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(GradeExt x, GradeExt y)
            {
                if (B)
                {
                    return x.Sid.CompareTo(y.Sid);
                }
                else
                {
                    return y.Sid.CompareTo(x.Sid);
                }
            }
        }
        /// <summary>
        /// 比较声明器
        /// </summary>
        class StudentsNameDESC : IComparer<GradeExt>
        {
            public StudentsNameDESC(bool b)
            {
                B = b;
            }
            public bool B { get; set; }
            /// <summary>
            /// 降序
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(GradeExt x, GradeExt y)
            {
                if (B)
                {
                    return y.Sname.CompareTo(x.Sname);
                }
                else
                {
                    return x.Sname.CompareTo(y.Sname);
                }
            }
        }
}
