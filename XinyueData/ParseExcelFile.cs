using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;
namespace XinyueData
{
    public class CountNum{
        public int repeatCount = 0;
        public int newAddCount = 0;
        public int unuseCount = 0;
        public bool doOk = false;
    }
    public class ParseExcelFile
    {
        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string fileName,string sheetName = null, bool isColumnWritten=false)
        {

            IWorkbook workbook = null;
            FileStream fs = null;

     

            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                fs.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string fileName,string sheetName=null, bool isFirstRowColumn=true)
        {

            IWorkbook workbook = null;
            FileStream fs = null;

            ISheet sheet = null;


            DataTable data = new DataTable();
            int startRow = 0;
          //  try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        if (row.FirstCellNum < 0)
                        {
                            continue;
                        }
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                
                fs.Close();
                return data;
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception: " + ex.Message);
            //    return null;
            //}

          
        }

        public CountNum ExcelToMysql(string fileName)
        {
            CountNum cn = new CountNum();

            MySqlHelper.Instance.init();
            Dictionary<string, string> dict = DataManager.Instance.FiledsDict;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return cn;
            }
             
            IWorkbook workbook = null;
            ISheet sheet = null;
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook(fs);
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook(fs);
            if (workbook == null)
            {
                fs.Close();
                return cn;
            }

            sheet = workbook.GetSheetAt(0);
            if (sheet == null)
            {
                fs.Close();
                return cn;
            }

            try
            {
                IRow firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                int rowCount = sheet.LastRowNum;
                for (int i = 1; i < rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.GetCell(1).ToString() == ""||row.GetCell(4).ToString()=="") continue;//无QQ号等级,无心悦等级 的不处理
                                                         // "insert into vipxy2 (in_time,{0},{1}) values (now(),{0},{1}) ON DUPLICATE KEY UPDATE update_time = now()",

                    string sql = "insert into vipxy2 (in_time,{0},{1}) values (now(),{0},{1}) ON DUPLICATE KEY UPDATE update_time = now()";
                    string str1 = "";
                    string str2 = "";
                    for (int j = 0; j < cellCount; j++)
                    {
                        string tempStr = row.GetCell(j).ToString().Trim();
                        if (tempStr=="")
                        {
                            continue;
                        }
                        str1 += dict[firstRow.GetCell(j).ToString().Trim()]+",";
                        str2 += "'"+tempStr+"',";
                    }
                    str1 = str1.Substring(0, str1.Length - 1);//去掉最后的逗号
                    str2 = str2.Substring(0, str2.Length - 1);

                    sql = string.Format("insert into vipxy2 (in_time,{0}) values (now(),{1}) ON DUPLICATE KEY UPDATE update_time = now()", str1, str2);

                   int ret = MySqlHelper.Instance.Do(sql);
                    if (ret==1)
                    {
                        cn.newAddCount++;
                    }
                    else if (ret==2)
                    {
                        cn.repeatCount++;
                    }
                }

                fs.Close();
            }
            catch (Exception e)
            {

                fs.Close();
                Console.WriteLine(e.Message);
                return cn;
            }
            return cn;
        }
    }
}
