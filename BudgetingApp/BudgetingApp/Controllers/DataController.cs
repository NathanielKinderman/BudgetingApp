using BudgetingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetingApp.Controllers
{
    public class DataController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index(int id)
        {
            var  madeActivites = context.MadeActivites.ToList();
            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (MadeActivites activity in madeActivites)                
            {
                dataPoints.Add(new DataPoint(activity.NameOfActivity, activity.EstimatedCostOfActivity));

            }
            

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }


    }
}