using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class SettingCategoryViewModel
    {
        public int id { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "TypeCode")]
        public string TypeCode { get; set; }
        [Display(Name = "SN Plant Name")]
        public string SNPlantName { get; set; }
        [Display(Name = "Shipping Address Line 1")]
        public string SNPlantAddressLine1 { get; set; }
        [Display(Name = "Shipping Address Line 2")]
        public string SNPlantAddressLine2 { get; set; }
        [Display(Name = "Shipping Address Line 3")]
        public string SNPlantAddressLine3 { get; set; }
        [Display(Name = "Dist")]
        public string Dist { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        // Consignee Details
        [Display(Name = "Consignee Name")]
        public string ConsigneeAddressName { get; set; }

        [Display(Name = "Consignee Address Line 1")]
        public string ConsigneeAddressLine1 { get; set; }

        [Display(Name = "Consignee Address Line 2")]
        public string ConsigneeAddressLine2 { get; set; }

        [Display(Name = "Consignee Address Line 3")]
        public string ConsigneeAddressLine3 { get; set; }

        [Display(Name = "Consignee District")]
        public string ConsigneeDist { get; set; }

        [Display(Name = "Consignee State")]
        public string ConsigneeState { get; set; }

        [Display(Name = "Consignee Country")]
        public string ConsigneeCountry { get; set; }

        [Display(Name = "Consignee Facility")]
        public string ConsigneeFacility { get; set; }

        [Display(Name = "Consignee Phone")]
        public int? ConsigneePhone { get; set; }

        // Buyer Details
        [Display(Name = "Buyer Name")]
        public string BuyerAddressName { get; set; }

        [Display(Name = "Buyer Address Line 1")]
        public string BuyerAddressLine1 { get; set; }

        [Display(Name = "Buyer Address Line 2")]
        public string BuyerAddressLine2 { get; set; }

        [Display(Name = "Buyer Address Line 3")]
        public string BuyerAddressLine3 { get; set; }

        [Display(Name = "Buyer District")]
        public string BuyerDist { get; set; }

        [Display(Name = "Buyer State")]
        public string BuyerState { get; set; }

        [Display(Name = "Buyer Country")]
        public string BuyerCountry { get; set; }

        [Display(Name = "Buyer Facility")]
        public string BuyerFacility { get; set; }

        [Display(Name = "Buyer Phone")]
        public int? BuyerPhone { get; set; }

        [Display(Name = "Final Destination")]
        public string FinalDestination { get; set; }

        [Display(Name = "Port Of Discharge")]
        public string PortOfDischarge { get; set; }
        [Display(Name = "Kind Attention")]
        public string KindAttention { get; set; }

        [Display(Name = "Port of Loading")]
        public string PortOfLoading { get; set; }

        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; }

        [Display(Name = "Vessel/Flight No.")]
        public string Vessel_FlightNo { get; set; }

        [Display(Name = "Terms of Delivery")]
        public string TermsOfDelivery { get; set; }

        [Display(Name = "IEC Number")]
        public string IECNO { get; set; }

        [Display(Name = "GSTIN")]
        public string GSTIN { get; set; }

        [Display(Name = "FEI")]
        public string FEI { get; set; }

        [Display(Name = "FDA Facility Registration")]
        public string FDAFacilityRegn { get; set; }

        [Display(Name = "CIN")]
        public string CIN { get; set; }

        [Display(Name = "Signature")]
        public string Signature { get; set; }



    }
}