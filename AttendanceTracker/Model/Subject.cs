using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTracker.Model
{
    public class Subject
    {
        public string Name { get; set; }

        public int held { get; set; }

        public int attended { get; set; }

        public double peratt { get; set; }

        public double minreq { get; set; }

        public DateTime lastUpdate { get; set; }

        public void updateNow()
        {
            peratt = attended / held;
            lastUpdate = DateTime.Today;
        }

    }
}
