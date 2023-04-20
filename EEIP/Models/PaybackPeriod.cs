using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEIP.Models
{
    public class PaybackPeriod
    {
        [AutoIncrement]
        public int Id { get; set; }
        public int Month { get; set; }
        public double Investment { get; set; }
        public  double CashFlow { get; set; }
    }
}
