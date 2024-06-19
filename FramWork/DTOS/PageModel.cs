using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramWork.DTOS
{
    public class PageModel
    {
        public int PageIndex { get; set; }//in mige Saghe number chandi

        public int PageSize { get; set; }//mige chanta to har safhe record bashe

        public int RecordCount { get; set; }//mige kolan chanta record dary

        public int PageCount { get; set; }//hasel Pagesize / recordCount
    }
}
