//Author: Eric Qin
//Date: 02/14/25
//Assignment: Homework 2
using Microsoft.AspNetCore.Mvc;
using Qin_Eric_HW2.Models;

namespace Qin_Eric_HW2.Controllers
{
    public class HomeController : Controller
    {
        // default return Index page
        public IActionResult Index()
        {
            return View();
        }

        // return CheckoutStandard page
        public IActionResult CheckoutStandard()
        {
            return View();
        }

        //handle StandardOrder logic, push to StandardTotals page
        [HttpPost]
        public IActionResult StandardTotals(StandardOrder standardOrder)
        {
            //check model state
            if (ModelState.IsValid == false)
            {
                return View("CheckoutStandard", standardOrder);
            }
            //set customer type and push to totals page
            standardOrder.CustomerType = CustomerType.Standard;
            standardOrder.CalcTotals();
            return View("StandardTotals", standardOrder);
        }

        // return CheckoutEvent page
        public IActionResult CheckoutEvent()
        {
            return View();
        }

        //validate CheckoutEvent, push to EventTotals page
        [HttpPost]
        public IActionResult EventTotals(EventOrder eventOrder)
        {
            //check model state
            if (ModelState.IsValid == false)
            {
                return View("CheckoutEvent", eventOrder);
            }
            //set customer type and push to totals page
            eventOrder.CustomerType = CustomerType.Event;
            eventOrder.CalcTotals();
            return View("EventTotals", eventOrder);
        }
    }
}
