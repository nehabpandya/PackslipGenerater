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
            string lastPackslipNo = context.Dispatch_PackingDetails
                                                    .OrderByDescending(p => p.PackslipNo)
                                                    .Select(p => p.PackslipNo)
                                                    .FirstOrDefault();

            int currentYear = DateTime.Now.Year;

            int lastNo = 0;
            int lastYear = currentYear;

            if (!string.IsNullOrEmpty(lastPackslipNo) && lastPackslipNo.Contains("/"))
            {
                string[] parts = lastPackslipNo.Split('/');
                int.TryParse(parts[0], out lastNo);
                int.TryParse(parts[1], out lastYear);
            }

            int newPackslipNo = (lastYear == currentYear) ? lastNo + 1 : 1;

            string packslipno = $"{newPackslipNo}/{currentYear}";
            ViewBag.PackslipNo = packslipno;
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

                    //string _packslipno = (context.Dispatch_PackingDetails.OrderByDescending(p => p.PackslipNo).Select(p => p.PackslipNo).FirstOrDefault()) + 1;
                    try
                    {
                        string lastPackslipNo = context.Dispatch_PackingDetails.OrderByDescending(p => p.ID).Select(p => p.PackslipNo).FirstOrDefault();

                        string lastInvoiceNo = context.Dispatch_PackingDetails.OrderByDescending(p => p.ID).Select(p => p.InvoiceNo).FirstOrDefault();
                        int currentYear = DateTime.Now.Year;
                        int lastNo = 0;
                        int _lastNo = 0;
                        int lastYear = currentYear;

                        if (!string.IsNullOrEmpty(lastPackslipNo) && lastPackslipNo.Contains("/"))
                        {
                            string[] parts = lastPackslipNo.Split('/');
                            int.TryParse(parts[0], out lastNo);
                            int.TryParse(parts[1], out lastYear);
                        }
                        if (!string.IsNullOrEmpty(lastInvoiceNo) && lastInvoiceNo.Contains("/"))
                        {
                            string[] _parts = lastInvoiceNo.Split('/');
                            string[] _pinvoice = _parts[0].Split('-');
                            int.TryParse(_pinvoice[1], out _lastNo);
                        }

                        int newPackslipNo = (lastYear == currentYear) ? lastNo + 1 : 1;
                        int newinvoicepNo = (lastYear == currentYear) ? _lastNo + 1 : 1;
                        string financialYear = _service.GetFinancialYear();

                        string packslipno = "";
                        string invoiceno = "";

                        packslipno = $"{newPackslipNo}/{currentYear}";

                        if (packingList[0].PackingListType == "Free sample")
                        {
                            invoiceno = $"FS-{newinvoicepNo}/{financialYear}";
                        }
                        else
                        {
                            invoiceno = $"EXP-{newinvoicepNo}/{financialYear}";
                        }

                        dispatch_PackslipNum.PackslipNo = packslipno;
                        dispatch_PackslipNum.InvoiceNo = invoiceno;
                        dispatch_PackslipNum.Date = DateTime.Now;
                        dispatch_PackslipNum.Category = packingList[0].PackingListType;
                        context.Dispatch_PackingDetails.Add(dispatch_PackslipNum);
                        context.SaveChanges();

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var validationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                            }
                        }
                    }
                    List<Dispatch_Data> dispatchDataList = packingList.Select(p =>
                    {
                        int boxLength = 0, boxWidth = 0, boxHeight = 0;

                        if (!string.IsNullOrEmpty(p.PackingType) && p.PackingType.Contains("*"))
                        {
                            string[] dimensions = p.PackingType.Split('*');
                            if (dimensions.Length == 3)
                            {
                                int.TryParse(dimensions[0], out boxLength);
                                int.TryParse(dimensions[1], out boxWidth);
                                int.TryParse(dimensions[2], out boxHeight);
                            }
                        }
                        return new Dispatch_Data
                        {
                            PID = dispatch_PackslipNum.ID,
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
                            BoxWeight = p.BoxWeight,
                            BoxLength = boxLength,
                            BoxWidth = boxWidth,
                            BoxHeight = boxHeight
                        };
                    }).ToList();

                    context.Dispatch_Data.AddRange(dispatchDataList);
                    context.SaveChanges();
                    return Json(new { success = true, message = "Packing list saved successfully!", redirectUrl = Url.Action("AddPackslipData", "UserInput") });
                }
            }
            catch (Exception ex)
            {
               
            }
            return Json(new { success = true, message = "Packing list saved successfully!", redirectUrl = Url.Action("AddPackslipData", "UserInput") });
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