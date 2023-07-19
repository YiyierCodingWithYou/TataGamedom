using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class NewsCategoryCode
    {
        public NewsCategoryCode()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<News> News { get; set; }
    }
}
