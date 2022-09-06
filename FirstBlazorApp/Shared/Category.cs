using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Shared
{
    public class Category
    {
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
