using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            if (Session["Name"] != null)
            {
                return View("Index");
            }
            else
            {
                return PartialView("Login");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        ////upon calling this method creates '.xlsx' file and places in downloads
        //public void CreateExcelFirstTemplate()
        //{
        //    List<string> userAssessmentsData = new List<string>() { "1","2","3","4","5","6","7","8","9","0" };
        //    //sets the file name
        //    var fileName = "ExcellData.xlsx";
        //    //sets fileinfo to the file name for system.io
        //    var file = new FileInfo(fileName);
        //    using (var package = new OfficeOpenXml.ExcelPackage(file))
        //    {
        //        //searches through the workbook for a worksheet with the name of Attempts
        //        var worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Attempts");
        //        //creates a new worksheet with the name of assessment attempts
        //        worksheet = package.Workbook.Worksheets.Add("Assessment Attempts");
        //        worksheet.Row(1).Height = 20;
        //        //sets the tab color
        //        worksheet.TabColor = Color.Gold;
        //        worksheet.DefaultRowHeight = 12;
        //        worksheet.Row(1).Height = 20;
        //        //names cells with repected string value
        //        worksheet.Cells[1, 1].Value = "Employee Number";
        //        worksheet.Cells[1, 2].Value = "Course Code";

        //        var cells = worksheet.Cells["A1:J1"];
        //        //starting at row 2 because the first row is labels
        //        var rowCounter = 2;
        //        foreach (var v in userAssessmentsData)
        //        {
        //            worksheet.Cells[rowCounter, 1].Value = v;

        //            rowCounter++;
        //        }
        //        //lines up the colums to match contents
        //        worksheet.Column(1).AutoFit();
        //        worksheet.Column(2).AutoFit();


        //        package.Workbook.Properties.Title = "Attempts";
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader(
        //                  "content-disposition",
        //                  string.Format("attachment;  filename={0}", "ExcellData.xlsx"));
        //        Response.BinaryWrite(package.GetAsByteArray());
        //    }
        //}
    }
}
