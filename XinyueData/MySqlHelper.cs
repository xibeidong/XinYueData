using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace XinyueData
{
    class MySqlHelper
    {

        public static MySqlHelper Instance = new MySqlHelper();
        private MySqlHelper()
        {

        }
        ~MySqlHelper()
        {
            if (sqlConn == null)
            {
                return;
            }

            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }

        }
        private string datasource = "localhost";
        private string user = "root";
        private string password = "123456";
        private string database = "xinyue";
        private string connStr = "Database=xinyue;datasource=127.0.0.1;port=3306;user=root;pwd=123456;";

        private MySqlConnection sqlConn;
        private System.Timers.Timer t;

        private bool isinit = false;

        private void Readini()
        {
            datasource = IniFiles.iniFile.IniReadValue("mysql", "datasource");
            user = IniFiles.iniFile.IniReadValue("mysql", "user");
            password = IniFiles.iniFile.IniReadValue("mysql", "password");
            database = IniFiles.iniFile.IniReadValue("mysql", "database");
            connStr = string.Format("Database={0};datasource={1};port=3306;user={2};pwd={3};", database, datasource, user, password);

        }

        public void check()
        {
            Readini();
            connStr = string.Format("datasource={0};port=3306;user={1};pwd={2};", datasource, user, password);

            //尝试连接Mysql服务
            MySqlConnection myConnnect = new MySqlConnection(connStr);
            try
            {
                myConnnect.Open();
                myConnnect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "（无法连接Mysql服务）");
                return;

            }

            //xinyue
            connStr = string.Format("Database={0};datasource={1};port=3306;user={2};pwd={3};", database, datasource, user, password);
            MySqlConnection myConnnect2 = new MySqlConnection(connStr);
            try
            {
                myConnnect2.Open();
                myConnnect2.Close();
                MessageBox.Show("数据库正常");
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "(数据库连接成功，即将进行初始化)");
            }

            //初始化数据库(建库建表)
            string connectStr = string.Format("datasource={0};port=3306;user={1};pwd={2};", datasource, user, password);
            MySqlConnection conn = new MySqlConnection(connectStr);
            string commandStr = string.Format("CREATE DATABASE {0};", database);
            MySqlCommand cmd = new MySqlCommand(commandStr, conn);

            conn.Open();
            int ret = cmd.ExecuteNonQuery();
            if (ret == 1)
            {
                Console.WriteLine(string.Format("{0}建立成功", database));
            }


            conn.Close();
            CreatTable1();
        }

        private void CreatTable1()
        {
            connStr = string.Format("Database={0};datasource={1};port=3306;user={2};pwd={3};", database, datasource, user, password);

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            // 建表 
            /*
            *表一：id，qq，level，in_time,update_time,out_time

           */
            string creatTable1 = string.Format("CREATE TABLE vipxy (in_time datetime,out_time datetime,update_time datetime,qq varchar(50),level int,PRIMARY KEY (qq))");
            using (MySqlCommand cmd2 = new MySqlCommand(creatTable1, conn))
            {
                int ret = cmd2.ExecuteNonQuery();
                if (ret >= 0)
                {
                    MessageBox.Show("初始化完成");
                }
            }
            conn.Close();

        }


        public void CreateTable2()
        {
            //QQ号,QQ等级,性别,年龄,心悦会员,财付通,游戏人生,应用中心,QQ会员,QQ蓝钻,QQ游戏,QQ紫钻,QQ黑钻,地下城与勇士,英雄联盟,斗战神VIP,斗战神,剑灵,天涯明月刀,上古世纪,御龙在天,疾风之刃,轩辕传奇,逆战,QQ飞车,QQ炫舞,穿越火线,战地之王,寻仙,QQ三国,QQ堂,QQ音速,QQ幻想,QQ自由幻想,QQ幻想世界,NBA2K Online,QQ仙灵,QQ仙侠传,全民超神,枪林弹雨,英雄之刃,枪神纪,七雄争霸,王朝霸域,天堂,火影忍者,传奇霸业,热血江湖,斩仙,倚天,苍穹变,天书残卷,勇者之塔,蜀山传奇,仙魂,六界仙尊,焚天,纵横九州,花千骨,三国乱世,龙骑士传,暴风王座,奇迹战神,战神霸业,古剑奇谭
            connStr = string.Format("Database={0};datasource={1};port=3306;user={2};pwd={3};", database, datasource, user, password);

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            // 建表 
            /*
            *表一：id，qq，level，in_time,update_time,out_time

           */
            Dictionary<string, string> dict = DataManager.Instance.FiledsDict;
            string creatTable1 = "CREATE TABLE vipxy2 (in_time datetime,out_time datetime,update_time datetime,"; //qq varchar(50),level int,PRIMARY KEY (qq))");

            for (int i = 0; i < dict.Count; i++)
            {
                creatTable1 += "f" + i + " varchar(50),";
            }

            creatTable1 += " PRIMARY KEY(f0))";

          //  string creatTable1 = string.Format("CREATE TABLE vipxy2 (in_time datetime,out_time datetime,update_time datetime,qq varchar(50),level int,PRIMARY KEY (qq))");
            using (MySqlCommand cmd2 = new MySqlCommand(creatTable1, conn))
            {
                try
                {
                    int ret = cmd2.ExecuteNonQuery();
                    if (ret >= 0)
                    {
                        MessageBox.Show("创建完成");
                    }
                    else
                    {
                        MessageBox.Show("创建失败");
                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }
               
            }
            conn.Close();

        }
        public void init()
        {
            if (isinit)
            {
                return;
            }
            sqlConn = new MySqlConnection(connStr);
            try
            {
                sqlConn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接失败，记录将不被保存！" + e.Message);
                return;
            }


            t = new System.Timers.Timer(1000 * 3600);
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            isinit = true;
        }
        //定时执行一下，防止连接停止活跃
        private void theout(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(1) FROM vipxy";
            using (MySqlCommand cmd2 = new MySqlCommand(str, sqlConn))
            {
                int ret = cmd2.ExecuteNonQuery();
                Console.WriteLine("SELECT COUNT(1) FROM vipxy 执行结果：" + ret.ToString());
            }
        }

        public int DoInsert(string commdStr)
        {
            int ret = 0;
            using (MySqlCommand cmd2 = new MySqlCommand(commdStr, sqlConn))
            {
                try
                {
                    ret = cmd2.ExecuteNonQuery();

                    Console.WriteLine(commdStr + " 执行结果：" + ret.ToString());

                    long newid = cmd2.LastInsertedId;
                    return (int)newid;
                }
                catch (Exception e)
                {

                    Console.WriteLine(commdStr + " 执行错误：" + e.Message);
                }

            }
            return ret;
        }

        public int DoScalar(string commdStr)
        {
            int ret = 0;
            using (MySqlCommand cmd2 = new MySqlCommand(commdStr, sqlConn))
            {
                try
                {
                    object ob = cmd2.ExecuteScalar();
                    // Console.WriteLine(commdStr + " 执行结果：" + ret.ToString());
                    ret =  Convert.ToInt32(ob);
                }
                catch (Exception e)
                {

                    Console.WriteLine(commdStr + " 执行错误：" + e.Message);
                }

            }
            return ret;
        }
        public int Do(string commdStr)
        {
            int ret = 0;
            using (MySqlCommand cmd2 = new MySqlCommand(commdStr, sqlConn))
            {
                try
                {
                    ret = cmd2.ExecuteNonQuery();
                   // Console.WriteLine(commdStr + " 执行结果：" + ret.ToString());
                   
                }
                catch (Exception e)
                {

                    Console.WriteLine(commdStr + " 执行错误：" + e.Message);
                }

            }
            return ret;
        }

        public MySqlDataReader DoGetReader(string commdStr)
        {
            MySqlDataReader ret = null;
            using (MySqlCommand cmd2 = new MySqlCommand(commdStr, sqlConn))
            {
                try
                {
                    ret = cmd2.ExecuteReader();
                   // Console.WriteLine(commdStr + " 执行结果：" + ret.ToString());
                }
                catch (Exception e)
                {

                    Console.WriteLine(commdStr + " 执行错误：" + e.Message);
                }

            }
            return ret;
        }


        public DataTable ExecuteDataTable(string commdStr)
        {
            return null;
        }
    }
}

