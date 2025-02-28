using PackSlipApp.Database.Models;
using PackSlipApp.Service;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PackSlipApp.Controllers
{
    public class UserInputController : Controller
    {
        // GET: UserInput
        ITe_INDIAEntities1 context = new ITe_INDIAEntities1();
        Dispatchservice _service = new Dispatchservice();

        public ActionResult AddPackslipData()
        {
            return View();
        }



        [HttpPost]
        public JsonResult SavePackingList(List<PackingDetails> packingList)
        {
            try
            {
                if (packingList != null && packingList.Count > 0)
                {
                    Dispatch_PackingDetails dispatch_PackslipNum = new Dispatch_PackingDetails();

                    string packslipno = (context.Dispatch_PackingDetails.OrderByDescending(p => p.PackslipNo).Select(p => p.PackslipNo).FirstOrDefault()) + 1;
                    dispatch_PackslipNum.PackslipNo = packslipno;
                    dispatch_PackslipNum.InvoiceNo = packslipno;
                    dispatch_PackslipNum.Date = DateTime.Now;
                    dispatch_PackslipNum.Category = "Medical";
                    context.Dispatch_PackingDetails.Add(dispatch_PackslipNum);
                    context.SaveChanges();



                    List<Dispatch_Data> dispatchDataList = packingList.Select(p => new Dispatch_Data
                    {

                        ID = dispatch_PackslipNum.ID,
                        PartNo = p.PartNo,
                        JobNo = p.JobNo,
                        LM = p.LM,
                        Qty = p.Qty,
                        wPcs = p.WPcs,
                        Box = p.Box,
                        PoNo = p.Po,
                        LineNo = p.LineNo,
                        MaterialDetails = p.MaterialDetails,
                        TotalWeight = p.TotalWeight,
                        PackingType = p.PackingType,
                        BoxWeight = p.BoxWeight

                    }).ToList();

                    // Add data to the DispatchDatas table
                    context.Dispatch_Data.AddRange(dispatchDataList);
                    context.SaveChanges();
                    return Json(new { success = true, message = "Packing list saved successfully!" });
                }
            }
            catch (DbEntityValidationException ex)
            {
                //errormessage = ex.Message;

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }
            }

            return Json(new { success = false, message = "No data to save." });
        }


        public ActionResult GetPartnorevno(string idjobnumber)
        {
            try
            {
                string partno = "";
                List<string> Ponum = new List<string>();
                List<string> lineno = new List<string>();
                DataTable dataTable = _service.GetPartNum(idjobnumber);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    partno = row["PartNum"].ToString();

                    DataTable _dataTable = _service.GetPOlineno(partno);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow _row in _dataTable.Rows)
                        {

                            Ponum.Add(_row["PONUM"].ToString());
                            lineno.Add(_row["POLine"].ToString());
                        }
                    }

                    return Json(new { PartNum = partno, Lineno = lineno, PoNum = Ponum }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}