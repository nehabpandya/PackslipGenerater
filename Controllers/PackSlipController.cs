using Antlr.Runtime;
using PackSlipApp.Database.Models;
using PackSlipApp.Filter;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    [SessionCheckFilter]
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

        public ActionResult GeneratePackslip(int ID, string type)
        {
            dispatch_Staticdata addDetails = context.dispatch_Staticdata.FirstOrDefault();
            GeneratedViewmodel Model = new GeneratedViewmodel();

            try
            {

                Dispatch_PackingDetails _PackingDetails = context.Dispatch_PackingDetails.Where(p => p.ID == ID).FirstOrDefault();
                if (_PackingDetails != null)
                {
                    dispatch_Staticdata dispatch_Staticdata = context.dispatch_Staticdata.FirstOrDefault();

                    dispatch_type _Type = context.dispatch_type.Where(p => p.type == _PackingDetails.Category).FirstOrDefault();

                    Model.InvoiceNo = _PackingDetails.InvoiceNo;
                    Model.PackSlipNo = _PackingDetails.PackslipNo;
                    Model.Category = _PackingDetails.Category;
                    Model.InvoiceDate = DateTime.Now;
                    Model.PackslipDate = DateTime.Now;
                    Model.SNAddLine1 = dispatch_Staticdata.SNAddLine1;
                    Model.SNAddLine2 = dispatch_Staticdata.SNAddLine2;
                    Model.SNAddLine3 = dispatch_Staticdata.SNAddLine3;
                    Model.SNAddLine4 = dispatch_Staticdata.SNAddLine4;
                    Model.SNAddLine5 = dispatch_Staticdata.SNAddLine5;
                    Model.SNAddLine6 = dispatch_Staticdata.SNAddLine6;
                    Model.SNAddLine7 = dispatch_Staticdata.SNAddLine7;
                    Model.PortOfLoading = dispatch_Staticdata.PortOfLoading;
                    Model.CountryOfOrigin = dispatch_Staticdata.CountryOfOrigin;
                    Model.PaymentTerms = dispatch_Staticdata.PaymentTerms;
                    Model.TermsOfDelivery = dispatch_Staticdata.TermsOfDelivery;
                    Model.IECNO = dispatch_Staticdata.IECNO;
                    Model.GSTIN = dispatch_Staticdata.GSTIN;
                    Model.FEI_ = dispatch_Staticdata.FEI_;
                    Model.FDAFacilityRegn_ = dispatch_Staticdata.FDAFacilityRegn_;
                    Model.CIN = dispatch_Staticdata.CIN;

                    Model.ConsigneeAddressName = _Type.ConsigneeAddressName;
                    Model.ConsigneeAddressLine1 = _Type.ConsigneeAddressLine1;
                    Model.ConsigneeAddressLine2 = _Type.ConsigneeAddressLine2;
                    Model.ConsigneeAddressLine3 = _Type.ConsigneeAddressLine3;
                    Model.ConsigneeDist = _Type.ConsigneeDist;
                    Model.ConsigneeState = _Type.ConsigneeState;
                    Model.ConsigneeCountry = _Type.ConsigneeCountry;
                    Model.ConsigneeFacility = _Type.ConsigneeFacility;
                    Model.ConsigneePhone = _Type.ConsigneePhone;
                    Model.BuyerAddressName = _Type.BuyerAddressName;
                    Model.BuyerAddressLine1 = _Type.BuyerAddressLine1;
                    Model.BuyerAddressLine2 = _Type.BuyerAddressLine2;
                    Model.BuyerAddressLine3 = _Type.BuyerAddressLine3;
                    Model.BuyerDist = _Type.BuyerDist;
                    Model.BuyerState = _Type.BuyerState;
                    Model.BuyerFacility = _Type.BuyerFacility;
                    Model.BuyerCountry = _Type.BuyerCountry;
                    Model.BuyerPhone = _Type.BuyerPhone;


                    Model.PoItemList = (from modal in context.Dispatch_Data.Where(p => p.PID == ID)
                                        select new ListOfItemsInPo
                                        {
                                            AdvanceLicenceNo = modal.LineNo,
                                            PONo = modal.PoNo,
                                            Qty = modal.Qty,
                                            QtyWPc = modal.wPcs,
                                            UOM = "Pcs",
                                            PartNum = modal.PartNo,
                                            Box = modal.Box,
                                            BoxType = modal.PackingType,
                                            //PartDesc = 
                                        }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return View(Model);
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
        public ActionResult GenerateInvoice( int ID)
        {
            dispatch_Staticdata addDetails = context.dispatch_Staticdata.FirstOrDefault();
            GeneratedViewmodel Model = new GeneratedViewmodel();

            try
            {

                Dispatch_PackingDetails _PackingDetails = context.Dispatch_PackingDetails.Where(p => p.ID == ID).FirstOrDefault();
                if (_PackingDetails != null)
                {
                    dispatch_Staticdata dispatch_Staticdata = context.dispatch_Staticdata.FirstOrDefault();

                    dispatch_type _Type = context.dispatch_type.Where(p => p.type == _PackingDetails.Category).FirstOrDefault();

                    Model.InvoiceNo = _PackingDetails.InvoiceNo;
                    Model.PackSlipNo = _PackingDetails.PackslipNo;
                    Model.Category = _PackingDetails.Category;
                    Model.InvoiceDate = DateTime.Now;
                    Model.PackslipDate = DateTime.Now;
                    Model.SNAddLine1 = dispatch_Staticdata.SNAddLine1;
                    Model.SNAddLine2 = dispatch_Staticdata.SNAddLine2;
                    Model.SNAddLine3 = dispatch_Staticdata.SNAddLine3;
                    Model.SNAddLine4 = dispatch_Staticdata.SNAddLine4;
                    Model.SNAddLine5 = dispatch_Staticdata.SNAddLine5;
                    Model.SNAddLine6 = dispatch_Staticdata.SNAddLine6;
                    Model.SNAddLine7 = dispatch_Staticdata.SNAddLine7;
                    Model.PortOfLoading = dispatch_Staticdata.PortOfLoading;
                    Model.CountryOfOrigin = dispatch_Staticdata.CountryOfOrigin;
                    Model.PaymentTerms = dispatch_Staticdata.PaymentTerms;
                    Model.TermsOfDelivery = dispatch_Staticdata.TermsOfDelivery;
                    Model.IECNO = dispatch_Staticdata.IECNO;
                    Model.GSTIN = dispatch_Staticdata.GSTIN;
                    Model.FEI_ = dispatch_Staticdata.FEI_;
                    Model.FDAFacilityRegn_ = dispatch_Staticdata.FDAFacilityRegn_;
                    Model.CIN = dispatch_Staticdata.CIN;

                    Model.ConsigneeAddressName = _Type.ConsigneeAddressName;
                    Model.ConsigneeAddressLine1 = _Type.ConsigneeAddressLine1;
                    Model.ConsigneeAddressLine2 = _Type.ConsigneeAddressLine2;
                    Model.ConsigneeAddressLine3 = _Type.ConsigneeAddressLine3;
                    Model.ConsigneeDist = _Type.ConsigneeDist;
                    Model.ConsigneeState = _Type.ConsigneeState;
                    Model.ConsigneeCountry = _Type.ConsigneeCountry;
                    Model.ConsigneeFacility = _Type.ConsigneeFacility;
                    Model.ConsigneePhone = _Type.ConsigneePhone;
                    Model.BuyerAddressName = _Type.BuyerAddressName;
                    Model.BuyerAddressLine1 = _Type.BuyerAddressLine1;
                    Model.BuyerAddressLine2 = _Type.BuyerAddressLine2;
                    Model.BuyerAddressLine3 = _Type.BuyerAddressLine3;
                    Model.BuyerDist = _Type.BuyerDist;
                    Model.BuyerState = _Type.BuyerState;
                    Model.BuyerFacility = _Type.BuyerFacility;
                    Model.BuyerCountry = _Type.BuyerCountry;
                    Model.BuyerPhone = _Type.BuyerPhone;


                    Model.PoItemList = (from modal in context.Dispatch_Data.Where(p => p.PID == ID)
                                        select new ListOfItemsInPo
                                        {
                                            AdvanceLicenceNo = modal.LineNo,
                                            PONo = modal.PoNo,
                                            Qty = modal.Qty,
                                            QtyWPc = modal.wPcs,
                                            UOM = "Pcs",
                                            PartNum = modal.PartNo,
                                            Box = modal.Box,
                                            BoxType = modal.PackingType,
                                            //PartDesc = 
                                        }).ToList();

                }
            }
            catch (Exception)
            {

            }

            return View(Model);
        }
        public void DownloadExcel()
        {

        }
    }
}