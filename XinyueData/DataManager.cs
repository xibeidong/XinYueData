using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinyueData
{
    public class DataManager
    {
        private DataManager() { }
        static DataManager _instance;
        public static DataManager Instance {
            get {
                if (_instance==null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }

        }

        public Dictionary<string, string> FiledsDict = new Dictionary<string, string>();

        public void init()
        {
            string str = "QQ号, QQ等级, 性别, 年龄, 心悦会员, 财付通, 游戏人生, 应用中心, QQ会员, QQ蓝钻, QQ游戏, QQ紫钻, QQ黑钻, 地下城与勇士, 英雄联盟, 斗战神VIP, 斗战神, 剑灵, 天涯明月刀, 上古世纪, 御龙在天, 疾风之刃, 轩辕传奇, 逆战, QQ飞车, QQ炫舞, 穿越火线, 战地之王, 寻仙, QQ三国, QQ堂, QQ音速, QQ幻想, QQ自由幻想, QQ幻想世界, NBA2K Online,QQ仙灵,QQ仙侠传,全民超神,枪林弹雨,英雄之刃,枪神纪,七雄争霸,王朝霸域,天堂,火影忍者,传奇霸业,热血江湖,斩仙,倚天,苍穹变,天书残卷,勇者之塔,蜀山传奇,仙魂,六界仙尊,焚天,纵横九州,花千骨,三国乱世,龙骑士传,暴风王座,奇迹战神,战神霸业,古剑奇谭";
            string[] strs = str.Split(',');

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i]!=null)
                {
                    FiledsDict.Add(strs[i].Trim(), "f" + i);
                }
            }
           
        }
    }
}
