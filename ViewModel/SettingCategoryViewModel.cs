using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackSlipApp.ViewModel
{
    public class SettingCategoryViewModel
    {
        public int id { get; set; }
        public string Type { get; set; }
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

        public string BuyerCountry { get; set; }

        public string BuyerFacility { get; set; }

        public int? BuyerPhone { get; set; }

    }
}