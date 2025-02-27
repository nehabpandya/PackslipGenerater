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
                   id = x.ID,
                   PackslipNo = x.PackslipNo,
                   InvoiceNo = x.InvoiceNo
               })
               .ToList();
            ViewPackSlipViewModel model = new ViewPackSlipViewModel();
            model.ListOfPackList = list;
            return View(model);
        }

        public ActionResult GeneratePackslip(int packslipNo, int invoiceNo)
        {
            GeneratedViewmodel model = new GeneratedViewmodel
            {
                PackSlipMainData = new ViewPackSlip
                {
                    id = 1,
                    PackslipNo = 1,
                    InvoiceNo = 1,
                }, 
                UseInputList = new ViewPackSlipViewModel(), // Initialize as needed
                InvoiceNo = invoiceNo,
                InvoiceDate = DateTime.Now,
                PackSlipDate = DateTime.Now.AddDays(-1),
                AddressHeading = "Dummy Address Heading",
                Address = "123, Dummy Street, City, Country",
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
                Consignee = "XYZ Corporation",
                BuyerPONum = 987654,
                BuyerDate = DateTime.Now.AddDays(-10),
                SummaryOfAdvanceLicence = "Summary here",
                ExportItemSrNo = "EXP12345",
                ExportQty = "1000",
                ImportItemDesc = "Imported Goods",
                ImportObigationKg = "500 KG",
                PoItemList = new List<ListOfItemsInPo> // Changed to List
                   {
                    new ListOfItemsInPo
                    {
                        AdvanceLicenceNo = 456789,
                        A4Lot = 12,
                        PartNum = "P1234",
                        PartDesc = "Sample Part 1",
                        qtyPc = 50,
                        qtyKg = 100,
                        UnitPrice = 500.75,
                        TotalValue = 50075
                    },
                    new ListOfItemsInPo
                    {
                        AdvanceLicenceNo = 456790,
                        A4Lot = 15,
                        PartNum = "P5678",
                        PartDesc = "Sample Part 2",
                        qtyPc = 30,
                        qtyKg = 60,
                        UnitPrice = 300.50,
                        TotalValue = 18030
                    },
                    new ListOfItemsInPo
                    {
                        AdvanceLicenceNo = 456791,
                        A4Lot = 20,
                        PartNum = "P91011",
                        PartDesc = "Sample Part 3",
                        qtyPc = 75,
                        qtyKg = 150,
                        UnitPrice = 450.00,
                        TotalValue = 33750
                    }
                }
            };

            return View();
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