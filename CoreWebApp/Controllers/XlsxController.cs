using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class XlsxController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public XlsxController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Excel导入功能
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Import(IFormFile excelFile)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    excelFile.CopyTo(fs);
                    fs.Flush();
                }
                //using (ExcelPackage package = new ExcelPackage(file))
                //{
                //    StringBuilder sb = new StringBuilder();
                //    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                //    int rowCount = worksheet.Dimension.Rows;
                //    int ColCount = worksheet.Dimension.Columns;
                //    bool bHeaderRow = true;
                //    for (int row = 1; row <= rowCount; row++)
                //    {
                //        for (int col = 1; col <= ColCount; col++)
                //        {
                //            if (bHeaderRow)
                //            {
                //                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                //            }
                //            else
                //            {
                //                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                //            }
                //        }
                //        sb.Append(Environment.NewLine);
                //    }
                //    return Content(sb.ToString());
                //}
                TestExcelRead(file.ToString());

                return Content("Ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public IActionResult Export()
        {
            #region 别的
            //string sWebRootFolder = _hostingEnvironment.WebRootPath;
            //string sFileName = $"{Guid.NewGuid().ToString("N")}.xlsx";
            //FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            //using (ExcelPackage package = new ExcelPackage(file))
            //{
            //    // 添加worksheet
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("aspnetcore");
            //    //添加头
            //    worksheet.Cells[1, 1].Value = "ID";
            //    worksheet.Cells[1, 2].Value = "Name";
            //    worksheet.Cells[1, 3].Value = "Url";
            //    //添加值
            //    worksheet.Cells["A2"].Value = 1000;
            //    worksheet.Cells["B2"].Value = "LineZero";
            //    worksheet.Cells["C2"].Value = "http://www.cnblogs.com/linezero/";

            //    worksheet.Cells["A3"].Value = 1001;
            //    worksheet.Cells["B3"].Value = "LineZero GitHub";
            //    worksheet.Cells["C3"].Value = "https://github.com/linezero";
            //    worksheet.Cells["C3"].Style.Font.Bold = true;

            //    package.Save();
            //}
            //return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            #endregion
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid().ToString("N")}.xlsx";
            string filePath = Path.Combine(sWebRootFolder, sFileName);
            TestExcelWrite(filePath);


            TestExcelRead(filePath);



            return Content("Ok");
        }

        /// <summary>
        /// Excel读取
        /// </summary>
        /// <param name="filePath"></param>
        private void TestExcelRead(string filePath)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    DataTable dt = excelHelper.ExcelToDataTable("MySheet", true);
                    PrintData(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


        }

        private void PrintData(DataTable dt)
        {
            if (dt == null) return;
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                object obRow = dt.Rows[i];

                for (int j = 0; j < dt.Columns.Count; ++j)
                {
                    object obCell = dt.Rows[i][j];
                    Console.Write("{0} ", dt.Rows[i][j]);
                }

                Console.Write("\n");
            }
        }

        /// <summary>
        /// Excel写
        /// </summary>
        /// <param name="file"></param>
        private void TestExcelWrite(string file)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(file))
                {
                    DataTable data = GenerateData();
                    int count = excelHelper.DataTableToExcel(data, "MySheet", true);
                    if (count > 0)
                        Console.WriteLine("Number of imported data is {0} ", count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private DataTable GenerateData()
        {
            DataTable data = new DataTable();
            for (int i = 0; i < 5; ++i)
            {
                data.Columns.Add("Columns_" + i.ToString(), typeof(string));
            }

            for (int i = 0; i < 10; ++i)
            {
                DataRow row = data.NewRow();
                row["Columns_0"] = "item0_" + i.ToString();
                row["Columns_1"] = "item1_" + i.ToString();
                row["Columns_2"] = "item2_" + i.ToString();
                row["Columns_3"] = "item3_" + i.ToString();
                row["Columns_4"] = "item4_" + i.ToString();
                data.Rows.Add(row);
            }
            return data;
        }
    }
}