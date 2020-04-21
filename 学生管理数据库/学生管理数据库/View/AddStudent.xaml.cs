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
using System.IO;

namespace 学生管理数据库.View
{
    /// <summary>
    /// AddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class AddStudent : UserControl
    {
        StudentClassManger csm = new StudentClassManger();
        StudentBLL.StudentManager manager = new StudentBLL.StudentManager();
        common.Bitmapimg image = null;
        public StudentExt student { get; set; }
        common.Bitmapimg img = new common.Bitmapimg();
        public AddStudent()
        {
            InitializeComponent();
            StudentExt stu = new StudentExt();
            student = stu;
            txtAddress.Text = stu.Saddress;
            txtAge.Content = stu.Sage.ToString();
            txtCardNo.Text = stu.CardNo;
            txtName.Text = stu.Sname;
            txtPhoneNumber.Text = stu.Sphone;
            txtStuNoId.Text = stu.SidNo;
            if (stu.Ssex == "男")
            {
                radBoy.IsChecked = true;
            }
            else
            {
                radGirl.IsChecked = true;
            }
            datePkBirthday.Content = stu.Birthday.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(stu.SImage))
            {
                stuImg.Source = new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute));
            }
            else
            {
                //如果学员的Iamge字段中能够查询到数据，那么就可以直接将这个数据反序列化成BitmapImage对象
                image = SerializeObjectTostring.DeserializeObject(stu.SImage) as common.Bitmapimg;
                img.Buffer = image.Buffer;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                stuImg.Source = bitmap;
            }
            List<StudentClass> classes = csm.GetStudentClasses();
            cmbClassName.ItemsSource = classes;
            cmbClassName.DisplayMemberPath = "Scname";
            cmbClassName.SelectedValuePath = "Scid";
            cmbClassName.SelectedIndex = stu.Sclassid - 1;
        }

        //取消添加
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        
        //确认添加
        private void btnSureAdd_Click(object sender, RoutedEventArgs e)
        {
            //改变数据之前的最终验证
            if (CheckInfor())
            {
                student.SidNo = txtStuNoId.Text;
                student.Sname = txtName.Text;
                student.Sage = (int)txtAge.Content;
                student.Birthday = (DateTime)datePkBirthday.Content;
                student.CardNo = txtCardNo.Text;
                student.Sclassid = (int)cmbClassName.SelectedValue;
                student.Ssex = (radBoy.IsChecked == true ? "男" : "女");
                student.Sphone = txtPhoneNumber.Text;
                student.Saddress = (string.IsNullOrEmpty(txtAddress.Text) ? null : txtAddress.Text);
                //判断是否重新选择了Image
                if (stuImg.Source == new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute)))
                {
                    student.SImage = null;
                }//判断数据库中的图片是否和目前的上传图片一样
                else
                {
                    //证明未修改图片,目前的图片和原来数据库中的一致
                    if (image != null && img.Buffer == image.Buffer)
                    {
                        student.SImage = Common.SerializeObjectTostring.SerializeObject(image);
                    }
                    else
                    {
                        student.SImage = Common.SerializeObjectTostring.SerializeObject(img);
                    }
                }
                if (manager.AddStudent(student))
                {
                    MessageBox.Show("添加成功!", "提示");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后再试！", "提示");
                }
            }
        }
        bool CheckInfor()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("姓名不能为空！");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                MessageBox.Show("打卡号不能为空！");
                txtCardNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStuNoId.Text))
            {
                MessageBox.Show("身份证号不能为空！");
                txtStuNoId.Focus();
                return false;
            }
            else if (Common.DataValidata.IsSCard(txtStuNoId.Text.Trim()))
            {
                MessageBox.Show("身份证号非法！");
                txtStuNoId.Focus();
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("联系方式不能为空！");
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }
        //姓名
        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("姓名不能为空！");
                txtName.Focus();
            }
        }
        //卡号
        private void txtCardNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                MessageBox.Show("打卡号不能为空！");
                txtCardNo.Focus();
            }
        }
        //身份证
        private void txtStuNoId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStuNoId.Text))
            {
                MessageBox.Show("身份证号不能为空！");
                txtStuNoId.Focus();
            }
            else if (Common.DataValidata.IsSCard(txtStuNoId.Text.Trim()))
            {
                System.Windows.MessageBox.Show("身份证号非法！");
                txtStuNoId.Focus();
            }
            else
            {
                datePkBirthday.Content = Common.GetValueById.GetBirthday(txtStuNoId.Text.Trim());

                txtAge.Content = Common.GetValueById.GetAge(Common.GetValueById.GetBirthday(txtStuNoId.Text.Trim()));
            }
        }
        //电话
        private void txtPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("联系方式不能为空！");
                txtPhoneNumber.Focus();
            }
        }
        //重新上传
        private void btnAddloadPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png,*.bmp";
            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                stuImg.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                stuImg.Stretch = Stretch.UniformToFill;
                img.Buffer = File.ReadAllBytes(path);
            }
        }
        public static string imgPath;
        //重新拍照
        private void btnOpenVideo_Click(object sender, RoutedEventArgs e)
        {
            StudentPhoto photo = new StudentPhoto();
            photo.ShowDialog();
            if (!string.IsNullOrEmpty(imgPath))
            {
                //照片刷新了之后对新照片进行序列化
                stuImg.Source = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
                img.Buffer = File.ReadAllBytes(imgPath);
            }
        }
    }
}
