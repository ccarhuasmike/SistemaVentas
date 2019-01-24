using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Pagination
    {
        public int CurrentPage { get; set; } = 0;  
        public int ItemsPerPage { get; set; }        
        public int TotalItems { get; set; }        
        public int TotalPages { get; set; }
    }
}
