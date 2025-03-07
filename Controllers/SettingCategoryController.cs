using PackSlipApp.Database.Models;
using PackSlipApp.Filter;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    [SessionCheckFilter]
    public class SettingCategoryController : Controller
    {
        ITe_INDIAEntities1 context = new ITe_INDIAEntities1();

        [HttpPost]
        public ActionResult SaveSettings(SettingCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                // Check if TypeCode already exists
                var existingTypeCode = context.dispatch_type.FirstOrDefault(x => x.TypeCode == model.TypeCode && x.id != model.id);

                if (existingTypeCode != null)
                {
                    TempData["ErrorMessage"] = "TypeCode already exists. Please use a different TypeCode.";
                    model.TypeCode = string.Empty;
                    return View("AddSettings", model);
                }


                // Check if it's an edit or a new record
                var existingRecord = context.dispatch_type.FirstOrDefault(x => x.id == model.id);

                if (existingRecord != null) // Update existing record
                {


                    existingRecord.id = model.id;
                    existingRecord.type = model.Type;
                    existingRecord.TypeCode = model.TypeCode;
                    existingRecord.SN_Plant_Name = model.SNPlantName;
                    existingRecord.SN_PlantAddressLine1 = model.SNPlantAddressLine1;
                    existingRecord.SN_PlantAddressLine2 = model.SNPlantAddressLine2;
                    existingRecord.SN_PlantAddressLine3 = model.SNPlantAddressLine3;
                    existingRecord.Dist = model.Dist;
                    existingRecord.State = model.State;
                    existingRecord.Country = model.Country;
                    existingRecord.Phone = model.Phone;
                    existingRecord.ConsigneeAddressName = model.ConsigneeAddressName;
                    existingRecord.ConsigneeAddressLine1 = model.ConsigneeAddressLine1;
                    existingRecord.ConsigneeAddressLine2 = model.ConsigneeAddressLine2;
                    existingRecord.ConsigneeAddressLine3 = model.ConsigneeAddressLine3;
                    existingRecord.ConsigneeDist = model.ConsigneeDist;
                    existingRecord.ConsigneeState = model.ConsigneeState;
                    existingRecord.ConsigneeCountry = model.ConsigneeCountry;
                    existingRecord.ConsigneeFacility = model.ConsigneeFacility;
                    existingRecord.ConsigneePhone = model.ConsigneePhone;
                    existingRecord.BuyerAddressName = model.BuyerAddressName;
                    existingRecord.BuyerAddressLine1 = model.BuyerAddressLine1;
                    existingRecord.BuyerAddressLine2 = model.BuyerAddressLine2;
                    existingRecord.BuyerAddressLine3 = model.BuyerAddressLine3;
                    existingRecord.BuyerDist = model.BuyerDist;
                    existingRecord.BuyerState = model.BuyerState;
                    existingRecord.BuyerCountry = model.BuyerCountry;
                    existingRecord.BuyerFacility = model.BuyerFacility;
                    existingRecord.BuyerPhone = model.BuyerPhone;
                    existingRecord.FinalDestination = model.FinalDestination;
                    existingRecord.PortOfDischarge = model.PortOfDischarge;
                    existingRecord.KindAttention = model.KindAttention;
                    existingRecord.PortOfLoading = model.PortOfLoading;
                    existingRecord.CountryOfOrigin = model.CountryOfOrigin;
                    existingRecord.PaymentTerms = model.PaymentTerms;
                    existingRecord.Vessel_FlightNo = model.Vessel_FlightNo;
                    existingRecord.TermsOfDelivery = model.TermsOfDelivery;
                    existingRecord.IECNO = model.IECNO;
                    existingRecord.GSTIN = model.GSTIN;
                    existingRecord.FEI = model.FEI;
                    existingRecord.FDAFacilityRegn = model.FDAFacilityRegn;
                    existingRecord.CIN = model.CIN;
                    existingRecord.Signature = model.Signature;
                }
                else // Create new record
                {
                    dispatch_type newRecord = new dispatch_type
                    {

                        id = model.id,
                        type = model.Type,
                        TypeCode = model.TypeCode,
                        SN_Plant_Name = model.SNPlantName,
                        SN_PlantAddressLine1 = model.SNPlantAddressLine1,
                        SN_PlantAddressLine2 = model.SNPlantAddressLine2,
                        SN_PlantAddressLine3 = model.SNPlantAddressLine3,
                        Dist = model.Dist,
                        State = model.State,
                        Country = model.Country,
                        Phone = model.Phone,
                        ConsigneeAddressName = model.ConsigneeAddressName,
                        ConsigneeAddressLine1 = model.ConsigneeAddressLine1,
                        ConsigneeAddressLine2 = model.ConsigneeAddressLine2,
                        ConsigneeAddressLine3 = model.ConsigneeAddressLine3,
                        ConsigneeDist = model.ConsigneeDist,
                        ConsigneeState = model.ConsigneeState,
                        ConsigneeCountry = model.ConsigneeCountry,
                        ConsigneeFacility = model.ConsigneeFacility,
                        ConsigneePhone = model.ConsigneePhone,
                        BuyerAddressName = model.BuyerAddressName,
                        BuyerAddressLine1 = model.BuyerAddressLine1,
                        BuyerAddressLine2 = model.BuyerAddressLine2,
                        BuyerAddressLine3 = model.BuyerAddressLine3,
                        BuyerDist = model.BuyerDist,
                        BuyerState = model.BuyerState,
                        BuyerCountry = model.BuyerCountry,
                        BuyerFacility = model.BuyerFacility,
                        BuyerPhone = model.BuyerPhone,
                        FinalDestination = model.FinalDestination,
                        PortOfDischarge = model.PortOfDischarge,
                        KindAttention = model.KindAttention,
                        PortOfLoading = model.PortOfLoading,
                        CountryOfOrigin = model.CountryOfOrigin,
                        PaymentTerms = model.PaymentTerms,
                        Vessel_FlightNo = model.Vessel_FlightNo,
                        TermsOfDelivery = model.TermsOfDelivery,
                        IECNO = model.IECNO,
                        GSTIN = model.GSTIN,
                        FEI = model.FEI,
                        FDAFacilityRegn = model.FDAFacilityRegn,
                        CIN = model.CIN,
                        Signature = model.Signature,
                    };

                    context.dispatch_type.Add(newRecord);
                }

                context.SaveChanges();
                return RedirectToAction("ViewSetting");
            }

            return View("AddSettings", model);
        }

        // GET: SettingCategory
        public ActionResult ViewSetting()
        {
            List<SettingCategoryViewModel> Model = new List<SettingCategoryViewModel>();

            Model = (from modal in context.dispatch_type
                     select new SettingCategoryViewModel
                     {
                         id = modal.id,
                         Type = modal.type,
                         TypeCode = modal.TypeCode,
                         SNPlantName = modal.SN_Plant_Name,
                         SNPlantAddressLine1 = modal.SN_PlantAddressLine1,
                         SNPlantAddressLine2 = modal.SN_PlantAddressLine2,
                         SNPlantAddressLine3 = modal.SN_PlantAddressLine3,
                         Dist = modal.Dist,
                         State = modal.State,
                         Country = modal.Country,
                         Phone = modal.Phone,
                         ConsigneeAddressName = modal.ConsigneeAddressName,
                         ConsigneeAddressLine1 = modal.ConsigneeAddressLine1,
                         ConsigneeAddressLine2 = modal.ConsigneeAddressLine2,
                         ConsigneeAddressLine3 = modal.ConsigneeAddressLine3,
                         ConsigneeDist = modal.ConsigneeDist,
                         ConsigneeState = modal.ConsigneeState,
                         ConsigneeCountry = modal.ConsigneeCountry,
                         ConsigneeFacility = modal.ConsigneeFacility,
                         ConsigneePhone = modal.ConsigneePhone,
                         BuyerAddressName = modal.BuyerAddressName,
                         BuyerAddressLine1 = modal.BuyerAddressLine1,
                         BuyerAddressLine2 = modal.BuyerAddressLine2,
                         BuyerAddressLine3 = modal.BuyerAddressLine3,
                         BuyerDist = modal.BuyerDist,
                         BuyerState = modal.BuyerState,
                         BuyerCountry = modal.BuyerCountry,
                         BuyerFacility = modal.BuyerFacility,
                         BuyerPhone = modal.BuyerPhone,
                         FinalDestination = modal.FinalDestination,
                         PortOfDischarge = modal.PortOfDischarge,
                         KindAttention = modal.KindAttention,
                         PortOfLoading = modal.PortOfLoading,
                         CountryOfOrigin = modal.CountryOfOrigin,
                         PaymentTerms = modal.PaymentTerms,
                         Vessel_FlightNo = modal.Vessel_FlightNo,
                         TermsOfDelivery = modal.TermsOfDelivery,
                         IECNO = modal.IECNO,
                         GSTIN = modal.GSTIN,
                         FEI = modal.FEI,
                         FDAFacilityRegn = modal.FDAFacilityRegn,
                         CIN = modal.CIN,
                         Signature = modal.Signature
                     }).ToList();

            return View(Model);
        }



        public ActionResult AddSettings(int id)
        {
            dispatch_type addDetails = context.dispatch_type.Where(p => p.id == id).FirstOrDefault();
            SettingCategoryViewModel model = new SettingCategoryViewModel
            {
                id = addDetails.id,
                Type = addDetails.type,
                TypeCode = addDetails.TypeCode,
                SNPlantName = addDetails.SN_Plant_Name,
                SNPlantAddressLine1 = addDetails.SN_PlantAddressLine1,
                SNPlantAddressLine2 = addDetails.SN_PlantAddressLine2,
                SNPlantAddressLine3 = addDetails.SN_PlantAddressLine3,
                Dist = addDetails.Dist,
                State = addDetails.State,
                Country = addDetails.Country,
                Phone = addDetails.Phone,
                ConsigneeAddressName = addDetails.ConsigneeAddressName,
                ConsigneeAddressLine1 = addDetails.ConsigneeAddressLine1,
                ConsigneeAddressLine2 = addDetails.ConsigneeAddressLine2,
                ConsigneeAddressLine3 = addDetails.ConsigneeAddressLine3,
                ConsigneeDist = addDetails.ConsigneeDist,
                ConsigneeState = addDetails.ConsigneeState,
                ConsigneeCountry = addDetails.ConsigneeCountry,
                ConsigneeFacility = addDetails.ConsigneeFacility,
                ConsigneePhone = addDetails.ConsigneePhone,
                BuyerAddressName = addDetails.BuyerAddressName,
                BuyerAddressLine1 = addDetails.BuyerAddressLine1,
                BuyerAddressLine2 = addDetails.BuyerAddressLine2,
                BuyerAddressLine3 = addDetails.BuyerAddressLine3,
                BuyerDist = addDetails.BuyerDist,
                BuyerState = addDetails.BuyerState,
                BuyerCountry = addDetails.BuyerCountry,
                BuyerFacility = addDetails.BuyerFacility,
                BuyerPhone = addDetails.BuyerPhone,
                FinalDestination = addDetails.FinalDestination,
                PortOfDischarge = addDetails.PortOfDischarge,
                KindAttention = addDetails.KindAttention,
                PortOfLoading = addDetails.PortOfLoading,
                CountryOfOrigin = addDetails.CountryOfOrigin,
                PaymentTerms = addDetails.PaymentTerms,
                Vessel_FlightNo = addDetails.Vessel_FlightNo,
                TermsOfDelivery = addDetails.TermsOfDelivery,
                IECNO = addDetails.IECNO,
                GSTIN = addDetails.GSTIN,
                FEI = addDetails.FEI,
                FDAFacilityRegn = addDetails.FDAFacilityRegn,
                CIN = addDetails.CIN,
                Signature = addDetails.Signature
            };
            return View(model);
        }
    }
}