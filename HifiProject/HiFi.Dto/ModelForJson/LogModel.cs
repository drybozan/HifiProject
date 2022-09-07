using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFi.Dto.ModelForJson
{
        public class LogModel
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string FirstPage { get; set; }
            public string LastPage { get; set; }
            public int TotalPages { get; set; }
            public int TotalRecords { get; set; }
            public string NextPage { get; set; }
            public object PreviousPage { get; set; }
            public List<LogDto> Data { get; set; }
        }
    
}
