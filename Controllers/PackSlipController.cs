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
            var addDetails = context.dispatch_Staticdata.FirstOrDefault();
            GeneratedViewmodel model = new GeneratedViewmodel
            {

                PackSlipMainData = new ViewPackSlip
                {
                    PackslipNo = packslipNo,
                    InvoiceNo = invoiceNo,
                },

                InvoiceNo = invoiceNo,
                InvoiceDate = DateTime.Now,
                PackSlipDate = DateTime.Now,
                AddressHeading = "Exporter", // need to discuss
                Address = addDetails.SNPlantAdd,
                CIN = "CIN123456",
                IEC = "IEC654321",
                GSTIN = "GSTIN789012",
                FEC = 1234,
                FDA = 5678,
                PortOfLoading = "Mumbai",
                PortOfDischarge = "New York",
                FinalDestination = "Los Angeles",
                CountryOfOrigin = "India",
                DestinationCountry = "USA",
                PayementTerms = "30 Days Credit",
                TermsOfDelivery = "FOB",
                OtherReference = "Ref-001",
                OtherDetails = "Some additional details",
                Consignee = addDetails.ConsigneeAdd,
                BuyerPONum = 987654,
                BuyerDate = DateTime.Now.AddDays(-10),
                SummaryOfAdvanceLicence = "Summary here",
               
                ImportObigationKg = "500 KG",

                PoItemList = context.Dispatch_Data.
                Where(d => d.PackslipNo == packslipNo && d.InvoiceNo == invoiceNo)
                  .Select(x => new ListOfItemsInPo
                  {
                      AdvanceLicenceNo = 1,
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


        public ActionResult GenerateInvoice(int packslipNo, int invoiceNo)
        {
          
            return View();
        }

        public void DownloadExcel()
        {

        }
    }
}