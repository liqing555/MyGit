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
using Common;
using System.IO;

namespace 学生管理数据库.View
{
    /// <summary>
    /// StudentInfor.xaml 的交互逻辑
    /// </summary>
    public partial class StudentInfor : Window
    {
        //构造函数
        public StudentInfor(StudentExt stu)
        {
            InitializeComponent();
            StuId = stu.Sid;
            this.Title = stu.Sname + "-信息";
            lblAddress.Content = stu.Saddress;
            lblAge.Content = stu.Sage;
            lblBirthday.Content = stu.Birthday.ToString("yyyy-MM-dd");
            lblCardNo.Content = stu.CardNo;
            lblClassName.Content = stu.Scname;
            lblGender.Content = stu.Ssex;
            lblName.Content = stu.Sname;
            lblPhoneNumber.Content = stu.Sphone;
            lblStuId.Content = stu.Sid;
            lblStuNoId.Content = stu.SidNo;
            if (string.IsNullOrEmpty(stu.SImage))
            {
                stuImg.Source = new BitmapImage(new Uri("/img/bg/zwzp.jpg",UriKind.RelativeOrAbsolute));
            }
            else
            {
                //如果学员的Iamge字段中能够查询到数据，那么就可以直接将这个数据反序列化成BitmapImage对象
                common.Bitmapimg image = SerializeObjectTostring.DeserializeObject(stu.SImage) as common.Bitmapimg;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                stuImg.Source = bitmap;
            }
        }
        //这个属性用它来记录当前窗口中绑定的学员信息是谁的
        public int StuId { get; set; }
    }
}
