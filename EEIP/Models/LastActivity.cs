using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEIP.Models
{
    public class LastActivity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int ActivityType { get; set; }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
