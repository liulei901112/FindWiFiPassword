using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FindWiFiPassword
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> wificfgList = Command.GetConnectedWIFIList();
            if (wificfgList == null || wificfgList.Count <= 0)
            {
                MessageBox.Show("当前为获取到Wifi连接信息");
                this.Close();
                return;
            }
            for (int i = 0; i < wificfgList.Count; i++)
            {
                string cfg = wificfgList[i];
                // 显示WIFI名称
                WifiList.Items.Add(cfg);
            }
        }

        /// <summary>
        /// WIFI列表点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WifiList_Click(object sender, EventArgs e)
        {
            WifiInfo.Text = "";
            ListBox wificfgList = (ListBox)sender;
            string name = wificfgList.SelectedItem + "";
            Console.WriteLine(name);
            List<string> wifiInfoList = Command.GetWIFICfg(name);
            for (int i = 0; i < wifiInfoList.Count; i++)
            {
                string info = wifiInfoList[i];
                // 显示WIFI信息
                WifiInfo.AppendText(info + "\r\n");
            }
        }
    }
}
