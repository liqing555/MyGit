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
    /// StuManager.xaml 的交互逻辑
    /// </summary>
    public partial class StuManager : UserControl
    {
        StudentClassManger csm = new StudentClassManger();
        StudentBLL.StudentManager sm = new StudentBLL.StudentManager();
        List<StudentExt> students = null;
        //用来记录当前的选择的学员
        StudentExt selectStu = null;
        public StuManager()
        {
            InitializeComponent();
            List<StudentClass> classes = csm.GetStudentClasses();
            smclassCmb.ItemsSource = classes;
            smclassCmb.DisplayMemberPath = "Scname";//设置下拉框的显示文本
            smclassCmb.SelectedValuePath = "Scid";//设置下拉框显示文本对应的value
            smclassCmb.SelectedIndex = 0;
            //给DataGrid进行数据绑定,需要针对DG中列进行绑定对应的数据列
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }
        //根据班级查询，提交查询
        private void btnSelectByCId_Click(object sender, RoutedEventArgs e)
        {
            if (smclassCmb.SelectedIndex < 0)
            {
                MessageBox.Show("请选择班级！", "提示");
                return;
            }
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }
        //学号排列
        private void btnGroupBySid_Click(object sender, RoutedEventArgs e)
        {
            if (smDgStudentLsit.ItemsSource == null)
            {
                return;
            }
            //倒序：从大到小
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new StudentIdDESC(true));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/up.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentIdDESC(false));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/down.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "True";
            }
            smDgStudentLsit.ItemsSource = null;
            smDgStudentLsit.ItemsSource = students;
        }
        //姓名排列
        private void btnGroupBySName_Click(object sender, RoutedEventArgs e)
        {
            if (smDgStudentLsit.ItemsSource == null)
            {
                return;
            }
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new StudentNameDESC(true));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/jiang.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentNameDESC(false));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/sheng.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "True";
            }
            smDgStudentLsit.ItemsSource = null;
            smDgStudentLsit.ItemsSource = students;
        }
        //关闭窗口
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        //根据学号，姓名，提交查询,包括模糊查询功能
        private void btnSelectBySIN_Click(object sender, RoutedEventArgs e)
        {
            smclassCmb.SelectedIndex = -1;
            string target = mstxtIdorName.Text.Trim();
            List<StudentExt> liststu = sm.GetStudentByIdOrName(target);
            smDgStudentLsit.ItemsSource = null;
            if (liststu.Count <= 0)
            {
                MessageBox.Show("根据条件未查询到相关信息！", "提示");
                mstxtIdorName.Focus();
                mstxtIdorName.SelectAll();
                return;
            }
            students = liststu;
            smDgStudentLsit.ItemsSource = students;
        }
        //修改学生信息
        private void xgxs_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            //检测当前选择的学员，查看详细信息的界面还未关闭
            if (IDlist.Contains(selectStu.Sid))
            {
                MessageBox.Show("请关闭正在查看的学员信息界面", "提示");
                return;
            }
            if (selectStu == null)
            {
                MessageBox.Show("请选择要修改的学生！", "提示");
                return;
            }
            StudentExt objStu = sm.GetStudentById(selectStu.Sid);
            UpdateStuInfor updateStuInfor = new UpdateStuInfor(objStu);
            updateStuInfor.ShowDialog();
            //刷新DG中这个学员的信息
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }

        List<int> IDlist = new List<int>();
        List<StudentInfor> list = new List<StudentInfor>();
        //当鼠标双击某个学生查看这个学生的详细信息
        private void smDgStudentLsit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu == null)
            {
                return;
            }
            //当这个学员的完整信息已经存在的话，证明已经打开了一个窗口
            //除非是打开新的学员窗口，否则只能把之前的窗口给呈现出来
            if (IDlist.Contains(selectStu.Sid))
            {
                foreach(StudentInfor item in list)
                {
                    if (item.StuId == selectStu.Sid)
                    {
                        //激活窗口
                        item.Activate();
                    }
                }
            }else
            {
                StudentExt objStu = sm.GetStudentById(selectStu.Sid);
                IDlist.Add(selectStu.Sid);
                View.StudentInfor studentInfor = new StudentInfor(objStu);
                studentInfor.Closing += StudentInfor_Closing;
                list.Add(studentInfor);
                //展示窗口
                studentInfor.Show();
            }
        }
        //移除关闭的窗口对应的数据
        private void StudentInfor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int stuId = (sender as StudentInfor).StuId;
            IDlist.Remove(stuId);
            foreach(StudentInfor item in list)
            {
                if (item.StuId == stuId)
                {
                    list.Remove(item);
                    return;
                }
            }
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
        //删除学生
        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (IDlist.Contains(selectStu.Sid))
            {
                MessageBox.Show("请关闭正在查看的学员信息界面", "提示");
                return;
            }
            if (selectStu == null)
            {
                MessageBox.Show("请选择要删除的学员！", "提示");
                return;
            }
            StudentExt student = sm.GetStudentById(selectStu.Sid);
            if (student != null)
            {
                MessageBox.Show("您选择的学员信息已经被删除！", "提示");
                return;
            }
            //删除工作很危险
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
        //实现打印及打印预览
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu == null)
            {
                MessageBox.Show("请选择您要打印的学员", "提示");
                return;
            }
            common.Bitmapimg image = null;
            if (string.IsNullOrEmpty(selectStu.SImage))
            {
                selectStu.ImgPath = "/img/bg/zwzp.jpg";
            }
            else
            {
                image = SerializeObjectTostring.DeserializeObject(selectStu.SImage) as common.Bitmapimg;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                long sc = DateTime.Now.Ticks;
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    byte[] buffer = stream.ToArray();
                    File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png", buffer);
                    stream.Close();
                }
                selectStu.ImgPath = AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png";
            }
            View.PrintWindow frmPrint = new PrintWindow("PrintModel.xaml", selectStu);
            frmPrint.ShowInTaskbar = false;
            frmPrint.ShowDialog();
        }
    }
    
    //声明比较器
    class StudentIdDESC : IComparer<StudentExt>
    {
        ///-1，0，1
        public StudentIdDESC(bool b)
        {
            B = b;
        }
        public bool B { get; set; }
        public int Compare(StudentExt x, StudentExt y)
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

    class StudentNameDESC : IComparer<StudentExt>
    {
        ///-1，0，1
        public StudentNameDESC(bool b)
        {
            B = b;
        }
        public bool B { get; set; }
        public int Compare(StudentExt x, StudentExt y)
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
