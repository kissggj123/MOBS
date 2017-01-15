using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOBS_Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string Branding = "Menglolita Browser S 1.0.1 Beta";

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置默认Path路径
            string Path = AppDomain.CurrentDomain.BaseDirectory + Branding + @"\";
            this.textBox1.Text = Path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + Branding + @"\";
            if (Directory.Exists(Path + "MBOSCache"))
            {
                Directory.Delete(Path, true);
                Directory.CreateDirectory(Path);
                MessageBox.Show("MOBS缓存成功清理，请重新打开浏览器", "操作完成");
            }
            else
            {
                MessageBox.Show("缓存不存在，太TM干净了","没什么可以清理的");
            }

        }
    }
}
