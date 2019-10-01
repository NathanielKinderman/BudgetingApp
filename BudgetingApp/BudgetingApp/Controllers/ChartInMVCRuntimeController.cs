using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetingApp.Controllers
{
    public class ChartInMVCRuntimeController : Controller
    {
        // GET: ChartInMVCRuntime
        public ActionResult Index()
        {
            return View("~/Views/RuntimeChart/ChartInMVC.cshtml");
        }

        [HttpPost]
        public JsonResult NewChart(string strEducation, string strLodging, string strFooding, string strTravelling, string strCommunication, string strOthers,
           decimal educationValue, decimal lodgingValue, decimal foodingValue, decimal travellingValue, decimal communicationValue, decimal othersValue)
        {
            educationValue = Math.Round(educationValue, 0);
            lodgingValue = Math.Round(lodgingValue, 0);
            foodingValue = Math.Round(foodingValue, 0);
            travellingValue = Math.Round(travellingValue, 0);
            communicationValue = Math.Round(communicationValue, 0);

            List<object> iData = new List<object>();
            //Creating sample data    
            DataTable dt = new DataTable();
            dt.Columns.Add("Expense", System.Type.GetType("System.String"));
            dt.Columns.Add("ExpenseValues", System.Type.GetType("System.Int32"));

            //For Education  
            DataRow dr = dt.NewRow();
            dr["Expense"] = strEducation;
            dr["ExpenseValues"] = educationValue;
            dt.Rows.Add(dr);

            //For Lodging  
            dr = dt.NewRow();
            dr["Expense"] = strLodging;
            dr["ExpenseValues"] = lodgingValue;
            dt.Rows.Add(dr);

            //For Fooding  
            dr = dt.NewRow();
            dr["Expense"] = strFooding;
            dr["ExpenseValues"] = foodingValue;
            dt.Rows.Add(dr);

            //For Travelling  
            dr = dt.NewRow();
            dr["Expense"] = strTravelling;
            dr["ExpenseValues"] = travellingValue;
            dt.Rows.Add(dr);

            //For Communication  
            dr = dt.NewRow();
            dr["Expense"] = strCommunication;
            dr["ExpenseValues"] = communicationValue;
            dt.Rows.Add(dr);

            //For Others  
            dr = dt.NewRow();
            dr["Expense"] = strCommunication;
            dr["ExpenseValues"] = othersValue;
            dt.Rows.Add(dr);

            //Looping and extracting each DataColumn to List<Object>    
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            ViewBag.ChartData = iData;
            //Source data returned as JSON    
            return Json(iData, JsonRequestBehavior.AllowGet);
        }


    }
}