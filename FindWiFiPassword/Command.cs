using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FindWiFiPassword
{
    /// <summary>
    /// 指令
    /// </summary>
    public class Command
    {

        #region 执行CMD命令
        private static string CmdPath = @"C:\Windows\System32\cmd.exe";
        /// <summary>
        /// 执行cmd命令 返回cmd窗口显示的信息
        /// 多命令请使用批处理命令连接符：
        /// <![CDATA[
        /// &:同时执行两个命令
        /// |:将上一个命令的输出,作为下一个命令的输入
        /// &&：当&&前的命令成功时,才执行&&后的命令
        /// ||：当||前的命令失败时,才执行||后的命令]]>
        /// </summary>
        /// <param name="cmd">执行的命令</param>
        public static string RunCmd(string cmd)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            using (Process p = new Process())
            {
                p.StartInfo.FileName = CmdPath;
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();

                return output;
            }
        }
        #endregion

        /// <summary>
        /// 获取连接过的WIFI列表
        /// </summary>
        /// <returns>List<string></returns>
        public static List<string> GetConnectedWIFIList()
        {
            string wificfgStr = Command.RunCmd("netsh wlan show profiles");
            // wificfgStr = "\r\n接口 WLAN 上的配置文件:\r\n\r\n\r\n组策略配置文件(只读)\r\n---------------------------------\r\n    <无>\r\n\r\n用户配置文件\r\n-------------\r\n    所有用户配置文件 : ShiXinJiaZhuang5G\r\n    所有用户配置文件 : TP-LINK_7FB2\r\n    所有用户配置文件 : Love\r\n\r\n接口 WLAN 2 上的配置文件:\r\n\r\n\r\n组策略配置文件(只读)\r\n---------------------------------\r\n    <无>\r\n\r\n用户配置文件\r\n-------------\r\n    所有用户配置文件 : ShiXinJiaZhuang5G\r\n    所有用户配置文件 : TP-LINK_7FB2\r\n    所有用户配置文件 : Love\r\n\r\n";
            //Console.WriteLine(wificfgStr);
            if (wificfgStr.Contains("系统上没有无线接口"))
            {
                return null;
            }
            string[] wificfgArray = wificfgStr.Split("\r\n".ToCharArray());
            List<string> list = new List<string>();
            for (int i = 0; i < wificfgArray.Length; i++)
            {
                string line = wificfgArray[i];
                if (line.Contains("所有用户配置文件 : "))
                {
                    line = line.Substring(line.IndexOf(":")).Replace(":", "").Trim();
                    Console.WriteLine(line);
                    list.Add(line);
                }
                
            }
            return list.Where((x, i) => list.FindIndex(z => z.Equals(x)) == i).ToList();
        }

        /// <summary>
        /// 根据WIFI名称获取WIFI信息
        /// </summary>
        /// <param name="wifiName">wifi名称</param>
        /// <returns></returns>
        public static List<string> GetWIFICfg(string wifiName)
        {
            string wificfgStr = Command.RunCmd("netsh wlan show profiles \"" + wifiName + "\" key = clear");

            // wificfgStr = "接口 WLAN 上的配置文件 中国航空:\r\n=======================================================================\r\n\r\n已应用: 所有用户配置文件\r\n\r\n配置文件信息\r\n-------------------\r\n    版本                   : 1\r\n    类型                   : 无线局域网\r\n    名称                   : 中国航空\r\n    控制选项               :\r\n        连接模式           : 自动连接\r\n        网络广播           : 只在网络广播时连接\r\n        AutoSwitch         : 请勿切换到其他网络\r\n        MAC 随机化: 禁用\r\n\r\n连接设置\r\n---------------------\r\n    SSID 数目              : 1\r\n    SSID 名称              :“涓浗鑸┖”\r\n    网络类型               : 结构\r\n    无线电类型             : [ 任何无线电类型 ]\r\n    供应商扩展名           : 不存在\r\n\r\n安全设置\r\n-----------------\r\n    身份验证         : WPA2 - 个人\r\n    密码                 : CCMP\r\n    身份验证         : WPA2 - 个人\r\n    密码                 : GCMP\r\n    安全密钥               : 存在\r\n    关键内容            : xiangbuqilaile\r\n\r\n费用设置\r\n-------------\r\n    费用                : 无限制\r\n    阻塞                : 否\r\n    接近数据限制        : 否\r\n    过量数据限制        : 否\r\n    漫游                : 否\r\n    费用来源            : 默认";
            wificfgStr = wificfgStr.Substring(wificfgStr.LastIndexOf("=="));
            string[] wificfgArray = wificfgStr.Split("\r\n".ToCharArray());
            List<string> list = new List<string>();
            bool begin = false;
            for (int i = 0; i < wificfgArray.Length; i++)
            {
                string line = wificfgArray[i];
                if (line.Contains("连接设置"))
                {
                    begin = true;
                }
                if (line.Contains("费用设置"))
                {
                    begin = false;
                }
                if (begin && !line.Contains("--"))
                {
                    line = line.Trim().Replace(":", "：").Replace(" ", "");
                    list.Add(line);
                }

            }
            return list;
        }
    }
}
