using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class ViewPackSlipViewModel
    {
       public List<ViewPackSlip> ListOfPackList = new List<ViewPackSlip>();
    }

    public class ViewPackSlip
    {
        public int id { get; set; }
        public int? PackslipNo { get; set; }
        public int? InvoiceNo { get; set; }
    }
}