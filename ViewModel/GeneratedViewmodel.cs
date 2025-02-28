using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class GeneratedViewmodel
    {

        public ViewPackSlip PackSlipMainData;

        public ViewPackSlipViewModel UseInputList;

        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? PackSlipDate { get; set; }
        public string AddressHeading { get; set; }
        public string Address { get; set; }
        public string CIN { get; set; }
        public string IEC { get; set; }
        public string GSTIN { get; set; }
        public int FEC { get; set; }
        public int FDA { get; set; }
        public string PortOfLoading { get; set; }
        public string PortOfDischarge { get; set; }
        public string FinalDestination { get; set; }
        public string CountryOfOrigin { get; set; }
        public string DestinationCountry { get; set; }
        public string PayementTerms { get; set; }
        public string TermsOfDelivery { get; set; }
        public string OtherReference { get; set; }
        public string OtherDetails { get; set; }
        public string Consignee { get; set; }
        public int BuyerPONum { get; set; }
        public DateTime BuyerDate { get; set; }

        public string SummaryOfAdvanceLicence { get; set; }
       
       
        public string ImportObigationKg { get; set; }
        public List<ListOfItemsInPo> PoItemList { get; set; }

        public double? SumOfTotal { get; set; }
        public double? ExportQtyKgs { get; set; }
        public double? ImportObligationKgs { get; set; }


    }

    public class ListOfItemsInPo
    {
        public int AdvanceLicenceNo { get; set; }
        public int A4Lot { get; set; }
        public string PartNum { get; set; }
        public string PartDesc { get; set; }
        public double? QtyWPc { get; set; }  
        public double? Qty { get; set; }

        public double? QtyKg => (Qty.HasValue && QtyWPc.HasValue) ? (Qty.Value * QtyWPc.Value) : (double?)null;

        public double? UnitPrice { get; set; }

        public double? TotalValue => (Qty.HasValue && UnitPrice.HasValue) ? (Qty.Value * UnitPrice.Value) : (double?)null;

        public string TotalValueInWords => TotalValue.HasValue
        ? ConvertToWords((long)TotalValue.Value)
        : "Zero";
        private string ConvertToWords(long number)
        {
            if (number == 0)
                return "Zero";

            var culture = new CultureInfo("en-IN"); 
            return number.ToString("N0", culture) + " Rupees"; 
        }
        public string ImportItemDesc { get; set; }
    }

  

}