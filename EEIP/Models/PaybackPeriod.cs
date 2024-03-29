﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEIP.Models
{
    public class PaybackPeriod
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Month { get; set; }
        public double Investment { get; set; }
        public double CashFlow { get; set; }
        public string Result { get; set; }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
