using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace XinyueData
{
    public partial class Form1 : Form
    {
        bool doPlan = false;
        double planHour = 1.0;
        List<string> pathList = new List<string>();
        string sp = "";
        string out_path;
        int qqNewCount = 0;
        int qqRepeatCount = 0;
        Action<String> AsyncUIDelegate;
        public Form1()
        {
            InitializeComponent();
            AsyncUIDelegate = delegate (string n) { richTextBox1.AppendText(n); };

            textBox_inpath.Text =  IniFiles.iniFile.IniReadValue("path", "inpath");
            textBox_path1.Text = IniFiles.iniFile.IniReadValue("path", "path1");
            textBox_path2.Text = IniFiles.iniFile.IniReadValue("path", "path2");

            label_backup.Text = "最近备份时间："+IniFiles.iniFile.IniReadValue("plan", "backuptime");

            setTaskAtFixedTime();

        }

        int temp_files_count = 0;

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择目录";
            string path = "";
            if (folder.ShowDialog()==DialogResult.OK)
            {
                path = folder.SelectedPath;
                richTextBox1.AppendText("路径："+path+"\r\n");
                textBox_inpath.Text = path;
                IniFiles.iniFile.IniWriteValue("path", "inpath", path);
            }
            else
            {
                return;
            }
           

        }
        void GetAllFilePath(string rootPath)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);
            foreach (FileInfo info in root.GetFiles())
            {
                if (info.Name.Contains(".txt"))
                {
                    pathList.Add(info.FullName);
                    temp_files_count++;
                    Console.WriteLine(temp_files_count + ".===>" + info.FullName);
                }
            }

            foreach (DirectoryInfo d in root.GetDirectories())
            {
                GetAllFilePath(d.FullName);
            }
        }

        
        void DoSQL()
        {
            //DateTime t_begin = DateTime.Now;
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Now;
            MySqlHelper.Instance.init();
            qqNewCount = 0;
            qqRepeatCount = 0;
            int fileCount = 1;
            int allCount = pathList.Count;
            foreach (string fileFullName in pathList)
            {
                richTextBox1.Invoke(AsyncUIDelegate,new object[] { string.Format("共{1}个文件，当前执行：{0}//{1}\r\n", fileCount, allCount) });
               // richTextBox1.AppendText(string.Format("共{1}个文件，当前执行：{0}/{1}\r\n", fileCount, allCount));
                FileStream fs = new FileStream(fileFullName,FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                int level = 0;
                string[] split = fileFullName.Split('\\');

                string levelStr = System.Text.RegularExpressions.Regex.Replace(split[split.Length-1], @"[^0-9]+", "");
                bool b = int.TryParse(levelStr, out level);
                if (!b)
                {
                    Console.WriteLine("无法从文件名中提取到心悦等级：" + fileFullName);
                    richTextBox1.AppendText("无法从文件名中提取到心悦等级：" + fileFullName+"\r\n");
                    sr.Close();
                    fs.Close();
                    continue;
                }

                while (true)
                {
                    string str = sr.ReadLine();
                    if (str==null)
                    {
                        sr.Close();
                        fs.Close();
                        break;
                    }
                    else
                    {
                        if (sp!="")
                        {
                            str = str.Replace(sp,"");
                        }
                        string commdStr = string.Format("insert into vipxy (in_time,qq,level) values (now(),{0},{1}) ON DUPLICATE KEY UPDATE update_time = now()", str, level);
                        int ret =  MySqlHelper.Instance.Do(commdStr);
                        if (ret == 1)
                        {
                            qqNewCount++;
                        }
                        else if (ret==2)
                        {
                            qqRepeatCount++;
                        }
                        else
                        {

                        }
                    }
                    
                }
                fileCount++;
                richTextBox1.Invoke(AsyncUIDelegate, new object[] { string.Format("累计新增心悦用户:{0} ,累计重复心悦用户:{1}\r\n", qqNewCount, qqRepeatCount) });
                //richTextBox1.AppendText(string.Format("累计新增心悦用户:{0} ,累计重复心悦用户:{1}\r\n", qqNewCount, qqRepeatCount));
                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                richTextBox1.Invoke(AsyncUIDelegate, new object[] {string.Format("累计用时：{0}时{1}分{2}秒\r\n",ts.Hours,ts.Minutes,ts.Seconds)  });
               // richTextBox1.AppendText("累计用时："+ts.Seconds+"\r\n");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            Console.WriteLine("查找到的所有文件：");
            pathList.Clear();
            temp_files_count = 0;
            GetAllFilePath(textBox_inpath.Text);
            sp = textBox_sp.Text;

            Thread thread = new Thread(new ThreadStart(DoSQL));//创建线程
            thread.IsBackground = true;
            thread.Start();
           


        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlHelper.Instance.check();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlHelper.Instance.init();
            string level = textBox_level.Text.Trim();
            string commdStr = "select count(*) from vipxy where out_time is null and level="+level;
            int num1 = MySqlHelper.Instance.DoScalar(commdStr);

            commdStr = "select count(*) from vipxy where level="+level;
            int numall = MySqlHelper.Instance.DoScalar(commdStr);

            richTextBox1.AppendText(string.Format("心悦{0}统计: 总数 {1}; 已导出 {2}; 未导出 {3};\r\n",level, numall, numall - num1, num1) );

        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择目录";
            //string path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                out_path = folder.SelectedPath;
                richTextBox1.AppendText("路径：" + out_path + "\r\n");

            }
            else
            {
                return;
            }
           
            DateTime dt = DateTime.Now;
            string str = dt.ToString("_yyyy_MM_dd_HH_mm_ss");
            out_path = out_path + "\\心悦" + textBox_level.Text.Trim() + str+".txt";
            Thread thread = new Thread(new ThreadStart(exportData));//创建线程
            thread.IsBackground = true;
            thread.Start();

          

        }

        void exportData()
        {
           
            MySqlHelper.Instance.init();
           
            richTextBox1.Invoke(AsyncUIDelegate, new object[] { "输出："+ out_path + "\r\n进行中...\r\n"});
            string m_count = textBox_num.Text.Trim();
            FileStream fs = new FileStream(out_path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            string commdStr = string.Format("select * from vipxy where out_time is null and level={1} limit {0}", m_count, textBox_level.Text.Trim());
            MySqlDataReader dr = MySqlHelper.Instance.DoGetReader(commdStr);
            List<string> tempList = new List<string>();
            if (dr != null)
            {
               
                while (dr.Read())
                {
                    tempList.Add(dr["qq"].ToString());
                   
                }
                dr.Close();
            }
            else
            {

            }

            int count_temp = 0;
            foreach (var item in tempList)
            {
                commdStr = string.Format("update vipxy set out_time=now() where qq={0}", item);
                int ret = MySqlHelper.Instance.Do(commdStr);
                if (ret == 1)
                {
                    sw.WriteLine(item);
                }

                count_temp++;
               // if (count_temp % 100 == 0)
                {
                    Console.WriteLine("进行中 (" + count_temp + "/" + textBox_num.Text+")");
                }
            }

            sw.Close();
            fs.Close();
            richTextBox1.Invoke(AsyncUIDelegate, new object[] { "已完成,导出"+count_temp+"条\r\n" });
        }

        private void textBox_level_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           DialogResult ret =  MessageBox.Show("重置所有记录为未导出状态，数据不会丢失","提示",MessageBoxButtons.OKCancel);
            if (ret==DialogResult.Cancel)
            {
                return;
            }
            MySqlHelper.Instance.init();
            MySqlHelper.Instance.Do("update vipxy set out_time=null");

            richTextBox1.AppendText("已重置\r\n");
        }

        private void button_path1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择路径1";
            //string path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox_path1.Text = folder.SelectedPath;
                richTextBox1.AppendText("路径1：" + textBox_path1.Text + "\r\n");
                IniFiles.iniFile.IniWriteValue("path", "path1", textBox_path1.Text);

            }
           
        }

        private void button_path2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择路径1";
            //string path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox_path2.Text = folder.SelectedPath;
                richTextBox1.AppendText("路径2：" + textBox_path2.Text + "\r\n");
                IniFiles.iniFile.IniWriteValue("path", "path2", textBox_path2.Text);

            }
           
        }

        private void button_bak_begin_Click(object sender, EventArgs e)
        {
           
            BackUP();
            string t = DateTime.Now.ToString();
            richTextBox1.AppendText(t+":备份完成！\r\n");
            IniFiles.iniFile.IniWriteValue("plan", "backuptime", t);
            label_backup.Text = "最近备份时间：" + t;
            
        }

        void BackUP()
        {
            string path1 = textBox_path1.Text;
            string path2 = textBox_path2.Text;

            if (!Directory.Exists(path1)||!Directory.Exists(path2))
            {
                richTextBox1.AppendText("路径1或路径2不存在，操作已终止！");
                return;
            }

            DateTime dt = DateTime.Now;
            string str = dt.ToString("yyyy_MM_dd_HH_mm_ss");
            path2 = path2 + "\\" + str;
            Directory.CreateDirectory(path2);

            CutFiles(path1, path2);

        }

        void CutFiles(string path1,string path2)
        {


            DirectoryInfo root = new DirectoryInfo(path1);
            foreach (FileInfo info in root.GetFiles())
            {
                if (info.Name.Contains(".txt"))
                {
                    string destFileName = path2 + "\\" + info.Name;
                    File.Copy(info.FullName, destFileName);
                    Console.WriteLine( info.FullName+" 成功复制到===>" + destFileName);
                    try
                    {
                        File.Delete(info.FullName);
                        Console.WriteLine(info.FullName + " 已删除");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(info.FullName + " 删除失败" + e.Message);
                       
                    }
                    
                }
            }

            foreach (DirectoryInfo d in root.GetDirectories())
            {
                string destDirPath = path2 + "\\" + d.Name;
                Directory.CreateDirectory(destDirPath);
                CutFiles(d.FullName, destDirPath);
            }
        }

        private void button_plan_start_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("开启定时任务，任务包括数据导入数据库和数据转移\r\n");
            doPlan = true;
            label_plan_state.Text = "已开启，执行时间" + planHour + "点";
        }

        private void setTaskAtFixedTime()
        {

            string m_hour = IniFiles.iniFile.IniReadValue("plan", "starttime");
            
            if (!double.TryParse(m_hour, out planHour))
            {
                planHour = 1.0;
            }
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(planHour); //凌晨1：00


            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        //要执行的任务
        private void doAt1AM(object state)
        {
            //执行功能...
            if (doPlan)
            {
                richTextBox1.AppendText(DateTime.Now.ToString() + ":计划任务开始执行\r\n");
                try
                {
                    //导入数据库
                    button2_Click(null, null);
                    //备份
                    button_bak_begin_Click(null, null);

                    richTextBox1.AppendText(DateTime.Now.ToString() + ":计划任务执行完毕\r\n");
                }
                catch (Exception e)
                {

                    richTextBox1.AppendText(DateTime.Now.ToString() + ":计划任务执行失败,控制台输出失败原因！！ \r\n");
                    Console.WriteLine("计划任务执行失败:" + e.Message);
                }
            }

            
            //再次设定
            setTaskAtFixedTime();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ParseExcelFile pef = new ParseExcelFile("Zx.xlsx");
            DataTable dt = pef.ExcelToDataTable(null, true);

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dt.Columns)
                {

                }
            }

        }
    }
}
