using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class AddPackingDetailsViewModel
    {
        public List<PackingDetails> PackingList = new List<PackingDetails>();
    }

    public class PackingDetails
    {
        public string Part { get; set; }
        public string JobNumber { get; set; }
        public string PartNumber { get; set; }
        public string Type { get; set; }
        public bool LM { get; set; }
        public int Qty { get; set; }
        

    }

   
}