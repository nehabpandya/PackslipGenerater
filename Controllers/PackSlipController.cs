using Antlr.Runtime;
using PackSlipApp.Database.Models;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    public class PackSlipController : Controller
    {
        // GET: PackSlip
        ITe_INDIAEntities1 context = new ITe_INDIAEntities1();
        public ActionResult ViewPackSlip()
        {
            List<ViewPackSlip> list = context.Dispatch_PackingDetails
               .Select(x => new ViewPackSlip
               {
                   Id = x.ID,
                   PackslipNo = x.PackslipNo,
                   InvoiceNo = x.InvoiceNo
               })
               .ToList();
            ViewPackSlipViewModel model = new ViewPackSlipViewModel
            {
                ListOfPackList = list
            };
            return View(model);
        }

        public ActionResult GeneratePackslip(string packslipNo, string invoiceNo)
        {
            dispatch_Staticdata addDetails = context.dispatch_Staticdata.FirstOrDefault();
            GeneratedViewmodel model = new GeneratedViewmodel
            {

                SNAddLine1 = addDetails.SNAddLine1,
                SNAddLine2 = addDetails.SNAddLine2,
                SNAddLine3 = addDetails.SNAddLine3,
                SNAddLine4 = addDetails.SNAddLine4,
                SNAddLine5 = addDetails.SNAddLine5,
                SNAddLine6 = addDetails.SNAddLine6,
                SNAddLine7 = addDetails.SNAddLine7,
                PortOfLoading = addDetails.PortOfLoading,
                CountryOfOrigin = addDetails.CountryOfOrigin,
                PaymentTerms = addDetails.PaymentTerms,
                TermsOfDelivery = addDetails.TermsOfDelivery,
                IECNO = addDetails.IECNO,
                GSTIN = addDetails.GSTIN,
                FEI_ = addDetails.FEI_,
                FDAFacilityRegn_ = addDetails.FDAFacilityRegn_,
                CIN = addDetails.CIN,

                PackSlipMainData = new ViewPackSlip
                {
                    PackslipNo = packslipNo,
                    InvoiceNo = invoiceNo,
                },
                InvoiceNo = invoiceNo,
                InvoiceDate = DateTime.Now,
                PackSlipDate = DateTime.Now,
                AddressHeading = "Exporter", 
                
                BuyerPONum = 987654,
                BuyerDate = DateTime.Now.AddDays(-10),
                SummaryOfAdvanceLicence = "Summary here",
               
                ImportObigationKg = "500 KG",

                PoItemList = context.Dispatch_Data.
                Where(d => d.PackslipNo == packslipNo && d.InvoiceNo == invoiceNo)
                  .Select(x => new ListOfItemsInPo
                  {
                      AdvanceLicenceNo = 1,
                      PONo = x.PoNo,
                      A4Lot = 20,
                      PartNum = x.PartNo,
                      PartDesc = x.PartDesc,
                      QtyWPc = x.Qty,
                      UnitPrice = 450.00,

                  })
                .ToList()
            };
            return View(model);
        }

        public int TotalPalate(List<(int length, int width, int height)> dimensions)
        {
            // Pallet capacities based on box dimensions
            Dictionary<(int, int, int), int> capacityLookup = new Dictionary<(int, int, int), int>()
            {
                {(15, 10, 4), 30}, // 30 boxes per pallet
                {(10, 10, 5), 36}, // 36 boxes per pallet
                {(17, 14, 6), 12}  // 12 boxes per pallet
            };

            Dictionary<(int, int, int), int> boxCount = new Dictionary<(int, int, int), int>(); // To count how many boxes per type

            // Count each box size
            foreach (var box in dimensions)
            {
                if (boxCount.ContainsKey(box))
                    boxCount[box]++;
                else
                    boxCount[box] = 1;
            }

            int totalPalateNo = 0;

            // Calculate required pallets
            foreach (var entry in boxCount)
            {
                var boxSize = entry.Key;
                int count = entry.Value;

                if (capacityLookup.TryGetValue(boxSize, out int capacity))
                {
                    totalPalateNo += (int)Math.Ceiling((double)count / capacity);
                }
                else
                {
                    // If box size is unknown, assume 1 box per pallet
                    totalPalateNo += count;
                }
            }

            return totalPalateNo;
        }
        public ActionResult GenerateInvoice(int packslipNo, int invoiceNo)
        {
            return View();
        }
        public void DownloadExcel()
        {

        }
    }
}