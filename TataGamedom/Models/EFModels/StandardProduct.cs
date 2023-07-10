namespace TataGamedom.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StandardProduct
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public bool? AutoOrder { get; set; }

        public virtual Product Product { get; set; }
    }
}
