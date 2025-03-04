using PackSlipApp.Database.Models;
using PackSlipApp.Filter;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
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
                // Check if it's an edit or a new record
                var existingRecord = context.dispatch_type.FirstOrDefault(x => x.id == model.Id);

                if (existingRecord != null) // Update existing record
                {
                    

                         existingRecord.id = model.Id;
                         existingRecord.type = model.Type;
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
                }
                else // Create new record
                {
                    dispatch_type newRecord = new dispatch_type
                    {
                       
                        id = model.Id,
                        type = model.Type,
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
                    Id=modal.id,
                    Type = modal.type,
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
                      }).ToList();

            return View(Model);
        }

        public ActionResult AddSettings(int id)
        {
            dispatch_type addDetails = context.dispatch_type.Where(p=>p.id == id).FirstOrDefault();
            SettingCategoryViewModel model = new SettingCategoryViewModel
            {

                Id = addDetails.id,
                Type = addDetails.type,
                
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
                
            };
            return View(model);
        }
    }
}