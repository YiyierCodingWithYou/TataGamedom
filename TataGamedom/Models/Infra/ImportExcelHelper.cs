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
        public HttpPostedFileBase file { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var file = validationContext.ObjectInstance as HttpPostedFileBase;
            
            if (file == null || file.ContentLength == 0) 
            {
                yield return new ValidationResult("請選取檔案", new List<string> {"file"});
            }

            var validExtensions = new[] { ".xls", ".xlsx" };
            var fileExtension = Path.GetExtension(file.FileName);
            if (validExtensions.Any(e => e.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)) == false) 
            {
                yield return new ValidationResult("僅能上傳Excel檔", new List<string> { "file" });
            }
        }
    }

}