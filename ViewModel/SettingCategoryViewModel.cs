using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class SettingCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

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

        public string SNAddLine1 { get; set; }



















    }
}