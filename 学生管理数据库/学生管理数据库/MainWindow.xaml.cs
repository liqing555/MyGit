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
using System.Windows.Threading;
using System.Configuration;
using System.IO;

namespace 学生管理数据库
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //登录窗口验证,如果登录成功,关闭Login打开MainWindow窗口
            Login login = new Login();
            //主窗口打开时加载出登录页面
            login.ShowDialog();
            if (login.DialogResult != true)
            {
                Environment.Exit(0);
            }
            //再App.Xaml这里面拿到密码和账号

            //MessageBox.Show("欢迎"+App.AppxamlAdmins.AdminName+"登录成功");

            //实例化计时器
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
            try
            {
                //拿到登录后管理员的名称
                statusAdminLb.Content = "操作管理员【" + App.CurrentAdmin.Aname + "】";

                //拿到版本的文本那一栏,版本号这个应在App.config配置文件中写方便更改,再这里使用先再引用里导入配置文件，然后给命名空间加配置文件
                statusVersionLb.Content = "版本号：" + ConfigurationManager.AppSettings["version"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //先要获取系统的年
            DateTime now = DateTime.Now;
            string week = "星期天";
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    week = "星期天";
                    break;
                case DayOfWeek.Monday:
                    week = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    week = "星期四";
                    break;
                case DayOfWeek.Friday:
                    week = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    week = "星期六";
                    break;
                default:
                    break;
            }
            //statusTimeLb状态栏中最右面装日期时间的Lable名字
            statusTimeLb.Content = string.Format("{0}年{1}月{2}日  {3}:{4}{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, week);
        }

        //声明计时器
        DispatcherTimer timer = null;
        //关闭窗口
        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //缩小界面
        private void btnmin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //修改密码
        private void xgmm_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.ChangePassword add = new View.ChangePassword();
            Gird_Content.Children.Add(add);
        }
        //退出系统
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //添加学员
        private void addstu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.AddStudent add = new View.AddStudent();
            Gird_Content.Children.Add(add);
        }
        //信息管理
        private void xxmag_Click(object sender, RoutedEventArgs e)
        {
            //1.如果添加学员管理中的信息管理先创建一个窗口再View里面添加一个页面
            //2.把原有的主窗口内面的字体清除
            //3.把View里面的页面放在这里显示
            //4.View文件中的WPF窗口如何显示：右键---点击--->添加---找--->用户控件(WPF)--就可以添加WPF窗口
            Gird_Content.Children.Clear();
            View.StuManager Student = new View.StuManager();
            Gird_Content.Children.Add(Student);

        }
        //成绩录入
        private void cjlr_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.GradeAdd add = new View.GradeAdd();
            Gird_Content.Children.Add(add);
        }
        //成绩分析
        private void cjfx_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.GradeManager add = new View.GradeManager();
            Gird_Content.Children.Add(add);
        }
        //成绩查询
        private void cjcx_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.GradeManager add = new View.GradeManager();
            Gird_Content.Children.Add(add);
        }
        //考勤查询
        private void kqcx_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.AttendanceManager attendance = new View.AttendanceManager();
            Gird_Content.Children.Add(attendance);
        }
        //考勤打卡
        private void kqdk_Click(object sender, RoutedEventArgs e)
        {

        }
        //访问官网
        private void fwgw_Click(object sender, RoutedEventArgs e)
        {
            //有两种方式
            //方法一：
            //1.首先再View添加用户控件(WPF),创建好后再Grid里面在工具箱里找WebBrowser控件，然后再Source里写网站地址
            //2.再这里先清除主页文字
            //3.再这里把链接的地址窗口实例化
            //4.添加到主页面里
            //5.这个网址一定要访问通
            /* Gird_Content.Children.Clear();
             View.WebBrowser Web = new View.WebBrowser();
             Gird_Content.Children.Add(Web);*/
            //法二：
            //1.可以把官网写到配置文件里(App.config)
            //2.在配置文件中写入网址
            //3.在要链接的网址中引用配置文件的类
            //4.在FrmeWebBrowser使用配置文件里面你添加的网址
            //5.通过WebBrowser工具名字的uir路径点出配置文件中含有网址的路径
            Gird_Content.Children.Clear();
            View.WebBrowser Web = new View.WebBrowser();
            Gird_Content.Children.Add(Web);
            //法三:
            //System.Diagnostics.Process.Start("explorer.exe",ConfigurationManager.AppSettings["webadd"].ToString());
            //explorer.exe只要在本机里面时.exe文件都可以被启动
        }
        //联系我们
        private void lxwm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请拨打电话:88844488");
        }
        //快捷键
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
                {
                    this.WindowState = WindowState.Minimized;
                }else if (e.Key == Key.S)
                {
                    xt.IsSubmenuOpen = true;
                }else if (e.Key == Key.M)
                {
                    stumag.IsSubmenuOpen = true;
                }else if (e.Key == Key.J)
                {
                    cjgl.IsSubmenuOpen = true;
                }else if (e.Key == Key.A)
                {
                    kqgl.IsSubmenuOpen = true;
                }else if (e.Key == Key.H)
                {
                    help.IsSubmenuOpen = true;
                }else if (e.Key == Key.Z)
                {
                    xxmag_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("快捷键无效");
            }
        }
        //批量导入
        private void btnpldr_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.ImportData import = new View.ImportData();
            Gird_Content.Children.Add(import);
        }
        //考勤查询
        private void SelectAttendance_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.AttendanceManager attendance = new View.AttendanceManager();
            Gird_Content.Children.Add(attendance);
        }
    }
}
