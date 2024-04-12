using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertJsonFileIntoSQLSever.Model
{
    public class SalesDataModel
    {
        public Guid VID { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ProductArea { get; set; }
        public string Manufacturer { get; set; }
        public string GoodsRecNumber { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public int SalesQty { get; set; }
    }
}
