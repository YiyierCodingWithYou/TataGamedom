using DocumentFormat.OpenXml.Drawing;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using Path = System.IO.Path;

namespace TataGamedom.Models.Infra
{
    public class ImportExcelHelper : IValidatableObject
    {
        [Required(ErrorMessage ="請選取檔案")]
        public HttpPostedFileBase File { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var importExcel = validationContext.ObjectInstance as ImportExcelHelper;
            
            if (importExcel.File == null || importExcel.File.ContentLength == 0) 
            {
                yield return new ValidationResult("請選取檔案", new List<string> {"File"});
            }

            var validExtensions = new[] { ".xls", ".xlsx" };

            if (Path.GetExtension(importExcel.File.FileName) == null) 
            {
                yield return new ValidationResult("僅能上傳Excel檔", new List<string> { "File" });
            }

            if (validExtensions.Any(e => e.Equals(Path.GetExtension(importExcel.File.FileName), StringComparison.OrdinalIgnoreCase)) == false) 
            {
                yield return new ValidationResult("僅能上傳Excel檔", new List<string> { "File" });
            }
        }
    }

}