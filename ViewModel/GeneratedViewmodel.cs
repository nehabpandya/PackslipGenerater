using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class GeneratedViewmodel
    {

        public ViewPackSlip PackSlipMainData;

        public ViewPackSlipViewModel UseInputList;

        public string InvoiceNo { get; set; }
        public string PackSlipNo { get; set; }
        public string Category { get; set; }

        public DateTime? InvoiceDate { get; set; }
        //public DateTime? PackslipDate { get; set; }
        public string FormattedInvoiceDate => InvoiceDate?.ToString("dd-MMM-yyyy");

        public DateTime? PackSlipDate { get; set; }
        public string FormattedPackSlipDate => PackSlipDate?.ToString("dd-MMM-yyyy");

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

        public string SNAddLine1 { get; set; }
        public string SNAddLine2 { get; set; }
        public string SNAddLine3 { get; set; }
        public string SNAddLine4 { get; set; }
        public string SNAddLine5 { get; set; }
        public string SNAddLine6 { get; set; }
        public string SNAddLine7 { get; set; }
        public string PaymentTerms { get; set; }
        public string Vessel_FlightNo { get; set; }
        public string IECNO { get; set; }
        public string FEI_ { get; set; }
        public string FDAFacilityRegn_ { get; set; }
        public string Signature { get; set; }

        public string OurAddressName { get; set; }
        public string OurPlantAddressLine1 { get; set; }
        public string OurPlantAddressLine2 { get; set; }
        public string OurPlantAddressLine3 { get; set; }
        public string Dist { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Phone { get; set; }
        public string ConsigneeAddressName { get; set; }
        public string ConsigneeAddressLine1 { get; set; }
        public string ConsigneeAddressLine2 { get; set; }
        public string ConsigneeAddressLine3 { get; set; }
        public string ConsigneeDist { get; set; }
        public string ConsigneeState { get; set; }
        public string ConsigneeCountry { get; set; }
        public string ConsigneeFacility { get; set; }
        public int? ConsigneePhone { get; set; }
        public string BuyerAddressName { get; set; }
        public string BuyerAddressLine1 { get; set; }
        public string BuyerAddressLine2 { get; set; }
        public string BuyerAddressLine3 { get; set; }
        public string BuyerDist { get; set; }
        public string BuyerState { get; set; }
        public string BuyerFacility { get; set; }
        public string BuyerCountry { get; set; }
        public int? BuyerPhone { get; set; }
        public string Portofdischarge { get; set; }
        public string Finaldestination { get; set; }
        public string Kind { get; set; }

    }

    public class ListOfItemsInPo
    {
        public int? AdvanceLicenceNo { get; set; }
        public string PONo { get; set; }
        public int A4Lot { get; set; }
        public string PartNum { get; set; }
        public int? Box { get; set; }
        public string BoxType { get; set; }
        public string PartDesc { get; set; }
        public decimal? QtyWPc { get; set; }
        public decimal? Qty { get; set; }
        public string UOM { get; set; }

        public decimal? QtyKg => (Qty.HasValue && QtyWPc.HasValue) ? (Qty.Value * QtyWPc.Value) : (decimal?)null;
        public decimal? grossweight => (QtyKg ?? 0) + ((Box ?? 0) * (decimal)2.372) + (decimal)15.51;


        public decimal? UnitPrice { get; set; }
        //gross weight formula
        public decimal? TotalValue => (Qty.HasValue && UnitPrice.HasValue) ? (Qty.Value * UnitPrice.Value) : (decimal?)null;

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