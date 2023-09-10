using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurnal
{
    public class Mark
    {
        public string Drade { get; set; }
        public DateTime Date { get; set; }
        public Mark(string drade)
        {
            Drade = drade;
            Date = DateTime.Now;
        }
    }
}
