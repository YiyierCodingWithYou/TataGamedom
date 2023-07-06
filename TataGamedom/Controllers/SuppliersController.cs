using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;

namespace TataGamedom.Controllers
{
    public class SuppliersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileResult ExportCSV() 
        {
            string csv = GetSuppliersCSV();

            return File(Encoding.UTF8.GetBytes(csv), "text/csv; charset=utf-8", "Suppliers.csv");
        }
        public string GetSuppliersCSV() 
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id,Name,Phone,Email");

            foreach (var supplier in db.Suppliers) 
            {
                builder.AppendLine($"{supplier.Name},{supplier.Name },{supplier.Phone},{supplier.Email},");
            }
            
            return builder.ToString();
        }

        public FileResult ExportExcel()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Suppliers");
                var currentRow = 1;
                workSheet.Cell(currentRow, 1).Value = "Id";
                workSheet.Cell(currentRow, 2).Value = "Name";
                workSheet.Cell(currentRow, 3).Value = "Phone";
                workSheet.Cell(currentRow, 4).Value = "Email";

                foreach (var supplier in db.Suppliers)
                {
                    currentRow++;
                    workSheet.Cell(currentRow, 1).Value = supplier.Id;
                    workSheet.Cell(currentRow, 2).Value = supplier.Name;
                    workSheet.Cell(currentRow, 3).Value = supplier.Phone;
                    workSheet.Cell(currentRow, 4).Value = supplier.Email;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Suppliers.xlsx");
                }
            }
        }

        [HttpPost]
        public ActionResult Index(ImportExcelHelper importedfile) 
        {
			if (ModelState.IsValid)
			{
				string path = Server.MapPath("~/Files/Uploads" + importedfile.file.FileName);
				importedfile.file.SaveAs(path);

				//寫入連接到 Microsoft Access 和 Excel檔 的Provider
				string excelConnectionString = $@"Provider='Microsoft.ACE.OLEDB.12.0';
Data Source='" + path + "';" +
"Extended Properties='Excel 12.0 Xml;IMEX=1'";


				OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

				excelConnection.Open();
				string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
				excelConnection.Close();

				string cmdText = $@"SELECT * FROM {tableName}";
				OleDbCommand cmd = new OleDbCommand(cmdText, excelConnection);

				excelConnection.Open();
				OleDbDataReader reader = cmd.ExecuteReader();
				SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["AppDbContext"].ToString());
				sqlBulk.DestinationTableName = "Suppliers";
				sqlBulk.ColumnMappings.Add("Name", "Name");
				sqlBulk.ColumnMappings.Add("Phone", "Phone");
				sqlBulk.ColumnMappings.Add("Email", "Email");
				sqlBulk.WriteToServer(reader);
				excelConnection.Close();

				ViewBag.Result = "成功建立資料";
			}
            ViewBag.ImportExcelHelper = new ImportExcelHelper();
			return View();
		}
		[HttpPost]
		public ActionResult Reset()
		{
			Session["ExcelData"] = null;
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
