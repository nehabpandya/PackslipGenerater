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
        public int Id { get; set; }
        public string PartNo { get; set; }
        public string JobNo { get; set; }
        public bool? LM { get; set; }
        public int Qty { get; set; }
        public decimal WPcs { get; set; }
        public int? Box { get; set; }
        public string Po { get; set; }
        public int? LineNo { get; set; }
        public string MaterialDetails { get; set; }
        public decimal TotalWeight { get; set; }
        public string PackingType { get; set; }
        public decimal BoxWeight { get; set; }


    }

   
}