using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDAssignment2._0
{
    public class DataModels
    {
        public class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
        }

        public class Resource
        {
            public int ResourceID { get; set; }
            public int CategoryID { get; set; }
            public string ResourceName { get; set; }
            public byte[] Images { get; set; }
        }

        public class Booking
        {
            public int BookingID { get; set; }
            public int ResourceID { get; set; }
            public DateTime? SlotDate { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string BookedBy { get; set; }
            public DateTime? BookingDate { get; set; }
        }
    }
}
