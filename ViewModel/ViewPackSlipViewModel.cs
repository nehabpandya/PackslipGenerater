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
        public int Id { get; set; }
        public string PackslipNo { get; set; }
        public string InvoiceNo { get; set; }
    }
}