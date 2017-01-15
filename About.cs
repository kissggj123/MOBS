using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("创意：萌萝互娱小梦酱\n背景图：minions缉毒犬\n\n内核更新：hgupta9\n\n部分源码基于github项目修改，感谢", "这是部分名单");
            //致谢名单
        }

       

    }
}
